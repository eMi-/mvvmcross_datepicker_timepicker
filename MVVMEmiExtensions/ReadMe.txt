1. 

Reference this Project (MVVMEmiExtensions) to the Project with the Resources Folder (where you want to use DatePicker & TimePicker)

2.

Add References to the Cirrious MVVMCross Libraries or Projects!

3. 

Add the following Code to your Setup.cs:

protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Interfaces.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
{
         registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(
                                       typeof(EmiDatePickerValueTargetBinding), typeof(EmiDatePicker), "Value"));
         registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(
                                       typeof(EmiTimePickerValueTargetBinding), typeof(EmiTimePicker), "Value"));
        base.FillTargetFactories(registry);
}


4. 

Add Properties in the ViewModel:

@TimePicker:

        private TimeSpan time = new TimeSpan(12, 00, 00);
        public TimeSpan Time
        {
               get
               {
                   return time;
               }
               set
               {
                   time = value; FirePropertyChanged(() => Time);
               }
        }

@DatePicker:
 
        private DateTime date = DateTime.Now;
        public DateTime Date
        {
               get
               {
                   return date;
               }
               set
               {
                   date = value; FirePropertyChanged(() => Date);
               }
        }


5. 

Add/Use & Bind DatePicker or TimePicker in your .axml

@TimePicker:

<MVVMEmiExtensions.EmiTimePicker
             android:layout_width="wrap_content"
             android:layout_height="wrap_content"
             local:MvxBind="{'Value':{'Path':'Time'}}"/>

@DatePicker:

<MVVMEmiExtensions.EmiDatePicker        
             android:layout_width="wrap_content"
             android:layout_height="wrap_content"
             local:MvxBind="{'Value':{'Path':'Date'}}"/>

6. 

Have Fun :)

