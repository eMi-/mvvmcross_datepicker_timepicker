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
    public class EmiListener : Java.Lang.Object, DatePicker.IOnDateChangedListener, TimePicker.IOnTimeChangedListener
    {
        private EmiDatePicker datePicker;
        private EmiTimePicker timePicker;

        public EmiListener(EmiDatePicker datePicker)
        {
            this.datePicker = datePicker;
        }

        public EmiListener(EmiTimePicker timePicker)
        {
            this.timePicker = timePicker;
        }

        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            datePicker.InternalSetValueAndRaiseChanged(new DateTime(year, (monthOfYear + 1), dayOfMonth));
        }

        public void OnTimeChanged(TimePicker view, int hourOfDay, int minute)
        {
            timePicker.InternalSetValueAndRaiseChanged(new TimeSpan(hourOfDay, minute, 0));
        }
    }
}
