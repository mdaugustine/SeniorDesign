using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static int heading;
        static int x;
        static int y;
        static char[,] grid = new char[21,21]; //-10,-10 to 10,10
        static int[] xObstacles = new int[10] {-5, 4, 2, -9, 8, 4, -10, -7, 9, -4};
        static int[] yObstacles = new int[10] {3, 6, 9, 1, -6, -3, -5, 8, -2, 1};

        static string getHeadingString()
        {
            switch (heading)
            {
                case 0:
                    return "North";
                case 1:
                    return "East";
                case 2:
                    return "South";
                case 3:
                    return "West";
            }

            return "Err";
        }

        static void TurnRight()
        {
            if (heading < 3)
                heading++;
            else
                heading = 0;
        }

        static void TurnLeft()
        {
            if (heading > 0)
                heading--;
            else
                heading = 3;
        }

        static void Move(string direction)
        {
            if (direction.Equals("forward"))
            {
                switch (heading)
                {
                    case 0:
                        y++;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        x--;
                        break;
                }
            }
            else
            {
                switch (heading)
                {
                    case 0:
                        y--;
                        break;
                    case 1:
                        x--;
                        break;
                    case 2:
                        y++;
                        break;
                    case 3:
                        x++;
                        break;
                }
            }

            if (x > 10)
                x = x - 21;
            if (x < -10)
                x = x + 21;
            if (y > 10)
                y = y - 21;
            if (y < -10)
                y = y + 21;

            for (int i = 0; i < 10; i++)
            {
                if (x == xObstacles[i] && y == yObstacles[i])
                {
                    if (direction.Equals("forward"))
                    {
                        switch (heading)
                        {
                            case 0:
                                y--;
                                break;
                            case 1:
                                x--;
                                break;
                            case 2:
                                y++;
                                break;
                            case 3:
                                x++;
                                break;
                        }
                    }
                    else
                    {
                        switch (heading)
                        {
                            case 0:
                                y++;
                                break;
                            case 1:
                                x++;
                                break;
                            case 2:
                                y--;
                                break;
                            case 3:
                                x--;
                                break;
                        }
                    }

                    Console.WriteLine("There is an obstacle there");
                }
            }
        }

        static void plotGrid()
        {
            for (int n = 0; n <= 20; n++)
            {
                for (int m = 0; m <= 20; m++)
                {
                    grid[n, m] = '-';
                }
            }

            grid[x + 10, y + 10] = '@';

            for (int i = 0; i < 10; i++)
            {
                grid[xObstacles[i] + 10, yObstacles[i] + 10] = 'x';
            }

            for (int j = 20; j >= 0; j--)
            {
                for (int i = 0; i <= 20; i++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            heading = 0;
            x = 0;
            y = 0;
            string instruction;

            Console.WriteLine(
                "L or l turn left\n" +
                "R or r turn right\n" +
                "F or f move forward\n" +
                "B or b move backward\n" +
                "exit to leave\n");

            do
            {
                Console.WriteLine(
                    "Location: ({0}, {1})\n" +
                    "Heading {2}", x, y, getHeadingString());
                plotGrid();

                instruction = Console.ReadLine();

                foreach (char i in instruction.ToCharArray())
                {
                    switch (i)
                    {
                        case 'l':
                            TurnLeft();
                            break;
                        case 'L':
                            TurnLeft();
                            break;
                        case 'r':
                            TurnRight();
                            break;
                        case 'R':
                            TurnRight();
                            break;
                        case 'f':
                            Move("forward");
                            break;
                        case 'F':
                            Move("forward");
                            break;
                        case 'b':
                            Move("back");
                            break;
                        case 'B':
                            Move("back");
                            break;
                        default:
                            Console.WriteLine("Invalid character \"{0}\" was removed from instruction", i);
                            break;
                    }
                }

            } while (!instruction.Equals("exit"));

        }
    }
}
