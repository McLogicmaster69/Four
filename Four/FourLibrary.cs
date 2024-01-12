using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    public class FourLibrary
    {
        public List<FourSolution> Solutions = new List<FourSolution>();

        public void AddEquation(FourEquation equation)
        {
            float value = equation.Equate();
            if (value % 1f == 0f)
                AddEquation(equation, (int)value);
        }

        private void AddEquation(FourEquation equation, int value)
        {
            Output(equation, value);

            if (Solutions.Count == 0)
            {
                FourSolution solution = new FourSolution();
                solution.Equations.Add(equation);
                solution.Value = value;
                Solutions.Add(solution);
                return;
            }

            int index = BinarySort(value);
            Solutions[index].Equations.Add(equation);
        }

        public void Output(FourEquation equation, int value)
        {
            Console.WriteLine($"A value of {value} has equation {equation.Format()}");
        }

        private int BinarySort(int value)
        {
            int lower = 0;
            int upper = Solutions.Count - 1;

            while(lower <= upper)
            {
                int middle = (lower + upper) / 2;
                if (Solutions[middle].Value == value)
                    return middle;
                else if (Solutions[middle].Value < value)
                    lower = middle + 1;
                else
                    upper = middle - 1;
            }

            if (lower >= Solutions.Count)
            {
                FourSolution solution = new FourSolution();
                solution.Value = value;
                Solutions.Add(solution);
                return Solutions.Count - 1;
            }

            if(upper < 0)
            {
                FourSolution solution = new FourSolution();
                solution.Value = value;
                Solutions.Insert(0, solution);
                return 0;
            }
            else
            {
                FourSolution solution = new FourSolution();
                solution.Value = value;
                Solutions.Insert(lower, solution);
                return lower;
            }
        }
    }
}
