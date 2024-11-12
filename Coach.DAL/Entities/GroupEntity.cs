using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class GroupEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(Coach))]
        public Guid CoachId { get; set; }
        public CoachEntity Coach { get; set; }
        public List<SportsmenEntity> Sportsmens { get; set; } = [];
    }
}
