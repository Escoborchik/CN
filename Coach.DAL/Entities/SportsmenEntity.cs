using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class SportsmenEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;       
        public bool IsMale { get; set; }
        public DateTime Birthday { get; set; }
        public int Category {  get; set; }
        public DateTime Beginnning { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        //public Dictionary<bool, DateOnly> Attendance { get; set; } = [];

        //[ForeignKey(nameof(Gruop))]
        //public Guid GruopId { get; set; }
        //public GruopEntity? Gruop { get; set; }

        //[ForeignKey(nameof(PayInformation))]
        //public Guid PayInformationId { get; set; }
        //public PayInformationEntity? PayInformation { get; set; }
    }
}
