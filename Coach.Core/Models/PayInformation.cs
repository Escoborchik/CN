namespace Coach.Core.Models
{
    public class PayInformation(int numberTrain, int price, int summary)
    {

        public int NumberTrain { get; } = numberTrain;
        public int Price { get; } = price;
        public int Summary { get; } = summary;
    }
}
