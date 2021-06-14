using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Domain
{
    public interface IRoverCommandParamRepository
    {
        IEnumerable<RoverCommandParameters> GetAll();
    }
}