using BenchMarkRavenAtMongo.Entity;
using BenchMarkRavenAtMongo.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BenchMarkRavenAtMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Bench!");
            TesteDeInsercao();
            TesteDeBusca();

        }

        private static void TesteDeBusca()
        {
            var mongoRepo = new FootballTeamManagerMongoDb();
            var ravenRepo = new FootballTeamManagerRavenDb();

            var swmongo = new Stopwatch();
            var swraven = new Stopwatch();

            Console.WriteLine("Teste de Busca um valor do tipo inteiro realizando 3 buscas consecultivas");

            BuscaPorIntMongo(mongoRepo, swmongo);
            BuscaPorIntRaven(ravenRepo, swraven);

            swmongo.Reset();
            swraven.Reset();

            Console.WriteLine("Teste de Busca um valor do tipo string realizando 5 buscas consecultivas");


            BuscaPorStringMongo(mongoRepo, swmongo);
            BuscaPorStringRaven(ravenRepo, swraven);

            Console.ReadKey();
        }

        //Trocar valores com o que for gerado para seu banco
        private static void BuscaPorStringRaven(FootballTeamManagerRavenDb ravenRepo, Stopwatch swraven)
        {
            swraven.Start();
            var resultRaven = ravenRepo.SearchByName("219b74e0-b205-4d2f-bae8-a3e");
            resultRaven = ravenRepo.SearchByName("6a4863d4-fd12-4436-83");
            resultRaven = ravenRepo.SearchByName("eb75781a-8388-46a3-9c");
            resultRaven = ravenRepo.SearchByName("397af1d9-2406-45b0-9b2c");
            resultRaven = ravenRepo.SearchByName("04944a79-");
            swraven.Stop();
            Console.WriteLine($"RavenDb busca por Nomes (dados tirados da base)-  {swraven.ElapsedMilliseconds} ms | {swraven.ElapsedTicks} ticks");
        }


        //Trocar valores com o que for gerado para seu banco
        private static void BuscaPorStringMongo(FootballTeamManagerMongoDb mongoRepo, Stopwatch swmongo)
        {
            swmongo.Start();
            var resultMongo = mongoRepo.SearchByName("219b74e0-b205-4d2f-bae8-a3e");
            resultMongo = mongoRepo.SearchByName("6a4863d4-fd12-4436-83");
            resultMongo = mongoRepo.SearchByName("eb75781a-8388-46a3-9c");
            resultMongo = mongoRepo.SearchByName("397af1d9-2406-45b0-9b2c");
            resultMongo = mongoRepo.SearchByName("04944a79-");
            swmongo.Stop();
            Console.WriteLine($"MongoDb busca por Nomes (dados tirados da base)-  {swmongo.ElapsedMilliseconds} ms | {swmongo.ElapsedTicks} ticks");
        }

        private static void BuscaPorIntRaven(FootballTeamManagerRavenDb ravenRepo, Stopwatch swraven)
        {
            swraven.Start();
            var resultRaven = ravenRepo.SearchByFoundation(2000);
            resultRaven = ravenRepo.SearchByFoundation(1975);
            resultRaven = ravenRepo.SearchByFoundation(2012);
            swraven.Stop();
            Console.WriteLine($"RavenDb busca por fundação (anos de 2000, 1975 e 2012) -  {swraven.ElapsedMilliseconds} ms | {swraven.ElapsedTicks} ticks");
        }

        private static void BuscaPorIntMongo(FootballTeamManagerMongoDb mongoRepo, Stopwatch swmongo)
        {
            swmongo.Start();
            var resultMongo = mongoRepo.SearchByFoundation(2000);
            resultMongo = mongoRepo.SearchByFoundation(1975);
            resultMongo = mongoRepo.SearchByFoundation(2012);
            swmongo.Stop();
            Console.WriteLine($"MongoDb busca por fundação (anos de 2000, 1975 e 2012) -  {swmongo.ElapsedMilliseconds} ms | {swmongo.ElapsedTicks} ticks");
        }

        private static void TesteDeInsercao()
        {
            try
            {

                var mongoRepo = new FootballTeamManagerMongoDb();
                var ravenRepo = new FootballTeamManagerRavenDb();

                var swmongo = new Stopwatch();
                var swraven = new Stopwatch();

                var ListaInsertsUmAUm = new List<FootballTeam>();
                var ListaBulkInsert = new List<FootballTeam>();

        

                GerarDadosAleatorios(ListaInsertsUmAUm, ListaBulkInsert);
                TesteInserts(ListaInsertsUmAUm, mongoRepo, ravenRepo, swmongo, swraven);
                swmongo.Reset();
                swraven.Reset();
                TesteBulk(ListaBulkInsert, mongoRepo, ravenRepo, swmongo, swraven);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static void TesteBulk(List<FootballTeam> ListaBulkInsert, FootballTeamManagerMongoDb mongoRepo, FootballTeamManagerRavenDb ravenRepo, Stopwatch swmongo, Stopwatch swraven)
        {
            Console.WriteLine("Testes bulkinsert 10000 items");

            TesteBulkMongo(ListaBulkInsert, mongoRepo, swmongo);
            TesteBulkRaven(ListaBulkInsert, ravenRepo, swraven);
        }

        private static void TesteInserts(List<FootballTeam> ListaInsertsUmAUm, FootballTeamManagerMongoDb mongoRepo, FootballTeamManagerRavenDb ravenRepo, Stopwatch swmongo, Stopwatch swraven)
        {
            Console.WriteLine("Testes 1000 inserts consecultivos");




            TesteInsertMongo(ListaInsertsUmAUm, mongoRepo, swmongo);
            TesteInsertRaven(ListaInsertsUmAUm, ravenRepo, swraven);
        }

        private static void TesteBulkRaven(List<FootballTeam> ListaBulkInsert, FootballTeamManagerRavenDb ravenRepo, Stopwatch swraven)
        {
            swraven.Start();
            ravenRepo.SaveTeams(ListaBulkInsert);
            swraven.Stop();
            Console.WriteLine($"RavenDb bulkinsert 10000 itens -  {swraven.ElapsedMilliseconds} ms | {swraven.ElapsedTicks} ticks");
        }

        private static void TesteBulkMongo(List<FootballTeam> ListaBulkInsert, FootballTeamManagerMongoDb mongoRepo, Stopwatch swmongo)
        {
            swmongo.Start();
            mongoRepo.SaveTeams(ListaBulkInsert);
            swmongo.Stop();
            Console.WriteLine($"MongoDb bulkinsert 10000 itens -  {swmongo.ElapsedMilliseconds} ms | {swmongo.ElapsedTicks} ticks");
        }

        private static void TesteInsertRaven(List<FootballTeam> ListaInsertsUmAUm, FootballTeamManagerRavenDb ravenRepo, Stopwatch swraven)
        {
            swraven.Start();
            foreach (var item in ListaInsertsUmAUm)
            {
                ravenRepo.SaveATeam(item);
            }
            swraven.Stop();

            Console.WriteLine($"RavenDb 1000 inserts -  {swraven.ElapsedMilliseconds} ms | {swraven.ElapsedTicks} ticks");
        }

        private static void TesteInsertMongo(List<FootballTeam> ListaInsertsUmAUm, FootballTeamManagerMongoDb mongoRepo, Stopwatch swmongo)
        {
            swmongo.Start();
            foreach (var item in ListaInsertsUmAUm)
            {
                mongoRepo.SaveATeam(item);
            }
            swmongo.Stop();

            Console.WriteLine($"MongoDb 1000 inserts -  {swmongo.ElapsedMilliseconds} ms | {swmongo.ElapsedTicks} ticks");
        }

        private static void GerarDadosAleatorios(List<FootballTeam> ListaInsertsUmAUm, List<FootballTeam> ListaBulkInsert)
        {
            for (int i = 0; i < 1000; i++)
            {
                ListaInsertsUmAUm.Add(FootballTeam.RandomCreator());
            }

            for (int i = 0; i < 10000; i++)
            {
                ListaBulkInsert.Add(FootballTeam.RandomCreator());
            }
        }
    }
}
