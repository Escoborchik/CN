namespace Coach_s_Log.DTO.PayInformationDTO
{
    public record class PayInformationResponse(
      int Summary,
      int Overpayment,
      int Debt,
      List<string> Images);

}
