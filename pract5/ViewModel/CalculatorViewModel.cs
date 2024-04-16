using pract5.Model;
using pract5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace pract5.ViewModel
{
    internal class CalculatorViewModel : BindingHelper
    {
        private CalculatorModel _calculatorModel;

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();

            NumberCommand = new BindableCommand(number => ExecuteNumberCommand(number as string));
            OperationCommand = new BindableCommand(operation => ExecuteOperationCommand(operation as string));
            ClearCommand = new BindableCommand(_ => ExecuteClearCommand());
            CalculateCommand = new BindableCommand(_ => ExecuteCalculateCommand());
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

        public BindableCommand OperationCommand { get; }

        public BindableCommand ClearCommand { get; }

        public BindableCommand CalculateCommand { get; }

        private void ExecuteNumberCommand(string number)
        {
            if (Result == "0" || _isResultCalculated)
            {
                Result = number;
                _isResultCalculated = false;
            }
            else
            {
                Result += number;
            }
        }

        private void ExecuteOperationCommand(string operation)
        {
            if (double.TryParse(Result, out double result))
            {
                _leftOperand = result;
                _operation = operation;
                _isResultCalculated = true;
            }
        }

        private void ExecuteClearCommand()
        {
            Result = "0";
            _leftOperand = 0;
            _operation = null;
            _isResultCalculated = false;
        }

        private void ExecuteCalculateCommand()
        {
            if (_operation != null && double.TryParse(Result, out double rightOperand))
            {
                try
                {
                    double calculationResult = _calculatorModel.Calculate(_leftOperand, rightOperand, _operation);
                    Result = calculationResult.ToString();
                    _isResultCalculated = true;
                }
                catch (Exception ex)
                {
                    Result = "Error";
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private double _leftOperand;
        private string _operation;
        private bool _isResultCalculated;

    }
}
