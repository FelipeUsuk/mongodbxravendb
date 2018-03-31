using BenchMarkRavenAtMongo.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchMarkRavenAtMongo.Repository
{
    interface IFootballTeamManager
    {
         void SaveATeam(FootballTeam team);

        List<FootballTeam> SearchByFoundation(int foundation);

        List<FootballTeam> SearchByName(string teamName);

        void SaveTeams(List<FootballTeam> teams);
    }
}
