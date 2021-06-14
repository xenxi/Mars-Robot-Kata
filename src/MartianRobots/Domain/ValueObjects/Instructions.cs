using Amdiaz.MartianRobots.Shared.Domain;
using System;
using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Domain.ValueObjects
{
    public class Instructions : ValueObject
    {
        public const int MaxLenght = 100;

        public Instructions(string instructionsStr)
        {
            guard(instructionsStr);

            Text = instructionsStr;
        }

        public string Text { get; }

        public static implicit operator Instructions(string instructionsStr) => new Instructions(instructionsStr);

        private void guard(string instructionsStr)
        {
            if (string.IsNullOrWhiteSpace(instructionsStr))
                throw new ArgumentNullException(nameof(instructionsStr));

            if (instructionsStr.Length > MaxLenght)
                throw new ArgumentOutOfRangeException(nameof(instructionsStr));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Text;
        }
    }
}