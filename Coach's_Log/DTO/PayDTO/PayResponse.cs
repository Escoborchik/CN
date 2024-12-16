using System.Runtime.CompilerServices;

namespace Coach_s_Log.DTO.PayDTO
{
    public record class PayResponse(
        DateOnly Date,
        int Paid,
        string Image
        );    
}
