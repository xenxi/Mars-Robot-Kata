using Amdiaz.MartianRobots.Domain.Rovers.Terrains;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using System;

namespace Amdiaz.MartianRobots.Terrains
{
    public class MarsTerrain : ITerrain
    {
        private static Coordinates _minCoordinates = new Coordinates(0, 0);
        private readonly Coordinates _maxCoordinates;

        public MarsTerrain(int maxX, int maxY)
        {
            _maxCoordinates = new Coordinates(x: maxX, y: maxY);
        }

        public bool IsOnTheSurface(Coordinates position)
        {
            return position.X > _maxCoordinates.X ||
                   position.X < _minCoordinates.X ||
                   position.Y > _maxCoordinates.Y ||
                   position.Y < _minCoordinates.Y;
        }

        public bool SmellsLikeDeadRobot(Coordinates position)
        {
            throw new NotImplementedException();
        }

        internal static ITerrain From(string command)
        {
            throw new NotImplementedException();
        }
    }
}