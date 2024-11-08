namespace Coach_s_Log.DTO.GroupDTO
{
    public record class GroupRequest(
        string Name,
        short Price,
        List<Guid> Sportsmens);
    
}
