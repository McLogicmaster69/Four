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
        public static SingleDetails[] SingleOperations = new SingleDetails[]
        {
            new SingleDetails(Factorial, "factorial"),
            new SingleDetails(Root, "root")
        };
        public static MultipleDetails[] MultipleOperations = new MultipleDetails[] 
        { 
            new MultipleDetails(Addition, true, "addition"),
            new MultipleDetails(Subtraction, false, "subtraction"),
            new MultipleDetails(Multiplication, true, "multiple"),
            new MultipleDetails(Division, false, "division"),
            new MultipleDetails(Pow, false, "pow"),
        };

        private const int SINGLES = 1;

        private static List<EquationElement>[,] _calculated;

        static void Main(string[] args)
        {
            _calculated = new List<EquationElement>[4, SINGLES + 2];
            DateTime startTime = DateTime.Now;
            FourLibrary library = new FourLibrary();

            Generate(library);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Solutions");
            library.PrintSolutions();
            Console.WriteLine("");
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Time to complete: {endTime - startTime}");
            Console.ReadLine();
        }

        private static void Generate(FourLibrary library)
        {
            foreach(EquationElement element in GenerateEquationParts(4, 0))
            {
                if(element.Fours == 4)
                    library.AddEquation(new FourEquation(element));
            }
        }

        private static List<EquationElement> GenerateEquationParts(int fours, int singleOperations)
        {
            List<EquationElement> elements = new List<EquationElement>();

            string opener = "";
            for (int i = 0; i < 4 - fours; i++)
            {
                opener += "-";
            }
            Console.WriteLine($"{opener} Number of fours: {fours}");

            elements.AddRange(GetNumbers(fours));

            if(singleOperations < SINGLES)
            {
                foreach (SingleDetails operation in SingleOperations)
                {
                    List<EquationElement> secondParts;
                    if (_calculated[fours - 1, singleOperations] != null)
                    {
                        secondParts = _calculated[fours - 1, singleOperations + 1];
                    }
                    else
                    {
                        secondParts = GenerateEquationParts(fours, singleOperations + 1);
                        _calculated[fours - 1, singleOperations + 1] = secondParts;
                    }

                    foreach (EquationElement element in secondParts)
                    {
                        EquationElement newElement = operation.Method(fours, element);
                        if (newElement != null)
                        {
                            elements.Add(newElement);
                            Console.WriteLine($"{opener} {newElement.Format()}");
                        }
                    }

                    if (fours == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        for (int i = 0; i < 200; i++)
                        {
                            Console.WriteLine($"Completed the operation {operation.Name}");
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }

            if(fours >= 2)
            {
                foreach (MultipleDetails operation in MultipleOperations)
                {
                    int totalFours = operation.Commutitive ? fours / 2 + 1 : fours;
                    for (int dedicatedFours = 1; dedicatedFours < totalFours; dedicatedFours++)
                    {
                        List<EquationElement> firstEquations;
                        if (_calculated[dedicatedFours - 1, singleOperations] != null)
                        {
                            firstEquations = _calculated[dedicatedFours - 1, singleOperations];
                        }
                        else
                        {
                            firstEquations = GenerateEquationParts(dedicatedFours, singleOperations);
                            _calculated[dedicatedFours - 1, singleOperations] = firstEquations;
                        }
                        foreach (EquationElement firstElement in firstEquations)
                        {
                            List<EquationElement> secondEquations;
                            if (_calculated[fours - dedicatedFours - 1, singleOperations] != null)
                            {
                                secondEquations = _calculated[fours - dedicatedFours - 1, singleOperations];
                            }
                            else
                            {
                                secondEquations = GenerateEquationParts(fours - dedicatedFours, singleOperations);
                                _calculated[fours - dedicatedFours - 1, singleOperations] = secondEquations;
                            }
                            foreach (EquationElement secondElement in secondEquations)
                            {
                                EquationElement newElement = operation.Method(fours, firstElement, secondElement);
                                if (newElement != null)
                                {
                                    elements.Add(newElement);
                                    Console.WriteLine($"{opener} {newElement.Format()}");
                                }

                                /*
                                if (!operation.Commutitive)
                                {
                                    EquationElement secondNewElement = operation.Method(fours, secondElement, firstElement);
                                    if (secondNewElement != null)
                                    {
                                        elements.Add(secondNewElement);
                                        Console.WriteLine($"{opener} {secondNewElement.Format()}");
                                    }
                                }
                                */
                            }
                        }
                    }

                    if (fours == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        for (int i = 0; i < 200; i++)
                        {
                            Console.WriteLine($"Completed the operation {operation.Name}");
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }

            return elements;
        }

        public static List<EquationElement> GetNumbers(int fours)
        {
            List<EquationElement> numbers = new List<EquationElement>();
            if (fours == 1)
            {
                numbers.Add(new Number(4f, 1));
                numbers.Add(new Number(.4f, 1));
            }
            if (fours == 2)
            {
                numbers.Add(new Number(44f, 2));
                numbers.Add(new Number(4.4f, 2));
                numbers.Add(new Number(.44f, 2));
                numbers.Add(new Number(4f / 9f, 2));
            }
            if (fours == 3)
            {
                numbers.Add(new Number(444f, 3));
                numbers.Add(new Number(44.4f, 3));
                numbers.Add(new Number(4.44f, 3));
                numbers.Add(new Number(.444f, 3));
            }
            if (fours == 4)
            {
                numbers.Add(new Number(4444f, 4));
                numbers.Add(new Number(444.4f, 4));
                numbers.Add(new Number(44.44f, 4));
                numbers.Add(new Number(4.444f, 4));
                numbers.Add(new Number(.4444f, 4));
            }
            return numbers;
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
            if (element.Equate() <= 0)
                return null;
            if (element.Equate() == 1)
                return null;
            return new Root(element, element.Fours);
        }

        #endregion

        #region Multiple

        private static EquationElement Addition(int fours, EquationElement element1, EquationElement element2) 
            => new Addition(element1, element2, element1.Fours + element2.Fours);
        private static EquationElement Subtraction(int fours, EquationElement element1, EquationElement element2) 
            => new Subtraction(element1, element2, element1.Fours + element2.Fours);
        private static EquationElement Multiplication(int fours, EquationElement element1, EquationElement element2) 
            => new Multiplication(element1, element2, element1.Fours + element2.Fours);
        private static EquationElement Division(int fours, EquationElement element1, EquationElement element2) 
            => new Division(element1, element2, element1.Fours + element2.Fours);
        private static EquationElement Pow(int fours, EquationElement element1, EquationElement element2)
        {
            if (element1.Equate() == 0)
                return null;
            if (element1.Equate() == 1)
                return null;
            if (element2.Equate() == 1)
                return null;
            if (element1.Equate() > 16)
                return null;
            if (element2.Equate() > 8)
                return null;
            return new Pow(element1, element2, element1.Fours + element2.Fours);
        }

        #endregion
    }

    public delegate EquationElement Multiple(int fours, EquationElement element1, EquationElement element2);
    public delegate EquationElement Single(int fours, EquationElement element);
}
