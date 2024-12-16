using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class PaymentEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date {  get; set; }                 
        public int Paid { get; set; }    
        public string Image { get; set; } 
        public SportsmenEntity Sportsmen { get; set; }

        [ForeignKey(nameof(Sportsmen))]
        public Guid SportsmenId { get; set; }
       
    }
}
