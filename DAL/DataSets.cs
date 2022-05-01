using System;
using DAL.Entities;
using DAL.Enums;

namespace DAL
{
    internal static class DataSets
    {
        private static Random _random = new Random();

        internal static readonly AssassinNpc[] Assassins =
        {
            new AssassinNpc()
                {
                    Id = 1,
                    Name = "Black Widow",
                    MinReward = _random.Next(1,16),
                    MaxReward = _random.Next(16,31)
                },
            new AssassinNpc()
                {
                    Id = 2,
                    Name = "Mockingjay",
                    MinReward = _random.Next(1, 16),
                    MaxReward = _random.Next(16, 31)
                },
            new AssassinNpc()
                {
                    Id=3,
                    Name = "Lonely Barman",
                    MinReward = _random.Next(1, 16),
                    MaxReward = _random.Next(16, 31)
                },
            new AssassinNpc()
                {
                    Id = 4,
                    Name = "Robot Arlye",
                    MinReward = _random.Next(1, 16),
                    MaxReward = _random.Next(16, 31)
                },
            new AssassinNpc()
                {
                    Id = 5,
                    Name = "Sniper Ghost",
                    MinReward = _random.Next(1,16),
                    MaxReward = _random.Next(16,31)
                },
        };

        internal static readonly BeggarNpc[] Beggars = 
        {
            new BeggarNpc()
            {
                Id = 1,
                Name = "John",
                Practice = BeggarsPractice.Twitchers
            },
            new BeggarNpc()
            {
                Id = 2,
                Name = "Elleon",
                Practice = BeggarsPractice.Droolers
            },
            new BeggarNpc()
            {
                Id = 3,
                Name = "Bobby",
                Practice = BeggarsPractice.Dribblers
            },
            new BeggarNpc()
            {
                Id = 4,
                Name = "George",
                Practice = BeggarsPractice.Mumblers
            },
            new BeggarNpc()
            {
                Id = 5,
                Name = "Shyam",
                Practice = BeggarsPractice.Mutterers
            },
            new BeggarNpc()
            {
                Id = 6,
                Name = "Ronnie",
                Practice = BeggarsPractice.WalkingAlongShouters
            },
            new BeggarNpc()
            {
                Id = 7,
                Name = "Katerina",
                Practice = BeggarsPractice.Demanders
            },
            new BeggarNpc()
            {
                Id = 8,
                Name = "Tyron",
                Practice = BeggarsPractice.JimmyCaller
            },
            new BeggarNpc()
            {
                Id = 9,
                Name = "Onur",
                Practice = BeggarsPractice.EightpenceForMeal
            },
            new BeggarNpc()
            {
                Id = 10,
                Name = "Nadia",
                Practice = BeggarsPractice.TwopenceForTea
            },
            new BeggarNpc()
            {
                Id = 11,
                Name = "Mohsin",
                Practice = BeggarsPractice.BeerNeeders
            },
        };

        internal static readonly FoolNpc[] Fools = 
        {
            new FoolNpc
            {
                Id = 1,
                Name = "Dillon",
                Practice = FoolsPractice.Muggins
            },
            new FoolNpc
            {
                Id = 2,
                Name = "Zoey",
                Practice = FoolsPractice.Gull
            },
            new FoolNpc
            {
                Id = 3,
                Name = "Humphrey",
                Practice = FoolsPractice.Dupe
            },
            new FoolNpc
            {
                Id = 4,
                Name = "Stephan",
                Practice = FoolsPractice.Butt
            },
            new FoolNpc
            {
                Id = 5,
                Name = "Chloe-Louise",
                Practice = FoolsPractice.Fool
            },
            new FoolNpc
            {
                Id = 6,
                Name = "Montel",
                Practice = FoolsPractice.Tomfool
            },
            new FoolNpc
            {
                Id = 7,
                Name = "Lynn",
                Practice = FoolsPractice.StupidFool
            },
            new FoolNpc
            {
                Id = 8,
                Name = "Iylah",
                Practice = FoolsPractice.ArchFool
            },
            new FoolNpc
            {
                Id = 9,
                Name = "Jozef",
                Practice = FoolsPractice.CompleteFool
            },
        };
    }
}
