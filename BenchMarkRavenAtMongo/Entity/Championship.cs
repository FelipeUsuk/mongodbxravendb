using System;

namespace BenchMarkRavenAtMongo.Entity
{
    public class Championship
    {
        public string ChampionshipName { get; set; }

        public int Year { get; set; }

        public static Championship RandomCreator()
        {
            var rand = new System.Random();
            var randomNameSize = rand.Next(30);
            var randomYear = rand.Next(1850,2018);
            
            return new Championship()
            {
                ChampionshipName = Guid.NewGuid().ToString().Substring(0, randomNameSize),
                Year = randomYear
            };
        }

    }
}