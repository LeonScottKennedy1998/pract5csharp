using pract5.Model;
using pract5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace pract5.ViewModel
{
    internal class TrigCalculatorViewModel : BindingHelper
    {

        private TrigCalculatorModel _TrigcalculatorModel;

        public TrigCalculatorViewModel()
        {
            _TrigcalculatorModel = new TrigCalculatorModel();

            NumberCommand = new BindableCommand(number => ExecuteNumberCommand(number as string));
            SinCommand = new BindableCommand(operand => ExecuteSinCommand(Convert.ToDouble(operand)));
            CosCommand = new BindableCommand(operand => ExecuteCosCommand(Convert.ToDouble(operand)));
            TanCommand = new BindableCommand(operand => ExecuteTanCommand(Convert.ToDouble(operand)));
            CtgCommand = new BindableCommand(operand => ExecuteCtgCommand(Convert.ToDouble(operand)));
            ArcSinCommand = new BindableCommand(operand => ExecuteArcSinCommand(Convert.ToDouble(operand)));
            ArcCosCommand = new BindableCommand(operand => ExecuteArcCosCommand(Convert.ToDouble(operand)));
            ArcTanCommand = new BindableCommand(operand => ExecuteArcTanCommand(Convert.ToDouble(operand)));
            ArcCtgCommand = new BindableCommand(operand => ExecuteArcCtgCommand(Convert.ToDouble(operand)));
            ClearCommand = new BindableCommand(operand => ExecuteClearCommand());
        }

        private string _result = "0";
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public BindableCommand NumberCommand { get; }
        public BindableCommand SinCommand { get; }
        public BindableCommand CosCommand { get; }
        public BindableCommand TanCommand { get; }
        public BindableCommand CtgCommand { get; }
        public BindableCommand ArcSinCommand { get; }
        public BindableCommand ArcCosCommand { get; }
        public BindableCommand ArcTanCommand { get; }
        public BindableCommand ArcCtgCommand { get; }
        public BindableCommand ClearCommand { get; }

        private void ExecuteNumberCommand(string number)
        {
            if (Result == "0")
            {
                Result = number;
            }
            else
            {
                Result += number; 
            }
        }

        private void ExecuteSinCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "sin");
                Result = result.ToString();
            }
        }
        private void ExecuteCosCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "cos");
                Result = result.ToString();
            }
        }
        private void ExecuteTanCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "tan");
                Result = result.ToString();
            }
        }
        private void ExecuteCtgCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "ctg");
                Result = result.ToString();
            }
        }
        private void ExecuteArcSinCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "arcsin");
                Result = result.ToString();
            }
        }
        private void ExecuteArcCosCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "arccos");
                Result = result.ToString();
            }
        }
        private void ExecuteArcTanCommand(double operand)
        {
            if (double.TryParse(Result, out operand))
            {
                double result = _TrigcalculatorModel.Calculate(operand, "arctan");
                Result = result.ToString();
            }
        }
        private void ExecuteArcCtgCommand(double operand)
        {
            if (double.TryParse(Result, out operand) && operand != 0)
            {
                double result = _TrigcalculatorModel.Calculate(operand, "arccot");
                Result = result.ToString();
            }
        }
        private void ExecuteClearCommand()
        {
            Result = "0";

        }
    }
}
