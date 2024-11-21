using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coach.DAL.Entities
{
    public class AttendanceEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public bool IsPresent {  get; set; } 
    }
}
