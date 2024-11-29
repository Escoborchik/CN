using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class AttendanceEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public bool IsPresent {  get; set; }

        [ForeignKey(nameof(Sportsmen))]
        public Guid SportstmenId { get; set; }
        public SportsmenEntity Sportsmen { get; set; }
    }
}
