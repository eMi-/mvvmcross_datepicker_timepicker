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

namespace MVVMEmiExtensions
{
    public class EmiDatePicker : DatePicker
    {
        public EmiDatePicker(Context context) : base(context)
        {

        }

        public EmiDatePicker(Context context, IAttributeSet attrs) : base(context, attrs)
        {

        }

        public DateTime Value
        {
            get
            {
                return new DateTime(Year, (Month + 1), DayOfMonth);
            }
            set
            {
                Init(value.Year, (value.Month - 1), value.Day, new EmiListener(this));
            }
        }

        public event EventHandler ValueChanged;

        public void InternalSetValueAndRaiseChanged(DateTime datetime)
        {
            Value = datetime;
            EventHandler handler = ValueChanged;
            if (handler != null)
            {
                handler(this, null);
            }
        }
    }
}
