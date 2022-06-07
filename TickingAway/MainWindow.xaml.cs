using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TickingAway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DateTime currentEventDate;
        private string currentEventName;
        private TimeSpan calcTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_newEvent_Click(object sender, RoutedEventArgs e)
        {
            // Display a pop-up window to create a new event to calculate the date for. 

            NewEventWindow popup = new NewEventWindow();

            popup.ShowDialog();

            

            // TODO: When the user has entered the event name and date on the popup window then closes the window with the top right X button, DO NOT DO THE CALCULATION OF THE EVENT. KEEP THE VALUES FROM THE PREVIOUSLY CALCULATED EVENT DATE!


            try
            {

                // grab the EventDate and EventName from the popup window
                currentEventDate = (DateTime)popup.datePicker_newEventDate.SelectedDate;
                currentEventName = popup.textBox_newEventName.Text;



                // calculate the timespan between the current time and the event time
                DateTime currTime = DateTime.Now;

                calcTime = currTime.Subtract(currentEventDate);


                // set the string values to display for the currently calculated event values. 
                label_calculatedTime.Content = $"Days: { Math.Abs(calcTime.Days)} Hours: { Math.Abs(calcTime.Hours)}";

                textBox_currentEventInfo.Text = $"Event Name: {currentEventName} Event Date: {currentEventDate.ToShortDateString()}";




                if (calcTime.Days <= 0)
                {
                    label_futurePast.Content = "In the Future";
                }
                else if (calcTime.Days > 0)
                {
                    label_futurePast.Content = "In the Past";
                }
            }
            catch (Exception goblin)
            {
                 Console.WriteLine(goblin.Message);

            }






        }
        
    }
}
