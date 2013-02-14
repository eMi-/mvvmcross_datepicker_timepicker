using System;
using Android.Widget;

namespace MVVMEmiExtensions
{
    public class EmiTimeChangedListener : Java.Lang.Object, TimePicker.IOnTimeChangedListener
    {
        private EmiTimePicker timePicker;

        public EmiTimeChangedListener(EmiTimePicker timePicker)
        {
            this.timePicker = timePicker;
        }

        public void OnTimeChanged(TimePicker view, int hourOfDay, int minute)
        {
            timePicker.InternalSetValueAndRaiseChanged(new TimeSpan(hourOfDay, minute, 0));
        }
    }
}