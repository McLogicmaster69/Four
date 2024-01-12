using Four.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    class Program
    {
        public static Operation[] SingleOperations = new Operation[] { };
        public static Operation[] MultipleOperations = new Operation[] { };

        static void Main(string[] args)
        {
            FourLibrary library = new FourLibrary();

            DoOperation(0, null, library, 0);
        }

        private static void DoOperation(int fours, EquationElement element, FourLibrary library, int depth)
        {
            if (fours > 4)
                return;
            if(fours == 4)
            {
                library.AddEquation(new FourEquation(element));
            }

            DoSingleElementOperation(fours, element, library, depth, new List<int>());
            DoMultipleElementOperation(fours, element, library, depth);
        }

        private static void DoSingleElementOperation(int fours, EquationElement element, FourLibrary library, int depth, List<int> singleOperationsDone)
        {
            for (int i = 0; i < SingleOperations.Length; i++)
            {
                EquationElement single = SingleOperations[i](fours, element, library, depth);
                List<int> newDone = new List<int>(singleOperationsDone);
                newDone.Add(i);
                DoSingleElementOperation(fours, single, library, depth, newDone);
                DoMultipleElementOperation(fours, single, library, depth);
            }
        }

        private static void DoMultipleElementOperation(int fours, EquationElement element, FourLibrary library, int depth)
        {
            foreach (Operation operation in MultipleOperations)
            {
                DoOperation(fours, operation(fours, element, library, depth), library, depth);
            }
        }

        public static List<EquationElement> GetNumbers(int fours, EquationElement element, FourLibrary library, int depth)
        {
            List<EquationElement> numbers = new List<EquationElement>();
            return numbers;
        }

        private static EquationElement Addition(int fours, EquationElement element, FourLibrary library, int depth)
        {

        }
    }

    public delegate EquationElement Operation(int fours, EquationElement element, FourLibrary library, int depth);
}
