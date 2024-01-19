using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    class Negative : EquationElement
    {
        public EquationElement Element;

        public Negative(EquationElement element, int fours) : base(ElementTypes.Negative, fours)
        {
            Element = element;
        }

        public override float Equate() => -Element.Equate();

        public override string Format() => $"(-{Element.Format()})";
    }
}
