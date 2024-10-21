namespace Coach_s_Log.DTO.CoachDTO
{
    public record class CoachResponse(
        Guid Id,
        string UserName,
        string Email,
        string PasswordHash);
    
}
