using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Counter_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Increment_Clicked(object sender, EventArgs e)
        {
            // Add 1 to the Counter
            Count.Text = Convert.ToString(Convert.ToInt32(Count.Text) + 1);

            // Check if the condition is met
            if (Convert.ToInt32(Count.Text) == Convert.ToInt32(Count_Limit.Text))
            {
                // Use default vibration length
                Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(4);

                // Vibrate the phone
                Vibration.Vibrate(duration);

                // Display the alert on popup screen
                await DisplayAlert("Alert", "You have reached the target!", "OK");
            }
        }
    }
}
