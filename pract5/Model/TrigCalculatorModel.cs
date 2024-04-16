using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract5.Model
{
    internal class TrigCalculatorModel
    {
        public double Calculate(double operand, string operation)
        {
            switch (operation)
            {
                case "sin":
                    return Math.Sin(operand);
                case "cos":
                    return Math.Cos(operand);
                case "tan":
                    return Math.Tan(operand);
                case "ctg":
                    return 1.0 / Math.Tan(operand);
                case "arcsin":
                    if (operand >= -1 && operand <= 1)
                        return Math.Asin(operand);
                    else
                        return double.NaN;
                case "arccos":
                    if (operand >= -1 && operand <= 1)
                        return Math.Acos(operand);
                    else
                        return double.NaN;
                case "arctan":
                    return Math.Atan(operand);
                case "arccot":
                    if (operand != 0)
                        return Math.Atan(1.0 / operand);
                    else
                        return double.NaN;
                default:
                    return double.NaN;
            }
        }
    }
}
