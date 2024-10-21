namespace Coach_s_Log.DTO.SportsmenDTO
{
    public record class SportsmenResponse(
        string FullName,
        bool IsMale,
        DateTime Birthday,
        int Category,
        DateTime Beginnning,
        string Address,
        string Contacts
        /*Dictionary<bool, DateOnly> Attendance*/);
}
