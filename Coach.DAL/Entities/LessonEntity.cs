using Coach.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class LessonEntity
    {
        [Key]
        public Guid Id { get; set; }
        public short Price  { get; set; }
        public TimeOnly Time { get; set; }          
        public DateOnly Date { get; set; }

        [ForeignKey(nameof(Coach))]
        public Guid CoachId { get; set; }            
        public CoachEntity Coach { get; set; }

        [ForeignKey(nameof(GruopId))]
        public Guid GruopId { get; set; }
        public GroupEntity Gruop { get; set; }
    }
}
