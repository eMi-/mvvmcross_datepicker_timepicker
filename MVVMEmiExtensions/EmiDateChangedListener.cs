using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MVVMEmiExtensions
{
    public class EmiDateChangedListener : Java.Lang.Object, DatePicker.IOnDateChangedListener
    {
        private EmiDatePicker datePicker;

        public EmiDateChangedListener(EmiDatePicker datePicker)
        {
            this.datePicker = datePicker;
        }

        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            datePicker.InternalSetValueAndRaiseChanged(new DateTime(year, (monthOfYear + 1), dayOfMonth));
        }
    }
}
