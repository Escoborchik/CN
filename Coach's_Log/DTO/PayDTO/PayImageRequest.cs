namespace Coach_s_Log.DTO.PayDTO
{
    public record class PayImageRequest(
        String Date,
        int Summary,
        Guid Sportsmen,
        IFormFile ImageFile);
}
