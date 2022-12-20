using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_8
{
    public class VisibilityChecker
    {
        public static bool IsVisibleFromTheTop(string[] arr, Tree tree)
        {
            for (int i = 0; i < tree.Position.I; i++)
            {
                if (arr[i][tree.Position.Y] - '0' >= tree.TreeHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsVisibleFromTheBottom(string[] arr, Tree tree)
        {
            for (int i = tree.Position.I + 1; i < arr.Length; i++)
            {
                if (arr[i][tree.Position.Y] - '0' >= tree.TreeHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsVisibleFromTheLeft(string[] arr, Tree tree)
        {
            for (int i = 0; i < tree.Position.Y; i++)
            {
                if (arr[tree.Position.I][i] - '0' >= tree.TreeHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsVisibleFromTheRight(string[] arr, Tree tree)
        {
            for (int i = tree.Position.Y + 1; i < arr[tree.Position.I].Length; i++)
            {
                if (arr[tree.Position.I][i] - '0' >= tree.TreeHeight)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
