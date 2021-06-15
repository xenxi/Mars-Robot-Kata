using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Infrastructure.Rovers
{
    public class MarsTerrain : ITerrain
    {
        private static Coordinates _minCoordinates = new Coordinates(0, 0);
        private readonly Coordinates _maxCoordinates;
        private readonly List<Coordinates> _deathRobots;

        public MarsTerrain(int maxX, int maxY)
        {
            _maxCoordinates = new Coordinates(x: maxX, y: maxY);
            _deathRobots = new List<Coordinates>();
        }

        public void Flavor(Coordinates coordinates)
        {
            if (!_deathRobots.Contains(coordinates))
                _deathRobots.Add(coordinates);
        }

        public bool IsOut(Coordinates coordinates)
        {
            return coordinates.X > _maxCoordinates.X ||
                   coordinates.X < _minCoordinates.X ||
                   coordinates.Y > _maxCoordinates.Y ||
                   coordinates.Y < _minCoordinates.Y;
        }

        public bool SmellsLikeDeadRobot(Coordinates coordinates)
             => _deathRobots.Contains(coordinates);
    }
}