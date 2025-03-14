using Hcd.Common.Models;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Requests.System.Option;
using Hcd.Application.Manages.System;
using Hcd.Data.Entities.System;

namespace Hcd.Application.Services.System
{
    public class OptionService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private OptionManager OptionManager => GetService<OptionManager>();

        public async Task<GetAllOptionsResponse> GetAllOptions(GetAllOptionsRequest request)
        {
            var Options = OptionManager.GetAll();

            var paginationResponse = await PaginationResponse<Option>.Create(
            Options,
            request
        );
            var response = Mapper.Map<GetAllOptionsResponse>(paginationResponse);
            return response;
        }        public async Task<UpdateOptionResponse> UpdateOption(UpdateOptionRequest request)
        {
            var Option = await OptionManager.FindAsync(request.Id) ?? throw new NotFoundException($"Option with {request.Id} not found!!");
            var updatedOption = request.Adapt(Option);

            await OptionManager.Update(Option);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<UpdateOptionResponse>(updatedOption);
        }
    }
}