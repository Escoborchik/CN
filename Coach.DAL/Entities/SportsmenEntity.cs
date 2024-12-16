using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class SportsmenEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;       
        public bool IsMale { get; set; }
        public DateOnly Birthday { get; set; }
        public int Category {  get; set; }
        public DateOnly Beginnning { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;       
        public List<AttendanceEntity> Attendance { get; set; } = [];        
        public List<PaymentEntity> PayInformationEntities { get; set; } = [];        
        public GroupEntity Group { get; set; }
        public CoachEntity CoachEntity { get; set; }

    }
}
