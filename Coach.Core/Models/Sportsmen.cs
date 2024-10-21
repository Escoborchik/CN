namespace Coach.Core.Models
{
    public class Sportsmen
    {
        public Sportsmen(Guid id, string userName, string passwordHash, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts/* Dictionary<bool, DateOnly> attendance*//*, Gruop? gruop, PayInformation? payInformation*/)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            FullName = fullName;
            IsMale = isMale;
            Birthday = birthday;
            Category = category;
            Beginnning = beginnning;
            Address = address;
            Contacts = contacts;
            //Attendance = attendance;
            //Gruop = gruop;
            //PayInformation = payInformation;
        }

        public Guid Id { get; }
        public string UserName { get; } = string.Empty;
        public string PasswordHash { get; } = string.Empty;
        public string FullName { get; } = string.Empty;
        public bool IsMale { get; }
        public DateTime Birthday { get; }
        public int Category { get; }
        public DateTime Beginnning { get; }
        public string Address { get; } = string.Empty;
        public string Contacts { get; } = string.Empty;
        //public Dictionary<bool, DateOnly> Attendance { get; } = [];
        //public Gruop? Gruop { get; }
        //public PayInformation? PayInformation { get; }

        public static (Sportsmen Sportsmen, string Error) Create(Guid id, string userName, string passwordHash, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts/*, Dictionary<bool, DateOnly> attendance*//*, Gruop? gruop, PayInformation? payInformation*/)
        {
            var error = string.Empty;

            var sportsmen = new Sportsmen(id, userName,passwordHash,fullName,isMale,birthday,category,beginnning,address,contacts/*attendance*/);

            return (sportsmen, error);

        }
    }
}