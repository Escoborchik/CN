namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenRegisterRequest(
        Guid CoachId,
        string FullName,                
        int Category,
        DateOnly Beginnning,
        string UserName,
        string Password);  
}
