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

        public void Add(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedBy = _currentUserService.GetCurrentUserId();
                baseEntity.CreatedDate = _dateTimeProvider.UtcNow;
            }
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException($"Entity with ID {id} not found.");

            // Set soft delete properties
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.IsDeleted = true;
                baseEntity.DeletedDate = _dateTimeProvider.UtcNow;
                baseEntity.DeletedBy = _currentUserService.GetCurrentUserId();
            }

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.Where(o => !o.IsDeleted).ToList();
        }

        public T GetById(Guid id)
        {
            return _dbSet.Where(o => o.Id == id && !o.IsDeleted).FirstOrDefault() ?? throw new NotFoundException(id + " not found!");
        }

        public void Update(T entity)
        {
            var existingEntity = _dbSet.FirstOrDefault(o => o.Id == entity.Id) ?? throw new NotFoundException(entity.Id + " not found!");

            if (entity is BaseEntity baseEntity)
            {
                baseEntity.UpdatedDate = _dateTimeProvider.UtcNow;
                baseEntity.UpdatedBy = _currentUserService.GetCurrentUserId();
            }

            _dbSet.Update(existingEntity);
            _context.SaveChanges();
        }
    }
}