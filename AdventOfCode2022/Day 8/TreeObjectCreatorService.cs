using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_8
{
    public class TreeObjectCreatorService
    {
        public static List<Tree> CreateTreeObjects(string[] treeHeights)
        {
            var trees = new List<Tree>();

            for (int i = 1; i < treeHeights.Length - 1; i++)
            {
                for (int y = 1; y < treeHeights[i].Length - 1; y++)
                {
                    var tree = new Tree()
                    {
                        TreeHeight = treeHeights[i][y] - '0',
                        Position = new Position()
                        {
                            I = i,
                            Y = y
                        }
                    };

                    trees.Add(tree);
                }
            }

            return trees;
        }
    }
}
