using Hcd.Application.Common.Interfaces;
using Hcd.Application.Common.Interfaces.Services;
using Hcd.Common.Exceptions;
using Hcd.Common.Interfaces;
using Hcd.Data;
using Hcd.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hcd.Application.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ICurrentUserService _currentUserService;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context, IDateTimeProvider dateTimeProvider, ICurrentUserService currentUserService)
        {
            _dateTimeProvider = dateTimeProvider;
            _currentUserService = currentUserService;
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.Where(o => !o.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
            return entity ?? throw new NotFoundException(id + " not found!");
        }

        public async Task AddAsync(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedBy = _currentUserService.GetCurrentUserId();
                baseEntity.CreatedDate = _dateTimeProvider.UtcNow;
            }
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await GetByIdAsync(id);

            // Set soft delete properties
            if (existingEntity is BaseEntity baseEntity)
            {
                baseEntity.IsDeleted = true;
                baseEntity.DeletedDate = _dateTimeProvider.UtcNow;
                baseEntity.DeletedBy = _currentUserService.GetCurrentUserId();
            }

            _dbSet.Update(existingEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var existingEntity = await GetByIdAsync(entity.Id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            if (existingEntity is BaseEntity baseEntity)
            {
                baseEntity.UpdatedDate = _dateTimeProvider.UtcNow;
                baseEntity.UpdatedBy = _currentUserService.GetCurrentUserId();
            }

            _context.Entry(existingEntity).Property(e => ((BaseEntity)e).CreatedDate).IsModified = false;
            _context.Entry(existingEntity).Property(e => ((BaseEntity)e).CreatedBy).IsModified = false;

            _dbSet.Update(existingEntity);
            await _context.SaveChangesAsync();
        }
    }
}