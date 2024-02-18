using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        Frame fr;
        List<Color> colors = new List<Color> { Color.DarkRed, Color.Gold, Color.DarkGreen };
        Button btnSisse;
        Button btnValja;
        List<string> text = new List<string>() { "Sisse", "Välja" };
        List<string> reaktion = new List<string>() { "Seisa", "Oota", "Mine" };
        List<string> Colortext = new List<string>() { "Punane", "Kollane", "Roheline" };
        List<Frame> frames = new List<Frame>();
        StackLayout st = new StackLayout();
        StackLayout vf = new StackLayout();
        StackLayout nd = new StackLayout();

        bool isTrafficLightOn = false;

        public Valgusfoor()
        {
            vf.Margin = new Thickness(40);
            for (int i = 0; i < 3; i++)
            {
                fr = new Frame
                {
                    Content = new Label
                    {
                        Text = Colortext[i],
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    },
                    BindingContext = Colortext[i],
                    TabIndex = i,
                    BackgroundColor = Color.Gray,
                    CornerRadius = 90,
                    HeightRequest = 150,
                    BorderColor = Color.Black
                };
                frames.Add(fr);

                vf.Children.Add(fr);
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                fr.GestureRecognizers.Add(tap);
            }

            nd.Margin = new Thickness(10);
            nd.HorizontalOptions = LayoutOptions.Center;
            nd.Orientation = StackOrientation.Horizontal;

            btnSisse = new Button
            {
                Text = text[0], // "Sisse"
                BackgroundColor = Color.AntiqueWhite,
                TabIndex = 0,
            };
            btnSisse.Clicked += BtnSisse_Clicked;
            nd.Children.Add(btnSisse);

            btnValja = new Button
            {
                Text = text[1], // "Välja"
                BackgroundColor = Color.AntiqueWhite,
                TabIndex = 1,
            };
            btnValja.Clicked += BtnValja_Clicked;
            nd.Children.Add(btnValja);

            st.Children.Add(vf);
            st.Children.Add(nd);
            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (isTrafficLightOn)
            {

                Frame frame = sender as Frame;
                frame.Content = new Label
                {
                    Text = reaktion[frame.TabIndex],
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
            }
        }


        private void BtnSisse_Clicked(object sender, EventArgs e)
        {
            isTrafficLightOn = true;
            UpdateTrafficLight();
        }

        private void BtnValja_Clicked(object sender, EventArgs e)
        {
            isTrafficLightOn = false;
            for (int i = 0; i < 3; i++)
            {
                frames[i].Content = new Label { Text = "Pane kaima" };
            }

            UpdateTrafficLight();
        }

        private void UpdateTrafficLight()
        {
            for (int i = 0; i < 3; i++)
            {

                fr = (Frame)vf.Children[i];
                fr.BackgroundColor = isTrafficLightOn ? colors[i] : Color.Gray;
            }
        }
    }
}