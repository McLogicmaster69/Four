using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    class Subtraction : EquationElement
    {
        public EquationElement Element1;
        public EquationElement Element2;

        public Subtraction(EquationElement element1, EquationElement element2)
        {
            Element1 = element1;
            Element2 = element2;
        }

        public override float Equate() => Element1.Equate() - Element2.Equate();

        public override string Format() => $"({Element1.Format()} - {Element2.Format()})";
    }
}
