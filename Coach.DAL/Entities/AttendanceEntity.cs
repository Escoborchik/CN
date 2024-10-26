using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coach.DAL.Entities
{
    public class AttendanceEntity
    {
        [Key]
        public DateTime Date { get; set; }
        public bool IsPresent {  get; set; } 
    }
}
