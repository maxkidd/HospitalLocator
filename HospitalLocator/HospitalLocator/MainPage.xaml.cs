using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HospitalLocator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Task.Delay(2000);
            UpdateMap();
        }


        List<Hospitals> placesList = new List<Hospitals>();

        private async void UpdateMap()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("HospitalLocator.Hospitals.json");
                string text = string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }

                var resultObject = JsonConvert.DeserializeObject<Rootobject>(text);

                foreach (var item in resultObject.results.bindings)
                {
                    placesList.Add(new Hospitals
                    {
                        Label = item.itemLabel.value,
                        Position = new Position(Convert.ToDouble(item.lat.value), Convert.ToDouble(item.lon.value)),
                        Link = item.item.value
                    });
                }

                HospitalMap.ItemsSource = placesList;
                //PlacesListView.ItemsSource = placesList;
                //var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                HospitalMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(53.479167, -2.244167), Distance.FromKilometers(10)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }

        private void Pin_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine((sender as Pin).Address);
            Browser.OpenAsync(new Uri((sender as Pin).Address), BrowserLaunchMode.SystemPreferred);
        }

        public async Task OpenBrowser(Uri uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}
