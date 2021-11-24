using System;
using System.Collections.Generic;

namespace a_star
{
    class Program
    {
        public static void DrawGrid(Grid grid, AstarSearch aStarSearch)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Location id = new Location(j,i );
                    Location ptr = id;
                    if (!aStarSearch.From.TryGetValue(id, out ptr))
                    {
                        ptr = id; 
                    }

                    if (grid.walls.Contains(id))
                    {
                        Console.Write("##");
                    }
                    else if (ptr.x == j+1){Console.Write("\u2192");}
                    else if (ptr.x == j-1){Console.Write("\u2190");}
                    else if (ptr.y == i+1){Console.Write("\u2193");}
                    else if (ptr.y == i-1){Console.Write("\u2191");}
                    else {Console.Write("* ");}
                    

                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            var grid = new Grid(10, 10);
            for (int i = 1; i < 4; i++)
            {
                for (int j = 7; j < 9; j++)
                {
                    grid.walls
                        .Add(new Location(i, j));
                }
            }

            grid.forests = new HashSet<Location>
            {
                new Location(3,4), new Location(3,5),
                new Location(4,1), new Location(4,2),
                new Location(4,3), new Location(4,4),
                new Location(4,5), new Location(4,6),
                new Location(4,7), new Location(4,8),
                new Location(5,1), new Location(5,2),
                new Location(5,3), new Location(5,4),
                new Location(5,5), new Location(5,6),
                new Location(5,7), new Location(5,8),
                new Location(6,2), new Location(6,3),
                new Location(6,4), new Location(6,5),
                new Location(6,6), new Location(6,7),
                new Location(7,3), new Location(7,4),
                new Location(7,5)

            };
            var astar = new AstarSearch(grid, new Location(1, 4), new Location(8, 5));
            DrawGrid(grid,astar);   
        }
    }
}