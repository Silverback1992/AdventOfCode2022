using AdventOfCode2022.Day_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_1
{
    public class CaloriesCalculator
    {
        private string[] _calories;

        public CaloriesCalculator(string[] calories)
        {
            _calories = calories;
        }

        public List<Elf> CalculateTotalCarriedCaloriesByElf()
        {
            var elves = new List<Elf>();
            int elfId = 1;
            int totalCalories = 0;

            for (int i = 0; i < _calories.Length; i++)
            {
                if (int.TryParse(_calories[i], out int calorie))
                {
                    totalCalories += calorie;
                }
                else
                {
                    elves.Add(new Elf()
                    {
                        ElfId = elfId,
                        TotalCarriedCalories = totalCalories
                    });

                    elfId++;
                    totalCalories = 0;
                }
            }

            return elves;
        }
    }
}
