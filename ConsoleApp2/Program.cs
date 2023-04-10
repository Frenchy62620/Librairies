using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("add parameters");
            var input = Console.ReadLine();
            var values = input.Split(' ');
            NumberOfButtonPress();
            NumberOfButtonPress(values);
            Console.ReadLine();
        }
        public static void NumberOfButtonPress()
        {
            int current = 1;
            int goal = 10;
            var Floors = new (int up, int down)[10]
            {
                (2, 3), (2, 3),(2, 0), (2, 1), (2, 1),
                (2, 1), (2, 1),(2, 3), (2, 1), (2, 1),
            };

            var result = BFS(Floors, current, goal);
            if (result < 0)
                Console.WriteLine("Uses stairs!");
            else
                Console.WriteLine($"You need {result} steps");

        }
        public static void NumberOfButtonPress(string[] values)
        {
            int nbfloors = int.Parse(values[0]);
            int current = int.Parse(values[1]);
            int goal = int.Parse(values[2]);
            int up = int.Parse(values[3]);
            int down = int.Parse(values[4]);

            var result = BFS(nbfloors, up, down, current, goal);
            if (result < 0)
                Console.WriteLine("Uses stairs!");
            else
                Console.WriteLine($"You need {result} steps");

        }
        private static int BFS((int up, int down)[] floors, int start, int end)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            HashSet<int> seen = new HashSet<int>();
            q.Enqueue((start, 0));
            seen.Add(start);

            while (q.Count > 0)
            {
                (int currFloor, int numSteps) = q.Dequeue();
                Console.WriteLine($"Dequeue: f={currFloor} -> s={numSteps}");
                if (currFloor == end)
                {
                    return numSteps;
                }

                if (floors[currFloor - 1].up + currFloor <= floors.Length)
                {
                    int nextFloor = currFloor + floors[currFloor - 1].up;
                    if (!seen.Contains(nextFloor))
                    {
                        q.Enqueue((nextFloor, numSteps + 1));
                        seen.Add(nextFloor);
                        Console.WriteLine($"  Enqueue: f={nextFloor} -> s={numSteps}");
                    }
                }
                else if (currFloor - floors[currFloor - 1].down >= 1)
                {
                    int nextFloor = currFloor - floors[currFloor - 1].down;
                    if (!seen.Contains(nextFloor))
                    {
                        q.Enqueue((nextFloor, numSteps + 1));
                        seen.Add(nextFloor);
                        Console.WriteLine($"  Enqueue: f={nextFloor} -> s={numSteps}");
                    }
                }
            }
            return -1;
        }
        private static int BFS(int nbfloors, int up, int down, int start, int end)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            HashSet<int> seen = new HashSet<int>();
            q.Enqueue((start, 0));
            seen.Add(start);

            while (q.Count > 0)
            {
                (int currFloor, int numSteps) = q.Dequeue();
                Console.WriteLine($"Dequeue: f={currFloor} -> s={numSteps}");
                if (currFloor == end)
                {
                    return numSteps;
                }

                if (up + currFloor <= nbfloors)
                {
                    int nextFloor = currFloor + up;
                    if (!seen.Contains(nextFloor))
                    {
                        q.Enqueue((nextFloor, numSteps + 1));
                        seen.Add(nextFloor);
                        Console.WriteLine($"  Enqueue: f={nextFloor} -> s={numSteps}");
                    }
                }
                else if (currFloor - down >= 1)
                {
                    int nextFloor = currFloor - down;
                    if (!seen.Contains(nextFloor))
                    {
                        q.Enqueue((nextFloor, numSteps + 1));
                        seen.Add(nextFloor);
                        Console.WriteLine($"  Enqueue: f={nextFloor} -> s={numSteps}");
                    }
                }
            }
            return -1;
        }
    }
}
/*
Here is the algorithm of the program in C#:

1) Define a static function called BFS which takes in five parameters: floors, up, down, start, and end. This function returns an integer.
2) Inside the function, create a new Queue object named q which will hold tuples of integers.
3) Create a new HashSet object named seen which will hold integers representing the floors that have been visited.
4) Add the starting floor to the queue along with the number of steps taken to get there (which is initially 0).
5) Add the starting floor to the seen set.
6) While the queue is not empty, do the following:
a. Dequeue the first tuple from the queue, which contains the current floor and the number of steps taken to get there.
b. If the current floor is equal to the end floor, return the number of steps taken to get there.
c. If it is possible to go up from the current floor without exceeding the maximum number of floors, do the following:
i. Calculate the next floor by adding the number of floors to go up to the current floor.
ii. If the next floor has not been seen before, add it to the queue along with the number of steps taken to get there plus 1 (since going up takes one step).
iii. Add the next floor to the seen set.
d. If it is not possible to go up from the current floor without exceeding the maximum number of floors, check if it is possible to go down from the current floor without going below the minimum floor:
i. Calculate the next floor by subtracting the number of floors to go down from the current floor.
ii. If the next floor has not been seen before, add it to the queue along with the number of steps taken to get there plus 1 (since going down takes one step).
iii. Add the next floor to the seen set.
If the end floor is not reached, return -1.
*/
