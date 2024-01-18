using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    class Root : EquationElement
    {
        public EquationElement Element;

        public Root(EquationElement element, int fours) : base(ElementTypes.Root, fours)
        {
            Element = element;
        }

        public override float Equate()
        {
            float value = Element.Equate();
            return (float)Math.Sqrt(value);
        }

        public override string Format() => $"ROOT({Element.Format()})";
    }
}
