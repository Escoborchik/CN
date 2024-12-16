using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.Core.Models
{
    public class Payment
    {
        public Payment(Guid id, DateOnly date, int paid, string image, Guid sportsmenId)
        {
            Id = id;
            Date = date;
            Paid = paid;           
            Image = image;
            SportsmenId = sportsmenId;
        }

        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public int Paid { get; set; }
        public string Image { get; set; }              
        public Guid SportsmenId { get; set; }

    }
}