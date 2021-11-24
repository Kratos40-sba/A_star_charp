using System.Collections.Generic;

namespace a_star
{
    public interface Graph<L>
    {
        double Cost(Location a, Location b);
        IEnumerable<Location> Neighbors(Location id);
    }
    
}