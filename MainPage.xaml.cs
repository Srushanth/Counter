using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Counter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DateTime dateTime_time_started = DateTime.Now;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void _count_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(Limit.Text) != Convert.ToInt32(_count.Content))
            {
                _count.Content = Convert.ToInt32(_count.Content) + 1;
                TextBlock_Time_Elapsed.Text = "Time Elapsed = " + (DateTime.Now - dateTime_time_started).ToString();
                TextBlock_Average_Time.Text = "Average Time = " + TimeSpan.FromSeconds(
                    (
                    (Convert.ToDateTime(TextBlock_Time_Elapsed.Text.Replace("Time Elapsed = ", "")).Hour*60*60) + 
                    (Convert.ToDateTime(TextBlock_Time_Elapsed.Text.Replace("Time Elapsed = ", "")).Minute*60) + 
                    (Convert.ToDateTime(TextBlock_Time_Elapsed.Text.Replace("Time Elapsed = ", "")).Second)
                    ) / Convert.ToInt32(_count.Content)).ToString();
                Random myObject = new Random();
                int min = 0;
                int max = 255;
                _bg_color.Color = Windows.UI.Color.FromArgb(255, (byte)myObject.Next(min, max), (byte)myObject.Next(min, max), (byte)myObject.Next(min, max));
                if (Convert.ToInt32(Limit.Text) == Convert.ToInt32(_count.Content))
                {
                    var dialog = new MessageDialog("Done!");
                    await dialog.ShowAsync();
                }
            }
        }
    }
}
