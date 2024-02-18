using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrameGridPage : ContentPage
    {
        Frame frame;
        Grid grid;
        Random rnd;
        Button button;
        Label label;



        public FrameGridPage()
        {
            rnd = new Random();
            grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Red

            };

            //for (int i = 0, i < 2, i++)
            //{
            //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            //    for (int j = 0, j < 3, j++)
            //    {
            //        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //    }
            //}
            for (int i = 0; i < 2; i++)
            {
                //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(i + 1, GridUnitType.Star) });

                for (int j = 0; j < 3; j++)
                {
                    //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.Children.Add(
                        button = new Button
                        {
                            Text = i.ToString()+j.ToString(),
                            CornerRadius = 10,
                            BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)),

                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,

                }, i, j);
                    button.Clicked += Button_Clicked;
                }
            }
            label = new Label { Text = "Tekst", BackgroundColor = Color.AliceBlue };

            grid.Children.Add(label, 0, 3);
            Grid.SetColumnSpan(label, 2);
            //StackLayout st = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand };
            //st.Children.Add(label);
            //st.Children.Add(grid);
            Content = grid;
        }

        // Объявите флаг вне метода, чтобы он был виден в разных вызовах
        private bool isButtonClicked = false;

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var r = Grid.GetRow(button);
            var c = Grid.GetColumn(button);

            if (isButtonClicked)
            {
                // Если кнопка уже была нажата, верните цвет из строчки
                button.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                isButtonClicked = false;
            }
            else
            {
                // Если кнопка не была нажата, установите цвет в красный
                button.BackgroundColor = Color.Red;
                isButtonClicked = true;
            }

            label.Text = r.ToString()+c.ToString();
        }

    }
}