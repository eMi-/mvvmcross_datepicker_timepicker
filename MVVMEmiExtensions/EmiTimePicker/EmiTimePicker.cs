using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace MVVMEmiExtensions
{
    public class EmiTimePicker : TimePicker
    {
        public EmiTimePicker(Context context)
            : base(context)
        {

        }

        public EmiTimePicker(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {

        }

        private bool initialised = false;

        private void Init(TimeSpan timeSpan)
        {
            if (!initialised)
            {
                CurrentHour = new Integer(timeSpan.Hours);
                CurrentMinute = new Integer(timeSpan.Minutes);
                SetIs24HourView(Java.Lang.Boolean.True);
                SetOnTimeChangedListener(new EmiTimeChangedListener(this));
            }
        }

        public TimeSpan Value
        {
            get
            {
                int currentHour = CurrentHour.IntValue();
                int currentMinute = CurrentMinute.IntValue();
                return new TimeSpan(currentHour, currentMinute, 0);
            }
            set
            {
                Init(value);
                initialised = true;
            }
        }

        public event EventHandler ValueChanged;

        public void InternalSetValueAndRaiseChanged(TimeSpan timeSpan)
        {
            Value = timeSpan;
            EventHandler handler = ValueChanged;
            if (handler != null)
            {
                handler(this, null);
            }
        }
    }
}