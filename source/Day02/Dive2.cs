namespace AdventOfCode2021
{
    public class Dive2
    {
        public static int Run(string[] commandStrings)
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach (var commandString in commandStrings)
            {
                var splitCommandString = commandString.Split();
                var direction = splitCommandString[0];
                var distance = int.Parse(splitCommandString[1]);

                switch (direction)
                {
                    case "forward":
                        horizontalPosition += distance;
                        depth += aim * distance;
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                }
            }

            return horizontalPosition * depth;
        }
    }
}
