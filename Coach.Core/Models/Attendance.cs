namespace Coach.Core.Models
{
    public class Attendance
    {
        private Attendance(DateTime date, bool isPresent)
        {
            Date = date;
            IsPresent = isPresent;
        }

        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public static Attendance Create(DateTime date, bool isPresent)
        {          
            var attendance = new Attendance(date,isPresent);

            return attendance;
        }
    }
}
