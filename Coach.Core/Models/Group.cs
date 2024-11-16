namespace Coach.Core.Models
{
    public class Group
    {
        private Group(Guid id, Guid coachId, string name, List<Sportsmen> sportsmens) : this(id, coachId,name)
        {                       
            Sportsmens = sportsmens;
            CoachId = coachId;
        }

        private Group(Guid id, Guid coachId, string name)
        {
            Id = id;
            CoachId = coachId;
            Name = name;             
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;      
        public Guid CoachId { get; set; }
        public CoachModel Coach { get; set; }
        public List<Sportsmen> Sportsmens { get; } = [];

        public static (Group Group, string Error) Create(Guid id, Guid coachId, string name, List<Sportsmen> sportsmens)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can't be empty!";
            }

            var gruop = new Group(id,coachId, name, sportsmens);

            return (gruop, error);

        }

        public static (Group Group, string Error) Create(Guid id, Guid coachId, string name)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can't be empty!";
            }

            var gruop = new Group(id, coachId, name);

            return (gruop, error);

        }
    }
}