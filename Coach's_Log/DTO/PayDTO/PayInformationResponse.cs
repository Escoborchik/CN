namespace Coach_s_Log.DTO.PayDTO
{
    public record class PayInformationResponse(
        List<PayResponse> PayResponses,
        int Sum,
        int Num,
        int Price);
    
}
