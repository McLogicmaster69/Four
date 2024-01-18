using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    class Pow : EquationElement
    {
        public EquationElement Element1;
        public EquationElement Element2;

        public Pow(EquationElement element1, EquationElement element2, int fours) : base(ElementTypes.Pow, fours)
        {
            Element1 = element1;
            Element2 = element2;
        }

        public override float Equate()
        {
            float value1 = Element1.Equate();
            float value2 = Element2.Equate();
            return (float)Math.Pow(value1, value2);
        }

        public override string Format() => $"({Element1.Format()} ^ {Element2.Format()})";
    }
}
