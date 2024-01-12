using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    public class Number : EquationElement
    {
        public float Value = 0;

        public Number(float value)
        {
            Value = value;
        }

        public override float Equate() => Value;

        public override string Format() => $"({Value})";
    }
}
