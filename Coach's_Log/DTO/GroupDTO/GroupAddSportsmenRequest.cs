namespace Coach_s_Log.DTO.GroupDTO
{
    public record class GroupAddSportsmenRequest(
        Guid GroupId,
        List<Guid> Sportsmen
        );    
}
