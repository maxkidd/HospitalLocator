using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HospitalLocator.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init("O2YblsbApNsAguw3AXCt~C98O-Yu5gwlw9uKls22VBA~AtmVMBG0qWg5h-oMblzLDNgauY8Hx9zKpumgsTS3nbWtDLsqd-3XVKfM0X_3FqeD");
            LoadApplication(new HospitalLocator.App());
        }
    }
}
