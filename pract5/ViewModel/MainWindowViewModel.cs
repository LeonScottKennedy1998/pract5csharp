using pract5.View;
using pract5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pract5.ViewModel
{
    public class MainWindowViewModel : BindingHelper
    {
        public BindableCommand OpenNormalCalculatorCommand { get; set; }
        public BindableCommand OpenTrigCalculatorCommand { get; set; }

        public MainWindowViewModel()
        {
            OpenNormalCalculatorCommand = new BindableCommand(_ => OpenNormalCalculator());
            OpenTrigCalculatorCommand = new BindableCommand(_ => OpenTrigCalculator());
        }

        private void OpenNormalCalculator()
        {
            CalculatorViewModel calculatorViewModel = new CalculatorViewModel();
            CalculatorView calculatorView = new CalculatorView();
            calculatorView.DataContext = calculatorViewModel;
            calculatorView.Show();

        }

        private void OpenTrigCalculator()
        {
            TrigCalculatorViewModel trigcalcModel = new TrigCalculatorViewModel();
            TrigCalculatorView trigView = new TrigCalculatorView();
            trigView.DataContext = trigcalcModel;
            trigView.Show();
        }
    }
}
