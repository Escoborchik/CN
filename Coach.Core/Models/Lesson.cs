using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.Core.Models
{
    public class Lesson
    {
        private Lesson(Guid id, short price, TimeOnly time, DateOnly date, Guid coachId, Guid gruopId)
        {
            Id = id;
            Price = price;
            Time = time;
            Date = date;
            CoachId = coachId;
            GruopId = gruopId;
        }

        private Lesson(Guid id, short price, TimeOnly time, DateOnly date, Group group)
        {
            Id = id;
            Price = price;
            Time = time;
            Date = date;
            Group = group;
        }

        public Guid Id { get; set; }
        public short Price { get; set; }
        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }
        public Guid CoachId { get; set; }
        public Guid GruopId { get; set; }
        public CoachModel Coach { get; set; }
        public Group Group { get; set; }

        public static (Lesson Lesson, string Error) Create(Guid id, short price, TimeOnly time, DateOnly date, Guid coachId, Guid gruopId)
        {
            var error = string.Empty;

            var lesson = new Lesson(id,price,time,date,coachId,gruopId);

            return (lesson, error);

        }

        public static (Lesson Lesson, string Error) Create(Guid id, short price, TimeOnly time, DateOnly date, Group group)
        {
            var error = string.Empty;

            var lesson = new Lesson(id, price, time, date, group);

            return (lesson, error);

        }
    }
}