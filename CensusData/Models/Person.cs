using RandomNameGeneratorLibrary;
using System;
using System.Security.Cryptography;

namespace CensusData.Models
{
    [Serializable]
    public class Person
    {
        private PersonNameGenerator nameGenerator = new PersonNameGenerator();
        public int ID { get; set; } = new Random().Next(1000);
        public string Name { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = nameGenerator.GenerateRandomFirstAndLastName();
            Occupation = getRandomString(15);
            Age = new Random().Next(18,100);
        }

        private static string getRandomString(int stringLength)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bit_count = (stringLength * 6);
                var byte_count = ((bit_count + 7) / 8); // rounded up
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
