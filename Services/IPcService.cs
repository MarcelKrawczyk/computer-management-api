using ComputerManagementApi.DTOs;

namespace ComputerManagementApi.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllDto>> GetAllAsync();
    Task<PcGetByIdDto?> GetByIdWithComponentsAsync(int id);
    Task<PcResponseDto> CreateAsync(PcCreateDto dto);
    Task<bool> UpdateAsync(int id, PcUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
