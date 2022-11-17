
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.SubcomponentValue;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class SubcomponentValueService : BaseService, ISubcomponentValueService
    {
        public SubcomponentValueService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<SubcomponentValueDto> CreateAsync(SubcomponentValueCreateDto request)
        {
            var subcomponentValue = _mapper.Map<SubcomponentValue>(request);

            await _unitOfWorkApp.Repository.SubcomponentValueRepository.AddAsync(subcomponentValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<SubcomponentValueDto>(subcomponentValue);
        }

        public async Task<bool> UpdateAsync(SubcomponentValueUpdateDto request)
        {
            var subcomponentValue = _mapper.Map<SubcomponentValue>(request);

            await _unitOfWorkApp.Repository.SubcomponentValueRepository.UpdateAsync(subcomponentValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var subcomponentValue = await _unitOfWorkApp.Repository.SubcomponentValueRepository.GetAsync(id);

            if (subcomponentValue is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.SubcomponentValueRepository.DeleteAsync(subcomponentValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<List<SubcomponentValueDto>> GetAllBySubcomponentAsync(Guid subcomponentId)
        {
            var subcomponentsValue = await _unitOfWorkApp.Repository.SubcomponentValueRepository
                   .Find(c => c.SubcomponentId.Equals(subcomponentId))
                   .ProjectTo<SubcomponentValueDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();

            return subcomponentsValue;
        }
    }
}
