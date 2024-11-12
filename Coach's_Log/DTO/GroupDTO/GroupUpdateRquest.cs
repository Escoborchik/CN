namespace Coach_s_Log.DTO.GroupDTO
{
    public record class GroupUpdateRquest(
        Guid groupId,
        string name,
        List<Guid> sportsmen
        );        
}
