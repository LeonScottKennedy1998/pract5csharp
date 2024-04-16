using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract5.Model
{
    internal class CalculatorModel
    {
        public double Calculate(double leftOperand, double rightOperand, string operation)
        {
            switch (operation)
            {
                case "+":
                    return leftOperand + rightOperand;
                case "-":
                    return leftOperand - rightOperand;
                case "*":
                    return leftOperand * rightOperand;
                case "/":
                    if (rightOperand != 0)
                        return leftOperand / rightOperand;
                    else
                        return double.NaN;
                    break;
                default:
                    throw new ArgumentException("Операция не выполнена");
            }
            return 0;
        }
    }
}
