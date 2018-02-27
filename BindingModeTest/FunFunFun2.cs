using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingModeTest
{
    public class FunFunFun2 : TextBox
    {
        public static readonly DependencyProperty ValueDecimalProperty
          = DependencyProperty.RegisterAttached(nameof(ValueDecimal), typeof(decimal), typeof(FunFunFun2),
               new FrameworkPropertyMetadata(new PropertyChangedCallback(On_ValueDecimal_Changed))
               {
                   BindsTwoWayByDefault = true,
                   DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
               });

        private static void On_ValueDecimal_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FunFunFun2 maskedNumericInput = (FunFunFun2)d;
            maskedNumericInput.ValueDecimal = Convert.ToDecimal(e.NewValue);
        }

        public decimal? ValueDecimal
        {
            get
            {
                if (base.Text == null)
                    return null;

                return Convert.ToDecimal(GetValue(ValueDecimalProperty));
            }
            set
            {
                SetValue(ValueDecimalProperty, value);
                base.Text = value.ToString();
            }
        }


        public void InitBinding(string propertyName)
        {
            var binding = new Binding(propertyName) { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Mode = BindingMode.OneWay };
            SetBinding(ValueDecimalProperty, binding);
        }
    }
}
