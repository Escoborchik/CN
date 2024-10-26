using Coach.Core.Models;
using Coach_s_Log.DTO.PayInformationDTO;

namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenResponse(
        string FullName,
        bool IsMale,
        DateTime Birthday,
        int Category,
        DateTime Beginnning,
        string Address,
        string Contacts,
        PayInformationResponse payInformation,
        List<Attendance> Attendance);
}
