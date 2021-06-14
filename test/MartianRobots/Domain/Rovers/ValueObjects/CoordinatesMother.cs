using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.Test.MartianRobots.Infrastructure;

namespace Amdiaz.Test.MartianRobots.Domain.Rovers.ValueObjects
{
    public static class CoordinatesMother
    {
        public static Coordinates Ramdom()
            => new Coordinates(x: MotherCreator.Random().Number(min: Coordinates.MinCoordinateValue,
                                                                max: Coordinates.MaxCoordinateValue),
                               y: MotherCreator.Random().Number(min: Coordinates.MinCoordinateValue,
                                                                max: Coordinates.MaxCoordinateValue));
    }
}