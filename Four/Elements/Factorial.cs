using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    public class Factorial : EquationElement
    {
        public EquationElement Element;

        public Factorial(EquationElement element, int fours) : base(ElementTypes.Factorial, fours)
        {
            Element = element;
        }

        public override float Equate()
        {
            float value = Element.Equate();
            float total = 1f;
            while(value > 0)
            {
                total *= value;
                value--;
            }
            return total;
        }

        public override string Format() => $"{Element.Format()}!";
    }
}
