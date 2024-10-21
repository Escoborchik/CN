using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class GruopEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public short Price { get; set; }

        [ForeignKey(nameof(Coach))]
        public Guid CoachId { get; set; }

        public CoachEntity? Coach { get; set; }
        public List<SportsmenEntity>? Sportsmens { get; set; }
    }
}
