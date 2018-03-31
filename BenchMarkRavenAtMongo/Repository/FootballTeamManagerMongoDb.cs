using BenchMarkRavenAtMongo.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BenchMarkRavenAtMongo.Repository
{
    class FootballTeamManagerMongoDb : IFootballTeamManager
    {
        MongoClient cliente;
        IMongoDatabase db;
        IMongoCollection<FootballTeam> col;

        public FootballTeamManagerMongoDb()
        {
            var connectionString = "mongodb://localhost:27017";
            cliente = new MongoClient(connectionString);
            db = cliente.GetDatabase("Football");
            col = db.GetCollection<FootballTeam>("FootballTeam");
        }

        public void SaveATeam(FootballTeam team)
        {
            col.InsertOne(team);
        }

        public void SaveTeams(List<FootballTeam> teams)
        {
            col.InsertMany(teams);
        }

        public List<FootballTeam> SearchByFoundation(int foundation)
        {
           var items = col.AsQueryable<FootballTeam>();

            return items.Where(i => i.Foundation == foundation).ToList();
        }

        public List<FootballTeam> SearchByName(string teamName)
        {
            var items = col.AsQueryable<FootballTeam>();

            return items.Where(i => i.Name == teamName).ToList();
        }

     
    }
}

