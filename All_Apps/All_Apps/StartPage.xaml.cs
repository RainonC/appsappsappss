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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Button Ent_btn = new Button
            {
                Text = "Entry page",
                BackgroundColor = Color.Azure
            };

            Button Time_btn = new Button
            {
                Text = "Timer page",
                BackgroundColor = Color.Azure
            };

            Button Fr_grid_btn = new Button
            {
                Text = "Frame Grid",
                BackgroundColor = Color.Azure
            };

            Button Img_btn = new Button
            {
                Text = "Image",
                BackgroundColor = Color.Azure
            };

            Button Valgusfoor_btn = new Button
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.Azure
            };

            Button Horo_btn = new Button
            {
                Text = "Horoskoop",
                BackgroundColor = Color.Azure
            };

            Button Brw_btn = new Button
            {
                Text = "Browser",
                BackgroundColor = Color.Azure
            };

            StackLayout st = new StackLayout
            {
                Children = { Ent_btn, Time_btn, Fr_grid_btn, Img_btn, Valgusfoor_btn, Horo_btn, Brw_btn },
                BackgroundColor = Color.Beige
            };
            Content = st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
            Fr_grid_btn.Clicked += Fr_grid_btn_Clicked;
            Img_btn.Clicked += Img_btn_Clicked;
            Valgusfoor_btn.Clicked += Valgusfoor_btn_Clicked;
            Horo_btn.Clicked += Horo_btn_Clicked;
            Brw_btn.Clicked += Brw_btn_Clicked;
        }

        private async void Brw_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpenBrowser());
        }

        private async void Horo_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Horoskoop());
        }

        private async void Valgusfoor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoor());
        }

        private async void Img_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage());
        }

        private async void Fr_grid_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrameGridPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }
    }



}