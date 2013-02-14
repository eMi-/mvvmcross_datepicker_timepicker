using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Interfaces.Platform.Diagnostics;

namespace MVVMEmiExtensions
{
    public class EmiDatePickerValueTargetBinding : MvxPropertyInfoTargetBinding<EmiDatePicker>
    {
        public EmiDatePickerValueTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var datePicker = View;
            if (datePicker == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - datePicker is null in EmiDatePickerValueTargetBinding");
            }
            else
            {
                datePicker.ValueChanged += DatePickerOnValueChanged;
            }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        private void DatePickerOnValueChanged(object sender, EventArgs args)
        {
            FireValueChanged(View.Value);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var datePicker = View;
                if (datePicker != null)
                {
                    datePicker.ValueChanged -= DatePickerOnValueChanged;
                }
            }
        }
    }
}