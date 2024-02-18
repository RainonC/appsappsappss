using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenBrowser : ContentPage
    {
        private Picker picker;
        private WebView webView;
        private StackLayout stackLayout;
        private Entry addressBar;
        private Button backButton;
        private Button nextButton;
        private Frame frame;
        private string[] urls = new string[] { "https://tahvel.edu.ee", "https://moodle.edu.ee/", "https://chat.openai.com/", "https://www.youtube.com/" };
        private int currentIndex = 0;

        public OpenBrowser()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            picker = new Picker
            {
                Title = "Web Pages"
            };

            foreach (var url in urls)
            {
                picker.Items.Add(url);
            }

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right | SwipeDirection.Left;

            frame = new Frame
            {
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,
                HeightRequest = 20,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true,
            };

            backButton = new Button
            {
                Text = "Back",
                Command = new Command(() => NavigateBack())
            };

            nextButton = new Button
            {
                Text = "Next",
                Command = new Command(() => NavigateNext())
            };

            addressBar = new Entry
            {
                Placeholder = "Enter URL",
                ReturnType = ReturnType.Go,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            addressBar.Completed += AddressBar_Completed;

            stackLayout = new StackLayout
            {
                Children = { picker, addressBar, backButton, nextButton }
            };

            Button addButton = new Button
            {
                Text = "Add Page",
                Command = new Command(async () => await OpenAddPagePopup())
            };

            stackLayout.Children.Add(addButton);

            frame.GestureRecognizers.Add(swipe);

            Content = stackLayout;
        }

        private void AddressBar_Completed(object sender, EventArgs e)
        {
            Navigate(addressBar.Text);
        }

        private void NavigateBack()
        {
            currentIndex = Math.Max(0, currentIndex - 1);
            picker.SelectedIndex = currentIndex;
            NavigateToPage(currentIndex);
        }

        private void NavigateNext()
        {
            currentIndex = Math.Min(urls.Length - 1, currentIndex + 1);
            picker.SelectedIndex = currentIndex;
            NavigateToPage(currentIndex);
        }

        private void Navigate(string url)
        {
            if (webView != null)
            {
                stackLayout.Children.Remove(webView);
            }

            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = url },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            stackLayout.Children.Add(webView);
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = urls[currentIndex] };

            currentIndex++;

            if (currentIndex == urls.Length)
            {
                currentIndex = 0;
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            NavigateToPage(picker.SelectedIndex);
        }

        private void NavigateToPage(int index)
        {
            if (webView != null)
            {
                stackLayout.Children.Remove(webView);
            }

            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = urls[index] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            stackLayout.Children.Add(webView);
        }

        private async Task OpenAddPagePopup()
        {
            string newPage = await InputPrompt("Add Page", "Enter URL:");

            if (!string.IsNullOrEmpty(newPage))
            {
                urls = urls.Concat(new[] { newPage }).ToArray();
                picker.Items.Add("New Page");
            }
        }

        private async Task<string> InputPrompt(string title, string message)
        {
            return await DisplayPromptAsync(title, message);
        }
    }
}