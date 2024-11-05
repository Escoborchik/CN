namespace Coach.Core.Models
{
    public class Group
    {
        private Group(Guid id, string name, short price, List<Sportsmen> sportsmens)
        {
            Id = id;
            Name = name;
            Price = price;            
            Sportsmens = sportsmens;
        }

        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public short Price { get; }
      
        public List<Sportsmen> Sportsmens { get; } = [];

        public static (Group Coach, string Error) Create(Guid id, string name, short price, List<Sportsmen> sportsmens)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can't be empty!";
            }

            var gruop = new Group(id, name, price, sportsmens);

            return (gruop, error);

        }
    }
}