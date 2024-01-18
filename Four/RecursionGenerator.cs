using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    /*
    public static class RecursionGenerator
    {
    
        public static Single[] SingleOperations = new Single[] { Factorial, Root };
        public static Operation[] MultipleOperations = new Operation[] { Addition, Subtraction, Multiplication, Division, Pow };
        public static Multiple[] MultipleGets = new Multiple[] { AdditionGet, SubtractionGet, MultiplicationGet, DivisionGet, PowGet };

        private static void DoOperation(int fours, EquationElement element, FourLibrary library)
        {
            if (fours > 4)
                return;
            if (fours == 4)
            {
                library.AddEquation(new FourEquation(element));
            }

            DoSingleElementOperation(fours, element, library);
            DoMultipleElementOperation(fours, element, library);
        }

        private static void DoSingleElementOperation(int fours, EquationElement element, FourLibrary library)
        {
            for (int i = 0; i < SingleOperations.Length; i++)
            {
                EquationElement single = SingleOperations[i](fours, element);
                if (single != null)
                {
                    DoSingleElementOperation(fours, single, library);
                    DoMultipleElementOperation(fours, single, library);
                }
            }
        }

        private static void DoMultipleElementOperation(int fours, EquationElement element, FourLibrary library)
        {
            foreach (Operation operation in MultipleOperations)
            {
                operation(fours, element, library);
            }
        }

        public static List<EquationElement> GetNumbers(int fours)
        {
            List<EquationElement> numbers = new List<EquationElement>();
            if (fours <= 3)
            {
                numbers.Add(new Number(4f, 1));
                numbers.Add(new Number(.4f, 1));
            }
            if (fours <= 2)
            {
                numbers.Add(new Number(44f, 2));
                numbers.Add(new Number(4.4f, 2));
                numbers.Add(new Number(.44f, 2));
            }
            if (fours <= 1)
            {
                numbers.Add(new Number(444f, 3));
                numbers.Add(new Number(44.4f, 3));
                numbers.Add(new Number(4.44f, 3));
                numbers.Add(new Number(.444f, 3));
            }
            if (fours <= 0)
            {
                numbers.Add(new Number(4444f, 4));
                numbers.Add(new Number(444.4f, 4));
                numbers.Add(new Number(44.44f, 4));
                numbers.Add(new Number(4.444f, 4));
                numbers.Add(new Number(.4444f, 4));
            }
            return numbers;
        }

        public static List<EquationElement> GetSecondEquationPart(int fours)
        {
            List<EquationElement> elements = new List<EquationElement>();
            elements.AddRange(GetNumbers(fours));
            foreach (Single operation in SingleOperations)
            {
                List<EquationElement> secondParts = GetSecondEquationPart(fours);
                foreach (EquationElement element in secondParts)
                {
                    EquationElement newElement = operation(fours, element);
                    if (newElement != null)
                        elements.Add(element);
                }
            }
            return elements;
        }

        #region Single

        private static EquationElement Factorial(int fours, EquationElement element)
        {
            float number = element.Equate();
            if (number % 1f != 0f)
                return null;
            if (number <= 2)
                return null;
            if (number >= 7)
                return null;
            return new Factorial(element, element.Fours);
        }

        private static EquationElement Root(int fours, EquationElement element)
        {
            if (element.Type == ElementTypes.Root)
                return null;
            return new Root(element, element.Fours);
        }

        #endregion

        #region Multiple

        private static void Addition(int fours, EquationElement element, FourLibrary library)
        {
            foreach (EquationElement equation in GetSecondEquationPart(fours))
            {
                DoOperation(fours + ((Number)equation).Fours, new Addition(element, equation, fours + ((Number)equation).Fours), library);
            }
        }

        private static void Subtraction(int fours, EquationElement element, FourLibrary library)
        {
            foreach (EquationElement equation in GetSecondEquationPart(fours))
            {
                DoOperation(fours + ((Number)equation).Fours, new Subtraction(element, equation, fours + ((Number)equation).Fours), library);
                DoOperation(fours + ((Number)equation).Fours, new Subtraction(equation, element, fours + ((Number)equation).Fours), library);
            }
        }

        private static void Multiplication(int fours, EquationElement element, FourLibrary library)
        {
            foreach (EquationElement equation in GetSecondEquationPart(fours))
            {
                DoOperation(fours + ((Number)equation).Fours, new Multiplication(element, equation, fours + ((Number)equation).Fours), library);
            }
        }

        private static void Division(int fours, EquationElement element, FourLibrary library)
        {
            foreach (EquationElement equation in GetSecondEquationPart(fours))
            {
                DoOperation(fours + ((Number)equation).Fours, new Division(element, equation, fours + ((Number)equation).Fours), library);
                DoOperation(fours + ((Number)equation).Fours, new Division(equation, element, fours + ((Number)equation).Fours), library);
            }
        }

        private static void Pow(int fours, EquationElement element, FourLibrary library)
        {
            foreach (EquationElement equation in GetSecondEquationPart(fours))
            {
                DoOperation(fours + ((Number)equation).Fours, new Pow(element, equation, fours + ((Number)equation).Fours), library);
                DoOperation(fours + ((Number)equation).Fours, new Pow(equation, element, fours + ((Number)equation).Fours), library);
            }
        }

        #endregion

        #region MultipleGet



        #endregion
    }
    public delegate void Operation(int fours, EquationElement element, FourLibrary library);
    */
}
