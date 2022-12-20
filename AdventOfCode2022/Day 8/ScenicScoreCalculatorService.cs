using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_8
{
    public class ScenicScoreCalculatorService
    {
        public static int TreesVisibleLookingAtTheTop(string[] arr, Tree tree)
        {
            int counter = 0;
            int i = tree.Position.I - 1;

            while (arr[i][tree.Position.Y] - '0'  < tree.TreeHeight)
            {
                counter++;
                i--;

                if (i < 0)
                {
                    return counter;
                }
            }

            return ++counter;
        }

        public static int TreesVisibleLookingAtTheBottom(string[] arr, Tree tree)
        {
            int counter = 0;
            int i = tree.Position.I + 1;

            while (arr[i][tree.Position.Y] - '0' < tree.TreeHeight)
            {
                counter++;
                i++;

                if (i > arr.Length - 1)
                {
                    return counter;
                }
            }

            return ++counter;
        }

        public static int TreesVisibleLookingAtTheLeft(string[] arr, Tree tree)
        {
            int counter = 0;
            int i = tree.Position.Y - 1;

            while (arr[tree.Position.I][i] - '0' < tree.TreeHeight)
            {
                counter++;
                i--;

                if (i < 0)
                {
                    return counter;
                }
            }

            return ++counter;
        }

        public static int TreesVisibleLookingAtTheRight(string[] arr, Tree tree)
        {
            int counter = 0;
            int i = tree.Position.Y + 1;

            while (arr[tree.Position.I][i] - '0' < tree.TreeHeight)
            {
                counter++;
                i++;

                if (i > arr[tree.Position.I].Length - 1)
                {
                    return counter;
                }
            }

            return ++counter;
        }
    }
}
