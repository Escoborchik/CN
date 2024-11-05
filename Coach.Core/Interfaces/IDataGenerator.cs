namespace Coach.Core.Interfaces
{
    public interface IDataGenerator
    {
        (string, string) Generate(string fullname);
    }
}