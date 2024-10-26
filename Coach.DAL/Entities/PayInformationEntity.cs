using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class PayInformationEntity
    {
        public Guid Id { get; set; }
        public int Summary { get; set; }
        public int Overpayment { get; set; }
        public int Debt { get; set; }
        public List<string> Images { get; set; } = [];
       
    }
}
