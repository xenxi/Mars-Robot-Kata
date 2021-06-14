using System;

namespace Amdiaz.MartianRobots.Shared
{
    public sealed class Speed
    {
        public Speed(int value)
        {
            guard(value);

            Value = value;
        }

        private void guard(int value)
        {
            throw new NotImplementedException();
        }

        public int Value { get; }
    }
}