namespace Coach.Core.Models
{
    public class Attendance
    {
        private Attendance(Guid id, DateOnly date, bool isPresent)
        {
            AttendanceId = id;
            Date = date;
            IsPresent = isPresent;
        }
        public Guid AttendanceId { get; set; }
        public DateOnly Date { get; set; }
        public bool IsPresent { get; set; }

        public static Attendance Create(Guid id, DateOnly date, bool isPresent)
        {          
            var attendance = new Attendance(id,date,isPresent);

            return attendance;
        }
    }
}
