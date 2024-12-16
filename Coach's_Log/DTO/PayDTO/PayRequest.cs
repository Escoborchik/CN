namespace Coach_s_Log.DTO.PayDTO
{
    public record class PayRequest(
        DateOnly Date,
        int Summary,
        string Image,
        Guid Sportsmen);
    
}
