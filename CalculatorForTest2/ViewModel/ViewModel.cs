using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculatorForTest2
{
    enum Operations
    {
        Add = 0,
        Subtract,
        Multipy,
        Divide,
        Equal,
        Modulo,
        Sqrt
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private decimal input;
        private decimal result;
        internal Operations? prevOperation;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand PlusCommand { get; private set; }


        public string Result
        {
            get => result.ToString(); 
            internal set
            {
                if (decimal.TryParse(value, out result))
                    NotifyPropertyChanged();
            }
        }

        public string Input
        {
            get => input.ToString();
            
            set
            {
                try
                {
                    input = decimal.Parse(value);
                }
                catch
                {
                    if (string.IsNullOrEmpty(value)) input = 0;
                    Input = $"{input:0}";
                }
                finally
                {
                    NotifyPropertyChanged();
                }
            }
        }
        public ViewModel()
        {
            Result = "0";
            Input = "0";
            prevOperation = null;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void PerformOperation(Operations? operations)
        {
            decimal par1 = input;
            decimal par2 = decimal.Parse(Result);
            switch (operations)
            {
                case Operations.Add:
                    Result = (par1 + par2).ToString();
                    break;
                case Operations.Subtract:
                    Result = $"{par2 - par1}";
                    break;
                case Operations.Multipy:
                    Result = $"{par2 * par1:0.00}";
                    break;
                case Operations.Divide:
                    if (par1 != 0) Result = $"{(decimal)par2 / par1:0.00}";
                    break;
                case Operations.Modulo:
                    if (par1 != 0) Result = ((long)(par2 % (long)par1)).ToString();
                    break;
                case Operations.Sqrt:
                    Result= $"{Math.Sqrt((double)par1):0.00}";
                    break;
                case Operations.Equal:
                    Result = $"{par1:0.00}" ;

                    break;
                default:
                    if (par1 != 0) Result = par1.ToString();
                    break;
            }
            Input = "0";
        }
    }

}
