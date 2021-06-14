using Bogus;

namespace Amdiaz.Test.MartianRobots.Infrastructure
{
    public static class MotherCreator
    {
        public static Randomizer Random()
            => new Faker().Random;
    }
}