using Amdiaz.MartianRobots.Domain.Exceptions;
using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Domain.ValueObjects
{
    public sealed class Coordinates : ValueObject
    {
        public const int MaxCoordinateValue = 50;
        public const int MinCoordinateValue = 0;

        public Coordinates(int x, int y)
        {
            guard(x, y);

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }

        private void guard(int x, int y)
        {
            if (x < MinCoordinateValue
                || x > MaxCoordinateValue
                || y < MinCoordinateValue
                || y > MaxCoordinateValue)
                throw new InvalidCoordinatesException($"x:{x} y:{y} out of rage ( x: {MinCoordinateValue}-{MaxCoordinateValue}" +
                    $" y: {MinCoordinateValue}-{MaxCoordinateValue})");
        }
    }
}