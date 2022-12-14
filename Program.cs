using Microsoft.Office.Interop.Excel;

namespace RubiksCubeSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Rubik's cube solver started...");

            //Get amount of cubes
            int amount = 0;
            while (amount == 0)
            {
                try
                {
                    Console.WriteLine("Type number of cubes to solve with each method:");
                    Console.Write(">");
                    amount = int.Parse(Console.ReadLine());
                    if (amount == 0) throw new Exception();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Input not recognized as a number... Try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            //Solve cubes
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Starting solving {amount} cubes...");
            Console.ForegroundColor = ConsoleColor.White;

            object[,] data = new object[amount, 3];

            for (int i = 0; i < amount; i++)
            {
                Cube cube1 = new(true);
                Cube cube2 = new(cube1);

                //Save cube state
                data[i, 0] = $"[{String.Join(";", cube1.state)}]";
                
                //  1 - Begynder
                Method1.SolveOLL(cube1);
                Method1.SolvePLL(cube1);
                checkSolved(cube1);
                data[i, 1] = cube1.totalRotations;
                //  2 - CFOP
                Method2.SolveOLL(cube2);
                Method2.SolvePLL(cube2);
                checkSolved(cube2);
                data[i, 2] = cube2.totalRotations;
                updatePercent(i + 1, amount);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDone solving all {amount} cubes");
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Open Excel
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opening Excel workbook...");
            Application xl = new Application();
            Workbook wb = xl.Workbooks.Open(Directory.GetCurrentDirectory() + "\\Data.xlsx");
            Worksheet template = wb.Sheets[1];
            template.Copy(Type.Missing, wb.Sheets[wb.Sheets.Count]);
            Worksheet sheet = wb.Sheets[wb.Sheets.Count];
            sheet.Name = "Data - " + (wb.Sheets.Count - 1);
            //Add data to excel
            Console.WriteLine("Adding data to Excel...");
            Console.ForegroundColor = ConsoleColor.White;
            sheet.Range["A" + 2, "C" + (amount + 1)].Value = data;
            wb.Save();

            //Done!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDone saving all the data");
            xl.Visible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        private static void updatePercent(double current, double all)
        {
            double percent = (current / all) * 100;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($".... {current}/{all} - {(int) percent}% ....");
        }
        //Solve check
        public static void checkSolved(Cube cube)
        {
            //Check solved...
            if (!cube.IsSolved())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error - Cube not solved");
                Console.ForegroundColor = ConsoleColor.White;
                cube.Log();
                Console.ReadKey();
            }
        }
        //Do algorithm
        public static void performAlgorithm(string algorithm, Cube cube, int top, int front)
        {
            //Sides...
            int right;
            if (top == 0) right = front + 1 > 4 ? 1 : front + 1;
            else if (top == 5) right = front - 1 < 1 ? 4 : front - 1;
            else if (front == 0) right = top - 1 < 1 ? 4 : top - 1;
            else if (front == 5) right = top + 1 > 4 ? 1 : top + 1;
            else right = top - front == 1 ? 5 : top - front == 3 ? 5 : 0;
            int left = right switch {0 => 5, 1 => 3, 2 => 4, 3 => 1, 4 => 2, 5 => 0,};
            int down = top switch {0 => 5, 1 => 3, 2 => 4, 3 => 1, 4 => 2, 5 => 0,};
            int back = front switch {0 => 5, 1 => 3, 2 => 4, 3 => 1, 4 => 2, 5 => 0,};

            //Convert
            foreach (char part in algorithm)
            {
                //Anti Clockwise
                if (part == 'r') cube.RotateAntiClockWise(right);
                if (part == 'l') cube.RotateAntiClockWise(left);
                if (part == 'd') cube.RotateAntiClockWise(down);
                if (part == 'u') cube.RotateAntiClockWise(top);
                if (part == 'f') cube.RotateAntiClockWise(front);
                if (part == 'b') cube.RotateAntiClockWise(back);
                if (part == 'y') cube.RotateCenterAntiClockWise(right);
                if (part == 'x') cube.RotateCenterAntiClockWise(front);
                if (part == 'z') cube.RotateCenterAntiClockWise(top);
                //Clockwise
                if (part == 'R') cube.RotateClockWise(right);
                if (part == 'L') cube.RotateClockWise(left);
                if (part == 'D') cube.RotateClockWise(down);
                if (part == 'U') cube.RotateClockWise(top);
                if (part == 'F') cube.RotateClockWise(front);
                if (part == 'B') cube.RotateClockWise(back);
                if (part == 'Y') cube.RotateCenterClockWise(right);
                if (part == 'X') cube.RotateCenterClockWise(front);
                if (part == 'Z') cube.RotateCenterClockWise(top);
            }
        }
    }
}