using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver
{
    //Beginners method
    internal class Method1
    {
    public static void SolveOLL(Cube cube)
    {
    //OLL - Cross
    int correctEdges = ollCheckCross(cube);
    while (correctEdges != 4)
    {
        Program.performAlgorithm("FRUruf", cube, 0, 2);
        correctEdges = ollCheckCross(cube);
        if(cube.state[3] != "w" || cube.state[5] != "w")
        {
            cube.RotateClockWise(0); //U
        }
    }
    int ollCheckCross(Cube cube)
    {
        int correct = 0;
        if (cube.state[1] == "w") correct += 1;
        if (cube.state[3] == "w") correct += 1;
        if (cube.state[5] == "w") correct += 1;
        if (cube.state[7] == "w") correct += 1;
        return correct;
    }
        //OLL - Corners
        int correctCorners = ollCheckCorners(cube);
        int tries = 0;
        while (correctCorners != 4)
        {
            if(correctCorners == 1)
            {
                while(cube.state[0] != "w")
                {
                    cube.RotateClockWise(0);
                }
                if (cube.state[11] == "w")
                {
                    Program.performAlgorithm("RUrURUUr", cube, 0, 1);
                } else if(cube.state[36] == "w")
                {
                    Program.performAlgorithm("luLulUUL", cube, 0, 4);
                }
            } else
            {
                if (tries >= 4) { 
                    cube.RotateClockWise(0);
                    tries = 0;
                }
                Program.performAlgorithm("RUrURUUr", cube, 0, 2);
            }
            correctCorners = ollCheckCorners(cube);
            tries++;
        }
        int ollCheckCorners(Cube cube)
        {
            int correctCorners = 0;
            if (cube.state[0] == "w") correctCorners += 1;
            if (cube.state[2] == "w") correctCorners += 1;
            if (cube.state[6] == "w") correctCorners += 1;
            if (cube.state[8] == "w") correctCorners += 1;
            return correctCorners;
        }
    }

    public static void SolvePLL(Cube cube)
    {
        //PLL - Corners
        int correctSideCorners = checkPLLCorners();
        while (correctSideCorners != 4)
        {
            bool cornerComplete = false;
            for (int s = 1; s <= 4; s++)
            {
                int start = s * 9;
                if (cube.state[start] == cube.state[start + 2])
                {
                    Program.performAlgorithm("RbRFFrBRFFRR", cube, 0, s);
                    cornerComplete = true;
                    break;
                }
            }
            if (!cornerComplete)
            {
                Program.performAlgorithm("RbRFFrBRFFRR", cube, 0, 2);
            }
            correctSideCorners = checkPLLCorners();
        }
        int checkPLLCorners()
        {
            int correct = 0;
            for (int s = 1; s <= 4; s++)
            {
                int start = s * 9;
                if (cube.state[start] == cube.state[start + 2])
                {
                    correct += 1;
                }
            }
            return correct;
        }

        //PLL - Edges
        int correctPllEdges = checkPLLEdges();
        while (correctPllEdges != 4)
        {
            bool edgesComplete = false;
            for (int s = 1; s <= 4; s++)
            {
                int start = s * 9;
                if (cube.state[start + 1] == cube.state[start])
                {
                    int reverse = s == 1 ? 3 : s == 3 ? 1 : s == 2 ? 4 : 2;
                    Program.performAlgorithm("FFurLFFRluFF", cube, 0, reverse);
                    edgesComplete = true;
                    break;
                }
            }
            if (!edgesComplete)
            {
                Program.performAlgorithm("FFurLFFRluFF", cube, 0, 2);
            }
            correctPllEdges = checkPLLEdges();
        }
        int checkPLLEdges()
        {
            int correct = 0;
            for (int s = 1; s <= 4; s++)
            {
                int start = s * 9;
                if (cube.state[start + 1] == cube.state[start])
                {
                    correct += 1;
                }
            }
            return correct;
        }

        //Last rotation
        while (cube.state[10] != cube.state[13])
        {
            cube.RotateClockWise(0);
        }
    }
    }
}
