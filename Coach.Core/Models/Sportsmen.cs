namespace Coach.Core.Models
{
    public class Sportsmen
    {
        public Sportsmen(Guid id, string userName, string passwordHash, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts,PayInformation payInformation, List<Attendance> attendance/*  Gruop? gruop,  */)
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
            Attendance = attendance;
            PayInformation = payInformation;
            //Gruop = gruop;

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
        public PayInformation PayInformation { get; }
        public List<Attendance> Attendance { get; } = [];
        //public Gruop? Gruop { get; }         

        public static (Sportsmen Sportsmen, string Error) Create(Guid id, string userName, string passwordHash, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts, PayInformation payInformation, List<Attendance> attendance/*,   Gruop? gruop, */)
        {
            var error = string.Empty;

            var sportsmen = new Sportsmen(id, userName,passwordHash,fullName,isMale,birthday,
                category,beginnning,address, contacts,payInformation,attendance);

            return (sportsmen, error);

        }
    }
}