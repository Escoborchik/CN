namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenRegisterRequest(
        string FullName,                
        int Category,
        DateOnly Beginnning,
        string UserName,
        string Password);  
}
