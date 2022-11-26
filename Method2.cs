using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver
{
    //CFOP method
    internal class Method2
    {
        public static void SolveOLL(Cube cube)
        {
            //OLL
            string ollState = checkOLLState(cube);
            int side = int.Parse(ollState.ElementAt(0).ToString());
            ollState = ollState.Substring(1);
            string ollAlgorithm;
            switch (ollState)
            {
                //Solved Edges
                case "Sune":
                    ollAlgorithm = "RUrURUUr";
                    break;
                case "Cross":
                    ollAlgorithm = "RUUruRUruRur";
                    break;
                case "Chameleon":
                    ollAlgorithm = "YRUruyrFRf";
                    break;
                case "AntiSune":
                    ollAlgorithm = "RUUruRur";
                    break;
                case "Bruno":
                    ollAlgorithm = "RUURRuRRuRRUUR";
                    break;
                case "Headlights":
                    ollAlgorithm = "RRDrUURdrUUr";
                    break;
                case "Bowtie":
                    ollAlgorithm = "fYRUruyrFR";
                    break;
                //T-Shapes
                case "T":
                    ollAlgorithm = "FRUruf";
                    break;
                case "Key":
                    ollAlgorithm = "RUrurFRf";
                    break;
                //Squares
                case "RightySquare":
                    ollAlgorithm = "YRUUruRuyr";
                    break;
                case "LeftySquare":
                    ollAlgorithm = "yrUURUrUYR";
                    break;
                //Solved Corners
                case "Arrow":
                    ollAlgorithm = "YRUruyURur";
                    break;
                case "H":
                    ollAlgorithm = "RUruYURuyr";
                    break;
                //Lightning Bolts
                case "Lightning":
                    ollAlgorithm = "YRUrURUUyr";
                    break;
                case "ReverseLightning":
                    ollAlgorithm = "yruRurUUYR";
                    break;
                case "Downstairs":
                    ollAlgorithm = "yrRRUrURUUrUY";
                    break;
                case "Upstairs":
                    ollAlgorithm = "YruRurUURuy";
                    break;
                case "BigLightning":
                    ollAlgorithm = "rFRUrufUR";
                    break;
                case "LeftyBigLightning":
                    ollAlgorithm = "LfluLUFul";
                    break;
                //P-Shapes
                case "P":
                    ollAlgorithm = "XFRUruxf";
                    break;
                case "InverseP":
                    ollAlgorithm = "xfluLUXF";
                    break;
                case "Couch":
                    ollAlgorithm = "ruFURurfR";
                    break;
                case "AntiCouch":
                    ollAlgorithm = "RUburURBr";
                    break;
                //C-Shapes
                case "SeeinHeadlights":
                    ollAlgorithm = "rurFRfUR";
                    break;
                case "City":
                    ollAlgorithm = "uRUrubrFRfB";
                    break;
                //Fishes
                case "MountedFish":
                    ollAlgorithm = "FRuruRUrf";
                    break;
                case "FishSalad":
                    ollAlgorithm = "RUURRFRfRUUr";
                    break;
                case "Kite":
                    ollAlgorithm = "RUrurFRRUruf";
                    break;
                case "AntiKite":
                    ollAlgorithm = "RUrUrFRfRUUr";
                    break;
                //L-Shapes
                case "Breakneck":
                    ollAlgorithm = "FRUruRUruf";
                    break;
                case "AntiBreakneck":
                    ollAlgorithm = "rurFRfrFRfUR";
                    break;
                case "FryingPan":
                    ollAlgorithm = "yruRurURurUUYR";
                    break;
                case "AntiFryingPan":
                    ollAlgorithm = "YRUrURurURUUyr";
                    break;
                case "FrontSqueezy":
                    ollAlgorithm = "yrUYRYRuYRYRuYRYRUyr";
                    break;
                case "BackSqueezy":
                    ollAlgorithm = "YRuYRYRUYRYRUYRYRuYR";
                    break;
                //W-Shapes
                case "Mario":
                    ollAlgorithm = "RUrURururFRf";
                    break;
                case "Wario":
                    ollAlgorithm = "luLulULULflF";
                    break;
                //Lines
                case "Ant":
                    ollAlgorithm = "XFRUruRUruxf";
                    break;
                case "RiceCooker":
                    ollAlgorithm = "RUrURuBubr";
                    break;
                case "Streetlights":
                    ollAlgorithm = "YRUyrURurURurYRuyr";
                    break;
                case "Highway":
                    ollAlgorithm = "RUURRuRurUUFRf";
                    break;
                //Knight moves
                case "Squeegee":
                    ollAlgorithm = "yruYRruRUyrUYR";
                    break;
                case "AntiSqueegee":
                    ollAlgorithm = "YRUyrRUruYRuyr";
                    break;
                case "Gun":
                    ollAlgorithm = "FURuRRfRURur";
                    break;
                case "AntiGun":
                    ollAlgorithm = "rFRUrfRFuf";
                    break;
                //Akward Shapes
                case "Poodle":
                    ollAlgorithm = "RUrURUUrFRUruf";
                    break;
                case "AntiPoodle":
                    ollAlgorithm = "ruRurUURFRUruf";
                    break;
                case "WTF":
                    ollAlgorithm = "YRYRdYRUyrDYRYRuyruYR";
                    break;
                case "AntiWTF":
                    ollAlgorithm = "FURUUruRUUruf";
                    break;
                //Dot
                case "Blank":
                    ollAlgorithm = "RUURRFRfUUrFRf";
                    break;
                case "Zamboni":
                    ollAlgorithm = "FRUruXRUruxf";
                    break;
                case "Slash":
                    ollAlgorithm = "RUrUrFRfUUrFRf";
                    break;
                case "X":
                    ollAlgorithm = "yURUruYYURuyr";
                    break;
                case "Bunny":
                    ollAlgorithm = "yURUruYrFRf";
                    break;
                case "Crown":
                    ollAlgorithm = "YRUrURUUyryruRurUUYR";
                    break;
                case "AntiNazi":
                    ollAlgorithm = "XFRUruxfuFRUruf";
                    break;
                case "Nazi":
                    ollAlgorithm = "XFRUruxfUFRUruf";
                    break;
                default:
                    ollAlgorithm = "";
                    break;
            }
            Cube oldCube = new(cube);
            Program.performAlgorithm(ollAlgorithm, cube, 0, side);
            string newState = checkOLLState(cube).Substring(1);
            if (newState != "done")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error - OLL Not solved");
                Console.WriteLine($"Side: {side} State: {ollState} Algorithm: {ollAlgorithm}");
                Console.ForegroundColor = ConsoleColor.White;
                oldCube.Log();
                cube.Log();
                Console.ReadKey();
            }
        }

        public static void SolvePLL(Cube cube)
        {
            //PLL
            string pllState = checkPLLState(cube);
            int side = int.Parse(pllState.ElementAt(0).ToString());
            pllState = pllState.Substring(1);
            string pllAlgorithm;
            switch (pllState)
            {
                //Edges only
                case "Ub":
                    pllAlgorithm = "RRURUrururUr";
                    break;
                case "Ua":
                    pllAlgorithm = "RuRURURuruRR";
                    break;
                case "Z":
                    pllAlgorithm = "YYUYYUYUUYYUUY";
                    break;
                case "H":
                    pllAlgorithm = "YYUYYUUYYUYY";
                    break;
                //Corners only
                case "Aa":
                    pllAlgorithm = "rFrBBRfrBBRR";
                    break;
                case "Ab":
                    pllAlgorithm = "RRBBRFrBBRfR";
                    break;
                case "E":
                    pllAlgorithm = "RUrUruRfRUrurFRRuRRUR";
                    break;
                //Adjacent corners
                case "Ra":
                    pllAlgorithm = "RuruRURDruRdrUUr";
                    break;
                case "Rb":
                    pllAlgorithm = "rUURUUrFRUrurfRR";
                    break;
                case "Ja":
                    pllAlgorithm = "rUlUURurUURL";
                    break;
                case "Jb":
                    pllAlgorithm = "RUrfRUrurFRRur";
                    break;
                case "T":
                    pllAlgorithm = "RUrurFRRuruRUrf";
                    break;
                case "F":
                    pllAlgorithm = "rufRUrurFRRuruRUrUR";
                    break;
                //Diagonal Corners
                case "V":
                    pllAlgorithm = "rUrubrBBubUbRBR";
                    break;
                case "Y":
                    pllAlgorithm = "FRuruRUrfRUrurFRf";
                    break;
                case "Na":
                    pllAlgorithm = "RUrURUrfRUrurFRRurUURur";
                    break;
                case "Nb":
                    pllAlgorithm = "rURurfuFRUrFrfRuR";
                    break;
                //G Permutations
                case "Ga":
                    pllAlgorithm = "RRUrUruRuRRDurURd";
                    break;
                case "Gb":
                    pllAlgorithm = "fuFRRZUrURuRzuRR";
                    break;
                case "Gc":
                    pllAlgorithm = "RRuRuRUrURRdURurD";
                    break;
                case "Gd":
                    pllAlgorithm = "dRUruDRRuRurUrURR";
                    break;
                default:
                    pllAlgorithm = "";
                    break;
            }
            Cube oldCube = new(cube);
            Program.performAlgorithm(pllAlgorithm, cube, 0, side);
            string newState = checkPLLState(cube).Substring(1);
            if (newState != "done")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error - PLL Not solved");
                Console.WriteLine($"Side: {side} State: {pllState} Algorithm: {pllAlgorithm}");
                Console.ForegroundColor = ConsoleColor.White;
                oldCube.Log();
                cube.Log();
                Console.ReadKey();
            }
            //Last rotation
            while (cube.state[10] != cube.state[13])
            {
                cube.RotateClockWise(0);
            }
        }
        
        //Check state
        private static string checkOLLState(Cube cube)
        {
            //Corners
            int[] cornerStates = new int[4];
            for (int i = 1; i <= 4; i++)
            {
                int corner = i == 1 ? 0 : i == 2 ? 2 : i == 3 ? 6 : 8;
                if (cube.state[corner] == "w")
                {
                    cornerStates[i - 1] = 0;
                    continue;
                }
                int side1 = i == 1 ? 1 : i == 2 ? 4 : i == 3 ? 2 : 3;
                int side2 = i == 1 ? 4 : i == 2 ? 3 : i == 3 ? 1 : 2;
                if (cube.state[side1 * 9] == "w")
                {
                    cornerStates[i - 1] = side1;
                    continue;
                }
                else if (cube.state[side2 * 9 + 2] == "w")
                {
                    cornerStates[i - 1] = side2;
                    continue;
                }
            }
            for (int s = 1; s <= 4; s++)
            {
                //Edges
                string edgeCase;
                int left = ((s - 1) * 2 + 1);
                int right = ((s - 1) * 2 + 5) > 7 ? ((s - 1) * 2 + 5) - 8 : ((s - 1) * 2 + 5);
                int down = ((s - 1) * 2 + 3) > 7 ? ((s - 1) * 2 + 3) - 8 : ((s - 1) * 2 + 3);
                int up = ((s - 1) * 2 + 7) > 7 ? ((s - 1) * 2 + 7) - 8 : ((s - 1) * 2 + 7);
                left = left switch{5 => 7, 7 => 5, _ => left,};
                right = right switch { 5 => 7, 7 => 5, _ => right, };
                down = down switch { 5 => 7, 7 => 5, _ => down, };
                up = up switch { 5 => 7, 7 => 5, _ => up, };

                if (cube.state[up] == "w" && cube.state[down] == "w" && cube.state[right] == "w" && cube.state[left] == "w")
                {
                    //Full cross
                    edgeCase = "full";
                } else if (cube.state[up] == "w" && cube.state[down] == "w")
                {
                    //Vertical bar
                    edgeCase = "vbar";
                } else if (cube.state[left] == "w" && cube.state[right] == "w")
                {
                    //Horizontal bar
                    edgeCase = "hbar";
                } else if (cube.state[up] == "w" && cube.state[left] == "w")
                {
                    //Top left
                    edgeCase = "topleft";
                } else if (cube.state[up] == "w" && cube.state[right] == "w")
                {
                    //Top right
                    edgeCase = "topright";
                } else if (cube.state[down] == "w" && cube.state[left] == "w")
                {
                    //Bottom left
                    edgeCase = "bottomleft";
                } else if (cube.state[down] == "w" && cube.state[right] == "w")
                {
                    //Bottom right
                    edgeCase = "bottomright";
                } else
                {
                    edgeCase = "dot";
                }

                //Corners
                int[] corners = new int[4];
                corners[0] = cornerStates[s == 1 ? 1 : s == 2 ? 0 : s == 3 ? 2 : 3];
                corners[1] = cornerStates[s == 1 ? 3 : s == 2 ? 1 : s == 3 ? 0 : 2];
                corners[2] = cornerStates[s == 1 ? 0 : s == 2 ? 2 : s == 3 ? 3 : 1];
                corners[3] = cornerStates[s == 1 ? 2 : s == 2 ? 3 : s == 3 ? 1 : 0];

                //Find OLL state
                if (edgeCase == "full")
                {
                    if (corners[0] == 0 && corners[1] == 0 && corners[2] == 0 && corners[3] == 0) return s + "done";
                    else if (corners[0] == 0 && corners[1] == 0 && corners[2] == corners[3]) return s + "Headlights";
                    else if (corners[1] == 0 && corners[3] == 0 && corners[0] != corners[2]) return s + "Chameleon";
                    else if (corners[1] == 0 && corners[2] == 0 && corners[3] == s && corners[0] != 0) return s + "Bowtie";
                    else if (corners[2] == 0 && corners[3] == s && corners[0] != 0 && corners[1] != 0) return s + "Sune";
                    else if (corners[1] == 0 && corners[2] == s) return s + "AntiSune";
                    else if (corners[2] == corners[3] && corners[0] == corners[1] && corners[2] != 0 && corners[0] != 0) return s + "Cross";
                    else if (corners[0] == corners[2] && corners[3] == s && corners[0] != 0) return s + "Bruno";
                } else if(edgeCase == "hbar")
                {
                    if (corners[1] == 0 && corners[3] == 0 && corners[0] != 0 && corners[2] != 0)
                    {
                        //T-shapes
                        if (corners[2] == s) return s + "Key";
                        if (corners[0] == corners[2]) return s + "T";
                    }
                    else if (corners[0] == 0 && corners[1] == 0 && corners[2] == 0 && corners[3] == 0) return s + "H";
                    else if (corners[0] == 0 && corners[3] == 0 && corners[1] == (s == 1 ? 3 : s == 2 ? 4 : s == 3 ? 1 : 2)) return s + "BigLightning";
                    else if (corners[1] == 0 && corners[2] == 0 && corners[0] == (s == 1 ? 3 : s == 2 ? 4 : s == 3 ? 1 : 2)) return s + "LeftyBigLightning";
                    else if (corners[2] == 0 && corners[3] == s && corners[0] != 0 && corners[1] != 0) return s + "Gun";
                    else if (corners[3] == 0 && corners[2] == s && corners[0] != 0 && corners[1] != 0) return s + "AntiGun";
                    else if (corners[3] == 0 && corners[2] != s && corners[0] != 0 && corners[1] != 0 && corners[2] != 0) return s + "Squeegee";
                    else if (corners[1] == 0 && corners[2] == s && corners[0] != 0 && corners[3] != 0 && corners[2] != 0) return s + "AntiSqueegee";
                    else if (corners[0] == corners[2] && corners[3] == s && corners[1] != 0 && corners[0] != 0) return s + "Ant";
                    else if (corners[0] == corners[2] && corners[1] == corners[3] && corners[0] != 0 && corners[1] != 0) return s + "Streetlights";
                } else if (edgeCase == "vbar")
                {
                    //C
                    if (corners[0] == 0 && corners[2] == 0)
                    {
                        if (corners[3] == s && corners[1] != 0) return s + "City";
                        if (corners[1] == corners[3] && corners[1] != 0) return s + "SeeinHeadlights";
                    }
                    else if (corners[1] == corners[3] && corners[0] == corners[2] && corners[0] != 0 && corners[1] != 0) return s + "Highway";
                    else if (corners[1] == corners[3] && corners[2] == s && corners[0] != 0 && corners[1] != 0) return s + "RiceCooker";
                } else if (edgeCase == "topleft")
                {
                    if (corners[0] == 0 && corners[1] == 0 && corners[2] == 0 && corners[3] == 0) return s + "Arrow";
                    else if (corners[2] == 0 && corners[3] == s && corners[1] != 0 && corners[0] != 0) return s + "Lightning";
                    else if (corners[0] == 0 && corners[3] == 0 && corners[2] == s && corners[1] != 0) return s + "MountedFish";
                    else if (corners[0] != 0 && corners[3] == 0 && corners[2] == s && corners[1] != 0) return s + "Kite";
                    else if (corners[0] != 0 && corners[1] != 0 && corners[2] != 0 && corners[2] != s && corners[3] == s) return s + "Breakneck";
                    else if (corners[1] == 0 && corners[2] == 0 && corners[0] != 0 && corners[3] != 0 && corners[3] != s) return s + "Mario";
                    else if (corners[2] == 0 && corners[3] == 0 && corners[0] == corners[1] && corners[0] != 0) return s + "Poodle";
                    else if (corners[2] == 0 && corners[3] == 0 && corners[0] != corners[1] && corners[0] != 0) return s + "AntiWTF";
                } else if (edgeCase == "topright")
                {
                    if (corners[1] == 0 && corners[2] == s && corners[0] != 0 && corners[3] != 0 && corners[3] != s) return s + "RightySquare";
                    else if (corners[0] == 0 && corners[2] == s && corners[1] != 0 && corners[3] != 0 && corners[3] != s) return s + "Upstairs";
                    else if (corners[1] == 0 && corners[3] == 0 && corners[2] == s && corners[0] != 0) return s + "Couch";
                    else if (corners[0] == 0 && corners[3] == 0 && corners[1] != 0 && corners[2] != 0 && corners[2] != s) return s + "Wario";
                    else if (corners[2] == s && corners[1] == corners[3] && corners[0] != 0 && corners[1] != 0) return s + "AntiBreakneck";
                    else if (corners[1] == corners[3] && corners[0] == corners[2] && corners[0] != 0 && corners[1] != 0) return s + "AntiFryingPan";
                    else if (corners[0] == corners[2] && corners[3] == s && corners[0] != 0 && corners[1] != 0) return s + "BackSqueezy";
                } else if (edgeCase == "bottomleft")
                {
                    if (corners[0] == 0 && corners[2] == s && corners[3] != 0 && corners[3] != s && corners[3] != corners[1] && corners[1] != 0) return s + "ReverseLightning";
                    else if (corners[0] == 0 && corners[2] == 0 && corners[1] == corners[3] && corners[1] != 0) return s + "InverseP";
                    else if (corners[1] == 0 && corners[3] == s && corners[2] != 0 && corners[2] != s && corners[0] != 0) return s + "AntiKite";
                    else if (corners[0] == 0 && corners[1] == 0 && corners[2] == s && corners[3] == s) return s + "AntiPoodle";
                    else if (corners[0] == 0 && corners[1] == 0 && corners[2] != corners[3] && corners[3] != 0) return s + "WTF";
                } else if (edgeCase == "bottomright")
                {
                    if (corners[3] == 0 && corners[2] != 0 && corners[1] != 0 && corners[0] != 0 && corners[2] != corners[0] && corners[2] != s) return s + "LeftySquare";
                    else if (corners[2] == 0 && corners[3] == s && corners[1] != corners[3] && corners[1] != 0 && corners[0] != 0) return s + "Downstairs";
                    else if (corners[1] == 0 && corners[3] == 0 && corners[0] != 0 && corners[0] == corners[2]) return s + "P";
                    else if (corners[1] == 0 && corners[3] == 0 && corners[2] == s && corners[0] != 0) return s + "AntiCouch";
                    else if (corners[3] == 0 && corners[0] == 0 && corners[2] == s && corners[1] != 0) return s + "FishSalad";
                    else if (corners[0] == corners[2] && corners[0] != 0 && corners[1] == corners[3] && corners[1] != 0) return s + "FryingPan";
                    else if (corners[0] == corners[2] && corners[0] != 0 && corners[3] == s && corners[1] != 0) return s + "FrontSqueezy";
                } else if (edgeCase == "dot")
                {
                    if (corners[0] == 0 && corners[1] == 0 && corners[2] == 0 && corners[3] == 0) return s + "X";
                    else if (corners[0] == 0 && corners[3] == 0 && corners[2] != s) return s + "Slash";
                    else if (corners[0] == 0 && corners[1] == 0 && corners[2] == s && corners[3] == s) return s + "Crown";
                    else if (corners[0] == 0 && corners[1] == 0 && corners[2] != s && corners[3] != s) return s + "Bunny";
                    else if (corners[1] == 0 && corners[2] == s && corners[3] != 0 && corners[3] != s && corners[0] != 0) return s + "Nazi";
                    else if (corners[3] == 0 && corners[2] != s && corners[2] != 0 && corners[0] != 0 && corners[1] != 0) return s + "AntiNazi";
                    else if (corners[0] == corners[2] && corners[1] == corners[3] && corners[0] != 0 && corners[1] != 0) return s + "Blank";
                    else if (corners[0] == corners[2] && corners[3] == s && corners[1] != 0 && corners[0] != 0) return s + "Zamboni";
                }
            }
            return "1None";
        }

        private static string checkPLLState(Cube cube)
        {
            //Corners
            KeyValuePair<string, string>[] cornerStates = new KeyValuePair<string, string>[4];
            for (int i = 0; i < 4; i++)
            {
                int side1 = i == 0 ? 1 : i == 1 ? 4 : i == 2 ? 2 : 3;
                int side2 = i == 0 ? 4 : i == 1 ? 3 : i == 2 ? 1 : 2;
                string c1 = cube.state[side1 * 9];
                string c2 = cube.state[side2 * 9 + 2];
                cornerStates[i] = new KeyValuePair<string, string>(c1, c2);
            }
            //Edges
            string[] edgeStates = new string[4];
            for (int i = 0; i < 4; i++)
            {
                int side = i == 0 ? 4 : i == 1 ? 1 : i == 2 ? 3 : 2;
                edgeStates[i] = cube.state[side * 9 + 1];
            }

            //Find case and side
            for (int s = 1; s <= 4; s++)
            {
                //Corners
                KeyValuePair<string, string>[] corners = new KeyValuePair<string, string>[4];
                corners[0] = cornerStates[s == 1 ? 1 : s == 2 ? 0 : s == 3 ? 2 : 3];
                corners[1] = cornerStates[s == 1 ? 3 : s == 2 ? 1 : s == 3 ? 0 : 2];
                corners[2] = cornerStates[s == 1 ? 0 : s == 2 ? 2 : s == 3 ? 3 : 1];
                corners[3] = cornerStates[s == 1 ? 2 : s == 2 ? 3 : s == 3 ? 1 : 0];
                //Edges
                string[] edges = new string[4];
                edges[0] = edgeStates[s == 1 ? 2 : s == 2 ? 0 : s == 3 ? 1 : 3];
                edges[1] = edgeStates[s == 1 ? 0 : s == 2 ? 1 : s == 3 ? 3 : 2];
                edges[2] = edgeStates[s == 1 ? 3 : s == 2 ? 2 : s == 3 ? 0 : 1];
                edges[3] = edgeStates[s == 1 ? 1 : s == 2 ? 3 : s == 3 ? 2 : 0];

                //Find PLL state

                //Corners correct
                if (corners[0].Key == corners[2].Value && corners[1].Key == corners[0].Value && corners[2].Key == corners[3].Value && corners[3].Key == corners[1].Value)
                {
                    if (edges[0] == corners[0].Value)
                    {
                        if (edges[1] == corners[0].Key && edges[2] == corners[1].Value && edges[3] == corners[2].Key) return s + "done";
                        else if (edges[1] == corners[2].Key) return s + "Ua";
                        else if (edges[1] == corners[3].Key) return s + "Ub";
                    }
                    else if (edges[0] == corners[0].Key && edges[1] == corners[0].Value) return s + "Z";
                    else if (edges[0] == corners[2].Key && edges[3] == corners[0].Value) return s + "H";
                }
                //Edges correct
                else if (edges[0] == edges[3] switch{"b"=>"g","g"=>"b","r"=>"o","o"=>"r",_=>""} && edges[1] == edges[2] switch{"b"=>"g","g"=>"b","r"=>"o","o"=>"r",_=>""})
                {
                    if (corners[2].Key == edges[3] && corners[2].Value == edges[1])
                    {
                        if (corners[3].Value == edges[0]) return s + "Aa";
                        else if (corners[3].Value == edges[2]) return s + "Ab";
                    }
                    else if (corners[0].Value == corners[2].Key && corners[1].Key == corners[3].Value && corners[0].Value == edges[1]) return s + "E";
                }
                //Adjacent Corners
                if (corners[2].Key == edges[3])
                {
                    if (corners[0].Key == corners[2].Value && corners[0].Key == edges[0] && corners[1].Key == corners[3].Value) return s + "Ra";
                    else if (corners[0].Key == corners[1].Value && corners[0].Key == edges[1] && corners[3].Value == corners[2].Key) return s + "Ja";
                    else if (corners[1].Key == corners[3].Value && corners[0].Key == corners[2].Value && corners[0].Key == edges[2]) return s + "T";
                }
                else if (corners[2].Value == edges[1])
                {
                    if (corners[0].Key == corners[1].Value && corners[2].Key == corners[3].Value && corners[3].Value == edges[2] && corners[3].Key == edges[3]) return s + "Rb";
                    else if (corners[0].Key == edges[1] && corners[3].Value == edges[3] && corners[1].Key == edges[3]) return s + "Jb";
                    else if (corners[0].Key == edges[1] && corners[1].Key == corners[3].Value && corners[1].Key == edges[2] && corners[0].Value == edges[3]) return s + "F";
                }
                //Diagonal Corners
                if (corners[2].Key == edges[3]) {
                    if (corners[2].Value == edges[1] && corners[3].Value == corners[1].Key && corners[1].Key == edges[2] && corners[0].Key == edges[0]) return s + "V";
                    else if (corners[1].Value == edges[2] && corners[3].Value == corners[1].Key && corners[0].Key == corners[1].Value) return s + "Y";
                    else if (corners[0].Key == edges[1] && corners[0].Key == corners[1].Value && corners[0].Value == edges[3] && corners[1].Key == edges[0] && corners[3].Value == edges[0] && corners[3].Key == edges[2]) return s + "Nb";

                }
                else if (corners[0].Key == edges[2] && corners[1].Value == edges[2] && corners[0].Value == edges[0] && corners[2].Key == edges[0] && corners[2].Value == edges[1] && corners[3].Key == edges[1] && corners[3].Value == edges[3]) return s + "Na";
                //G Permutations
                if (corners[3].Value == edges[3])
                {
                    if (corners[0].Key == corners[2].Value && corners[3].Value == corners[1].Key && corners[3].Key == edges[1] && corners[2].Key == edges[0]) return s + "Ga";
                    else if (corners[2].Value == corners[3].Key && corners[0].Value == corners[1].Key && corners[0].Key == edges[3] && corners[0].Value == edges[2] && corners[2].Value == edges[0]) return s + "Gb";
                } else if (corners[0].Key == corners[2].Value && corners[1].Key == corners[3].Value)
                {
                    if (corners[1].Key == edges[0] && corners[0].Key == edges[2] && corners[3].Key == edges[3] && corners[2].Key == edges[1] && corners[1].Value == edges[1]) return s + "Gc";
                    else if (corners[3].Key == edges[2] && corners[0].Key == edges[3] && corners[2].Key == edges[0] && corners[0].Value == edges[2]) return s + "Gd";
                }
            }
            return "1Error";
        }
    }
}
