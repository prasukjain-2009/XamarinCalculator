using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace CalculatorForTest2
{
    public partial class MainPage : ContentPage
    {
        ViewModel vc;
        public MainPage()
        {
            vc = new ViewModel();

            Resources.Add(StyleSheet.FromAssemblyResource(
            IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly,
            "CalculatorForTest2.Assets.Style.css"));
            BindingContext = vc;
            InitializeComponent();
        }


        void PlusClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(vc.prevOperation);
            vc.prevOperation = Operations.Add;
            EntryInput.Focus();
        }
        void MinusClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(vc.prevOperation);
            vc.prevOperation = Operations.Subtract;
            EntryInput.Focus();
        }
        void MultiplyClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(vc.prevOperation);
            vc.prevOperation = Operations.Multipy;
            EntryInput.Focus();
        }
        void DivideClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(vc.prevOperation);
            vc.prevOperation = Operations.Divide;
            EntryInput.Focus();
        }
        void ModuloClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(vc.prevOperation);
            vc.prevOperation = Operations.Modulo;
            EntryInput.Focus();
        }
        void SqrtClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(Operations.Sqrt);
            EntryInput.Focus();
        }


        void EqualClicked(object sender, System.EventArgs e)
        {
            vc.PerformOperation(vc.prevOperation);
            vc.prevOperation = null;
            EntryInput.Focus();
        }



        void ClearClicked(object sender, System.EventArgs e)
        {
            vc.Result = "0";
            vc.Input = "0";
            vc.prevOperation = null;
            EntryInput.Focus();
        }
    }
}
