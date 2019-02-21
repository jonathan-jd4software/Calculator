using Calculator.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    public class MainCalculatorViewModel : INotifyPropertyChanged
    {
        private enum MathFunc { Mf_None, Mf_Add, Mf_Subtract, Mf_Divide, Mf_Multiply};


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        #region Privates
        private bool _firstPressDone;
        private bool _decimalDone;
        private bool _clearOnFirstKey;
        private MathFunc _mathFunc;
        private string _firstEntry;
        #endregion


        #region Properties
        private string _calculatorEntry;
        public string CalculatorEntry
        {
            get { return _calculatorEntry; }
            set
            {
                _calculatorEntry = value;
                OnPropertyChanged("CalculatorEntry");
            }
        }
        #endregion


        #region Commands
        public ICommand PlusCommand => new Command(PlusMethod);
        public ICommand SubtractCommand => new Command(SubtractMethod);
        public ICommand MultiplyCommand => new Command(MultiplyMethod);
        public ICommand DivideCommand => new Command(DivideMethod);
        public ICommand DecimalCommand => new Command(DecimalMethod);
        public ICommand ClearCommand => new Command(ClearMethod);
        public ICommand EqualsCommand => new Command(EqualsMethod);
        public ICommand NumericEntryCommand => new Command<string>((str) => NumericEntryMethod(str));
        #endregion



        public void Init()
        {
            InitCalculatorEntry();

            _firstEntry = string.Empty;
            _mathFunc = MathFunc.Mf_None;
        }

        private void InitCalculatorEntry(bool clearOnFirstKey = false)
        {
            _clearOnFirstKey = clearOnFirstKey;
            if (!clearOnFirstKey)
            {
                CalculatorEntry = "0";
            }
            _firstPressDone = false;
            _decimalDone = false;
        }


        #region MethodsForCommands

        private void NumericEntryMethod(string entry)
        {
            if (!_firstPressDone)
            {
                if (_clearOnFirstKey)
                {
                    CalculatorEntry = "0";
                    _clearOnFirstKey = false;
                }
                if (entry != "0")
                {
                    _firstPressDone = true;
                }
                if (entry != ".")
                {
                    CalculatorEntry = string.Empty;
                }
            }
            CalculatorEntry = CalculatorEntry + entry;
        }



        private void PlusMethod()
        {
            if (_mathFunc == MathFunc.Mf_None)
            {
                _firstEntry = CalculatorEntry;
                InitCalculatorEntry(true);
                _mathFunc = MathFunc.Mf_Add;
            }
        }


        private void SubtractMethod()
        {
            if (_mathFunc == MathFunc.Mf_None)
            {
                _firstEntry = CalculatorEntry;
                InitCalculatorEntry(true);
                _mathFunc = MathFunc.Mf_Subtract;
            }

        }


        private void MultiplyMethod()
        {
            if (_mathFunc == MathFunc.Mf_None)
            {
                _firstEntry = CalculatorEntry;
                InitCalculatorEntry(true);
                _mathFunc = MathFunc.Mf_Multiply;
            }

        }


        private void DivideMethod()
        {
            if (_mathFunc == MathFunc.Mf_None)
            {
                _firstEntry = CalculatorEntry;
                InitCalculatorEntry(true);
                _mathFunc = MathFunc.Mf_Divide;
            }

        }

        private void DecimalMethod()
        {
            if (!_decimalDone)
            {
                NumericEntryMethod(".");
                _decimalDone = true;
            }
        }

        private void ClearMethod()
        {
            Init();
        }

        private void EqualsMethod()
        {
            if (_mathFunc != MathFunc.Mf_None)
            {
                var secondEntry = CalculatorEntry;
                
                if (_mathFunc == MathFunc.Mf_Divide && secondEntry == "0")
                {
                    CalculatorEntry = "Error";
                }
                else
                {
                    var first = Convert.ToDouble(_firstEntry);
                    var second = Convert.ToDouble(secondEntry);
                    double result = 0;

                    switch (_mathFunc)
                    {
                        case MathFunc.Mf_Add:
                            result = first + second;
                            break;
                        case MathFunc.Mf_Subtract:
                            result = first - second;
                            break;
                        case MathFunc.Mf_Multiply:
                            result = first * second;
                            break;
                        case MathFunc.Mf_Divide:
                            result = first / second;
                            break;
                    }

                    CalculatorEntry = result.Truncate(8).ToString();
                    InitCalculatorEntry(true);
                    _mathFunc = MathFunc.Mf_None;
                }

            }

        }
        #endregion
    }


}
