using Coach.Core.Interfaces;
using System.Text;

namespace Coach.Infrastructure.Authentication
{
    public class DataGenerator : IDataGenerator
    {
       private readonly static Dictionary<char, string> translitMap = new Dictionary<char, string>
        {
            {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"}, {'е', "e"}, {'ё', "e"},
            {'ж', "zh"}, {'з', "z"}, {'и', "i"}, {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"},
            {'н', "n"}, {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"}, {'у', "u"},
            {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"}, {'ш', "sh"}, {'щ', "shch"},
            {'ы', "y"}, {'э', "e"}, {'ю', "yu"}, {'я', "ya"}
        };
        public (string, string) Generate(string fullname)
        {
            var data = fullname.Split(' ');
            var surname = data[0];
            var name = data[1];
            var secondName = data[2];
            string login = GenerateLogin(name, surname);
            string password = GeneratePassword(name, surname, secondName);
            return (login, password);
        }
        static string GenerateLogin(string firstName, string lastName)
        {
            string initials = Transliterate(firstName[0].ToString() + lastName[0].ToString());
            string transliteratedLastName = Transliterate(lastName);

            return initials + transliteratedLastName;
        }

        static string GeneratePassword(string firstName, string middleName, string lastName)
        {
            string passwordBase = Transliterate(firstName[0].ToString() + middleName[0].ToString() + lastName[0].ToString()).ToUpper();

            Random random = new Random();
            string randomChars = "!@#$%^&*()_+";
            passwordBase += random.Next(0, 10);
            passwordBase += randomChars[random.Next(0, randomChars.Length)];

            return passwordBase;
        }

        static string Transliterate(string input)
        {
            

            StringBuilder result = new StringBuilder();
            input = input.ToLower();

            foreach (char c in input)
            {
                if (translitMap.TryGetValue(c, out string latin))
                {
                    result.Append(latin);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
