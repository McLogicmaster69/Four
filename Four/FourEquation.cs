using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Four
{
    public class FourEquation
    {
        public EquationElement Element;

        public FourEquation(EquationElement element)
        {
            Element = element;
        }

        public float Equate() => Element.Equate();

        public string Format() => Element.Format();
    }
}
