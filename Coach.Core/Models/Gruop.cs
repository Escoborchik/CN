namespace Coach.Core.Models
{
    public class Gruop
    {
        private Gruop(Guid id, string name, short price, CoachModel coach, List<Sportsmen> sportsmens)
        {
            Id = id;
            Name = name;
            Price = price;
            Coach = coach;
            Sportsmens = sportsmens;
        }

        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public short Price { get; }

        public CoachModel? Coach { get; } 
        public List<Sportsmen> Sportsmens { get; } = new();

        public static (Gruop Coach, string Error) Create(Guid id, string name, short price, CoachModel coach, List<Sportsmen> sportsmens)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can't be empty!";
            }

            var gruop = new Gruop(id, name, price, coach,sportsmens);

            return (gruop, error);

        }
    }
}