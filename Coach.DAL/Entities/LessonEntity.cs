using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class LessonEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }          
        public Guid Coach { get; set; }     
        public Guid Gruop { get; set; }
    }
}
