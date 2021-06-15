using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Factories;
using Amdiaz.Test.MartianRobots.Domain.Rovers.ValueObjects;
using Amdiaz.Test.MartianRobots.Infrastructure;

namespace Amdiaz.Test.MartianRobots.Domain.Rovers.Locations
{
    public static class LocationMother
    {
        public static Location Random()
            => LocationFactory.From(orientation: MotherCreator.Random().Enum<Orientation>(),
                                    coordinates: CoordinatesMother.Ramdom());
    }
}