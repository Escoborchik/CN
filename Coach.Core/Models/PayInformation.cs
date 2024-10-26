namespace Coach.Core.Models
{
    public class PayInformation
    {
        private PayInformation(Guid id, int summary, int overpayment, int debt, List<string> images)
        {
            Id = id;
            Summary = summary;
            Overpayment = overpayment;
            Debt = debt;
            Images = images;
        }

        public Guid Id { get; }
        public int Summary { get; }
        public int Overpayment { get; }
        public int Debt { get; }
        public List<string> Images { get; } = [];

        public static (PayInformation PayInformation, string Error) Create(Guid id, int summary, int overpayment, int debt, List<string> images)
        {
            var error = string.Empty;

            var payInformation = new PayInformation(id, summary, overpayment,debt, images);

            return (payInformation, error);

        }

    }
}