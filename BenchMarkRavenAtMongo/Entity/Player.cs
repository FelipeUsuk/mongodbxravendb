using System;

namespace BenchMarkRavenAtMongo.Entity
{
    public class Player
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public static Player RandomCreator()
        {
            var rand = new System.Random();
            var randomNameSize = rand.Next(30);
            var randomCountrySize = rand.Next(15);
            var randomAge = rand.Next(18, 40);
            return new Player()
            {
                Name = Guid.NewGuid().ToString().Substring(0, randomNameSize),
                Country = Guid.NewGuid().ToString().Substring(0, randomCountrySize),
                Age = randomAge
            };
        }
    }
}