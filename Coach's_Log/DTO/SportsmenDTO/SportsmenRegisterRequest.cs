namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenRegisterRequest(
        string UserName,
        string Password,
        string FullName,
        bool IsMale,
        DateTime Birthday,
        int Category,
        DateTime Beginnning,
        string Address,
        string Contacts);  
}
