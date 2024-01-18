using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    public abstract class EquationElement
    {
        public ElementTypes Type;
        public int Fours;

        public EquationElement(ElementTypes type, int fours)
        {
            Type = type;
            Fours = fours;
        }

        public abstract float Equate();

        public abstract string Format();
    }

    public enum ElementTypes
    {
        Number,
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Factorial,
        Root,
        Pow
    }
}
