using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMarkRavenAtMongo.Entity;
using Raven.Client.Documents;
using Raven.Client.Documents.BulkInsert;
using Raven.Client.Documents.Session;

namespace BenchMarkRavenAtMongo.Repository
{
    class FootballTeamManagerRavenDb : IFootballTeamManager
    {
        private static IDocumentStore store;

        

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://localhost:8585" },
                Database = "Football"
            }.Initialize();

            return store;
        }

        public FootballTeamManagerRavenDb()
        {
          store = CreateStore();
        }
        public void SaveATeam(FootballTeam team)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Store(team);
            }
        }

        public void SaveTeams(List<FootballTeam> teams)
        {
            using (BulkInsertOperation bulkInsert = store.BulkInsert())
            {
                foreach(var team in teams)
                {
                    bulkInsert.Store(team);
                }
            }
        }

        public List<FootballTeam> SearchByFoundation(int foundation)
        {

            using (IDocumentSession session = store.OpenSession())
            {
                List<FootballTeam> teams = session
                .Advanced
                .DocumentQuery<FootballTeam>()
                .WhereEquals("Foundation", foundation)
                .ToList();

                return teams;
            }
          
        }

        public List<FootballTeam> SearchByName(string teamName)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                List<FootballTeam> teams = session
                .Advanced
                .DocumentQuery<FootballTeam>()
                .WhereEquals("Name", teamName)
                .ToList();

                return teams;
            }
        }
    }
}
