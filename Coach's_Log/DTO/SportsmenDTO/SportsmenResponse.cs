using Coach.Core.Models;
using Coach_s_Log.DTO.PayInformationDTO;

namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenResponse(
        Guid Id,
        string FullName
        );
}
