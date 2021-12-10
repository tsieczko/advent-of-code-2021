namespace AdventOfCode2021.Day02
{
    public class Dive1
    {
        public static int Run(string[] commandStrings)
        {
            var horizontalPosition = 0;
            var depth = 0;

            foreach (var commandString in commandStrings)
            {
                var splitCommandString = commandString.Split();
                var direction = splitCommandString[0];
                var distance = int.Parse(splitCommandString[1]);

                switch (direction)
                {
                    case "forward":
                        horizontalPosition += distance;
                        break;
                    case "down":
                        depth += distance;
                        break;
                    case "up":
                        depth -= distance;
                        break;
                }
            }

            return horizontalPosition * depth;
        }
    }
}
