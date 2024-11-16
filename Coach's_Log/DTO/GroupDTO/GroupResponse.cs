using Coach_s_Log.DTO.SportsmenDTO;

namespace Coach_s_Log.DTO.GroupDTO
{
    public record class GroupResponse(
     Guid Id,
     string Name,
     List<SportsmenResponse> Sportsmens
    );
}
