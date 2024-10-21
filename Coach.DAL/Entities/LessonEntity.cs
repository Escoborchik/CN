using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class LessonEntity
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(Coach))]
        public Guid CoachId { get; set; }
        public CoachEntity? Coach { get; set; }

        [ForeignKey(nameof(Gruop))]
        public Guid GruopId { get; set; }
        public GruopEntity? Gruop { get; set; }
    }
}
