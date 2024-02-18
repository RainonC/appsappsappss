using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Switch sw;
        Image img;
        public ImagePage()
        {
            img = new Image { Source = "bees.jpg" };
            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);


            sw = new Switch()
            {
                IsToggled = true,
                VerticalOptions= LayoutOptions.FillAndExpand,
                HorizontalOptions= LayoutOptions.Center,

            };
            sw.Toggled += Sw_Toggled;
            Content = new StackLayout { Children = { sw, img } };
        }
        int taps = 0;

        private void Tap_Tapped(object sender, EventArgs e)
        {
            taps++;
            Image img = (Image)sender;
            if (taps%2==0)
            {
                img.Source = "bees.jpg";
            }
            else
            {
                img.Source = "bee.png";
            }
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value) 
            {
                img.IsVisible = true;
            }
            else 
            {
                img.IsVisible = false;
            }
        }
    }
}