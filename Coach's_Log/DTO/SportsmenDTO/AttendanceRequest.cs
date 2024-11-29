namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class AttendanceRequest(
        Guid SportsmenId,
        DateOnly date,
        bool isPresent);
    
    
}
