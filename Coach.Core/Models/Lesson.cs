namespace Coach.Core.Models
{
    public class Lesson
    {
        private Lesson(Guid id, DateTime dateTime, CoachModel? coach, Group? gruop)
        {
            Id = id;
            DateTime = dateTime;
            Coach = coach;
            Gruop = gruop;
        }

        public Guid Id { get; }
        public DateTime DateTime { get; }        
        public CoachModel? Coach { get; }
        public Group? Gruop { get; }

        public static (Lesson Lesson, string Error) Create(Guid id, DateTime dateTime, CoachModel? coach, Group? gruop)
        {
            var error = string.Empty;           

            var lesson = new Lesson(id, dateTime, coach, gruop);

            return (lesson, error);

        }
    }
}