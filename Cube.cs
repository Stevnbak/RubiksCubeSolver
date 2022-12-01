using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver
{
    internal class Cube
    {
        //State array
        public string[] state = new string[54];

        //Total rotations
        public int totalRotations = 0;

        //Constructors
        public Cube(bool scramble)
        {
            string[] colors = new string[6] { "w", "o", "g", "r", "b", "y" };
            for(int c = 0; c < 6; c++)
            {
                for (int i = 0; i < 9; i++)
                {
                    state[c * 9 + i] = colors[c];
                }
            }
            if (scramble) Scramble(10);
            totalRotations = 0;
        }
        public Cube(Cube cube)
        {
            for (int i = 0; i < cube.state.Length; i++)
            {
                state[i] = cube.state[i];
            }
            totalRotations = 0;
        }
        //Scramble cube
        private void Scramble(int moves)
        {
            Random rnd = new Random();
            for (int i = 0; i < moves; i++)
            {
                string[] algorithms = new string[20] {"FRUruf","RUrURUUr","luLulUUL","RbRFFrBRFFRR","FFurLFFRluFF","RRURUrururUr","RuruRURDruRdrUUr","RUrurFRRuruRUrf","RRuRuRUrURRdURurD","rURurfuFRUrFrfRuR","RRDrUURdrUUr","RUruYURuyr","rFRUrufUR","RUburURBr","yruRurURurUUYR","RUURRuRurUUFRf","RUrUrFRfUUrFRf","XFRUruxfUFRUruf","uRUrubrFRfB","YRUruyURur"
                };
                int r = rnd.Next(20);
                Program.performAlgorithm(algorithms[r], this, 0, 2);
            }
        }

        //Log current cube state to console
        public void Log()
        {
            Console.WriteLine("---------------------------------");
            //Draw white face
            for(int line = 0; line < 3; line++)
            {
                //Space break to line up correctly
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[00][00][00]");
                //Draw the actual faces
                for(int i = line * 3; i < (line + 1) * 3; i++)
                {
                    Console.ForegroundColor = color(state[i]);
                    Console.Write($"[ {i}]");
                }
                //New line
                Console.WriteLine();
            }
            //Draw orange, green, red and blue face
            for (int line = 3; line < 6; line++)
            {
                for (int i = line * 3; i < (line * 3) + 30; i++)
                {
                    //Skip to correct numbers...
                    if (i == line * 3 + 3) i = line * 3 + 9;
                    if (i == line * 3 + 12) i = line * 3 + 18;
                    if (i == line * 3 + 21) i = line * 3 + 27;
                    //Write in console
                    Console.ForegroundColor = color(state[i]);
                    Console.Write("[" + (i > 9 ? i : " " + i) + "]");
                }
                //New line
                Console.WriteLine();
            }
            //Draw yellow face
            for (int line = 0; line < 3; line++)
            {
                //Space break to line up correctly
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[00][00][00]");
                //Draw the actual faces
                for (int i = 45 + line * 3; i < 45 + (line + 1) * 3; i++)
                {
                    Console.ForegroundColor = color(state[i]);
                    Console.Write($"[{i}]");
                }
                //New line
                Console.WriteLine();
            }
            //Reset color
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("---------------------------------");

            //Color function
            ConsoleColor color(string value)
            {
                if (value == "w") return ConsoleColor.White;
                else if (value == "o") return ConsoleColor.DarkYellow;
                else if (value == "g") return ConsoleColor.Green;
                else if (value == "r") return ConsoleColor.DarkRed;
                else if (value == "b") return ConsoleColor.Blue;
                else if (value == "y") return ConsoleColor.Yellow;
                else return ConsoleColor.Black;
            }
        }

        //Rotate face clock wise.
        public void RotateClockWise(int side, bool count = true)
        {
            if (count) totalRotations++;
            //Create copy of state
            string[] oldState = new string[54];
            state.CopyTo(oldState, 0);

            //Create dictionary of face pairs
            Dictionary<int, int> pairs;
            //Setup sides rotation
            switch (side)
            {
                case 0:
                    pairs = new Dictionary<int, int>() { { 9, 18 }, { 10, 19 }, { 11, 20 }, { 18, 27 }, { 19, 28 }, { 20, 29 }, { 27, 36 }, { 28, 37 }, { 29, 38 }, { 36, 9 }, { 37, 10 }, { 38, 11 } };
                    break;
                case 1:
                    pairs = new Dictionary<int, int>() { { 0, 44 }, { 3, 41 }, { 6, 38 }, { 18, 0 }, { 21, 3 }, { 24, 6 }, { 45, 18 }, { 48, 21 }, { 51, 24 }, { 44, 45 }, { 41, 48 }, { 38, 51 } };
                    break;
                case 2:
                    pairs = new Dictionary<int, int>() { { 6, 17 }, { 7, 14 }, { 8, 11 }, { 27, 6 }, { 30, 7 }, { 33, 8 }, { 45, 33 }, { 46, 30 }, { 47, 27 }, { 11, 45 }, { 14, 46 }, { 17, 47 } };
                    break;
                case 3:
                    pairs = new Dictionary<int, int>() { { 8, 26 }, { 5, 23 }, { 2, 20 }, { 20, 47 }, { 23, 50 }, { 26, 53 }, { 47, 42 }, { 50, 39 }, { 53, 36 }, { 36, 8 }, { 39, 5 }, { 42, 2 } };
                    break;
                case 4:
                    pairs = new Dictionary<int, int>() { { 2, 35 }, { 1, 32 }, { 0, 29 }, { 9, 2 }, { 12, 1 }, { 15, 0 }, { 53, 15 }, { 52, 12 }, { 51, 9 }, { 29, 53 }, { 32, 52 }, { 35, 51 } };
                    break;
                case 5:
                    pairs = new Dictionary<int, int>() { { 15, 42 }, { 16, 43 }, { 17, 44 }, { 24, 15 }, { 25, 16 }, { 26, 17 }, { 33, 24 }, { 34, 25 }, { 35, 26 }, { 42, 33 }, { 43, 34 }, { 44, 35 } };
                    break;
                default:
                    pairs = new Dictionary<int, int>();
                    break;
            }
            //Setup face rotation
            int start = side * 9;
            // Corners
            pairs.Add(start + 0, start + 6);
            pairs.Add(start + 6, start + 8);
            pairs.Add(start + 2, start + 0);
            pairs.Add(start + 8, start + 2);
            //  Edges
            pairs.Add(start + 1, start + 3);
            pairs.Add(start + 3, start + 7);
            pairs.Add(start + 7, start + 5);
            pairs.Add(start + 5, start + 1);

            //Perform the string manipulation
            foreach (KeyValuePair<int, int> pair in pairs)
            {
                state[pair.Key] = oldState[pair.Value];
            }
        }
        public void RotateCenterClockWise(int side, bool count = true)
        {
            if (count) totalRotations++;
            //Create copy of state
            string[] oldState = new string[54];
            state.CopyTo(oldState, 0);

            //Create dictionary of face pairs
            Dictionary<int, int> pairs;
            //Setup sides rotation
            switch (side)
            {
                case 0:
                    pairs = new Dictionary<int, int>() { { 12, 21 }, { 13, 22 }, { 14, 23 }, { 21, 30 }, { 22, 31 }, { 23, 32 }, { 30, 39 }, { 31, 40 }, { 32, 41 }, { 39, 12}, { 40, 13 }, { 41, 14 } };
                    break;
                case 1:
                    pairs = new Dictionary<int, int>() { { 46, 19 }, { 49, 22 }, { 52, 25 }, { 43, 46 }, { 40, 49 }, { 37, 52 }, { 7, 37}, { 4, 40 }, { 1, 43}, { 25, 7}, { 22, 4 }, { 19, 1} };
                    break;
                case 2:
                    pairs = new Dictionary<int, int>() { { 5, 10 }, { 4, 13 }, { 3, 16 }, { 10, 48 }, { 13, 49 }, { 16, 50 }, { 48, 34 }, { 49, 31 }, { 50, 28 }, { 34, 5 }, { 31, 4 }, { 28, 3 } };
                    break;
                case 3:
                    pairs = new Dictionary<int, int>() { { 19, 46 }, { 22, 49 }, { 25, 52 }, { 46, 43 }, { 49, 40 }, { 52, 37 }, { 37, 7 }, { 40, 4 }, { 43, 1 }, { 7, 25 }, { 4, 22 }, { 1, 19 } };
                    break;
                case 4:
                    pairs = new Dictionary<int, int>() { { 10, 5 }, { 13, 4 }, { 16, 3 }, { 48, 10 }, { 49, 13 }, { 50, 16 }, { 34, 48 }, { 31, 49 }, { 28, 50 }, { 5, 34 }, { 4, 31 }, { 3, 28 } };
                    break;
                case 5:
                    pairs = new Dictionary<int, int>() { { 21, 12 }, { 22, 13 }, { 23, 14 }, { 30, 21 }, { 31, 22 }, { 32, 23 }, { 39, 30 }, { 40, 31 }, { 41, 32 }, { 12, 39 }, { 13, 40 }, { 14, 41 } };
                    break;
                default:
                    pairs = new Dictionary<int, int>();
                    break;
            }
            //Perform the string manipulation
            foreach (KeyValuePair<int, int> pair in pairs)
            {
                state[pair.Key] = oldState[pair.Value];
            }
        }
        public void RotateAntiClockWise(int side)
        {
            RotateClockWise(side, true);
            RotateClockWise(side, false);
            RotateClockWise(side, false);
        }
        public void RotateCenterAntiClockWise(int side)
        {
            RotateCenterClockWise(side, true);
            RotateCenterClockWise(side, false);
            RotateCenterClockWise(side, false);
        }
        public bool IsSolved()
        {
            string[] colors = new string[6] { "w", "o", "g", "r", "b", "y" };
            for (int c = 0; c < 6; c++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if(state[c * 9 + i].ToString() != colors[c].ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
