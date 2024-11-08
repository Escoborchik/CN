namespace Coach.Core.Models
{
    public class Group
    {
        private Group(Guid id, string name, short price, List<Guid> sportsmens) : this(id, name,price)
        {                       
            Sportsmens = sportsmens;
        }

        private Group(Guid id, string name, short price)
        {
            Id = id;
            Name = name;
            Price = price;             
        }

        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public short Price { get; }
      
        public List<Guid> Sportsmens { get; } = [];

        public static (Group Group, string Error) Create(Guid id, string name, short price, List<Guid> sportsmens)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can't be empty!";
            }

            var gruop = new Group(id, name, price, sportsmens);

            return (gruop, error);

        }

        public static (Group Group, string Error) Create(Guid id, string name, short price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can't be empty!";
            }

            var gruop = new Group(id, name, price);

            return (gruop, error);

        }
    }
}