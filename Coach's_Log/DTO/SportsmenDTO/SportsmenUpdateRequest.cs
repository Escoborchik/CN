using System.Net;

namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenUpdateRequest(
       bool IsMale,
       DateOnly Birthday,
       string Address,
       string Contacts);
}
