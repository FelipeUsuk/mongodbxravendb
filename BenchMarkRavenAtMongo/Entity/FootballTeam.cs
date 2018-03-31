using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchMarkRavenAtMongo.Entity
{
    [BsonIgnoreExtraElements]
    class FootballTeam
    {
        public string Name { get; set; }
        public int Foundation { get; set; }
        public string MainColors { get; set; }
        public string Stadium { get; set; }
        public List<Player> Players { get; set; }
        public List<Championship> Championships { get; set; }

        public FootballTeam()
        {
            Players = new List<Player>();
            Championships = new List<Championship>();
        }
        public static FootballTeam RandomCreator()
        {
            var rand = new System.Random();
            var randomNameSize = rand.Next(30);
            var randomColorsSize = rand.Next(15);
            var randomAge = rand.Next(18, 40);
            var randomFoundation = rand.Next(1800, 1950);
            var randomChampionships = rand.Next(2, 10);
            int playersQuantity = 21;

            var team = new FootballTeam()
            {
                Name = Guid.NewGuid().ToString().Substring(0, randomNameSize),
                MainColors = Guid.NewGuid().ToString().Substring(0, randomColorsSize),
                Stadium = Guid.NewGuid().ToString().Substring(0, randomNameSize),
                Foundation = randomFoundation,
            };

            for (int i = 0; i < playersQuantity; i++)
            {
                team.Players.Add(Player.RandomCreator());
            }

            for (int i = 0; i < randomChampionships; i++)
            {
                team.Championships.Add(Championship.RandomCreator());
            }
            return team;
        }
    }
}
