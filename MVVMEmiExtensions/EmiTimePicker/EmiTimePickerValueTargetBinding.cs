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
    public class EmiTimePickerValueTargetBinding : MvxPropertyInfoTargetBinding<EmiTimePicker>
    {
        public EmiTimePickerValueTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var timePicker = View;
            if (timePicker == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - timePicker is null in EmiTimePickerValueTargetBinding");
            }
            else
            {
                timePicker.ValueChanged += TimePickerOnValueChanged; 
            }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        private void TimePickerOnValueChanged(object sender, EventArgs args)
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
                    datePicker.ValueChanged -= TimePickerOnValueChanged;
                }
            }
        }
    }
}