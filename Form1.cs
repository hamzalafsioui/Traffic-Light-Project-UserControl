using System;
using System.Windows.Forms;

namespace Traffic_Light_Project_Idea__Traffic_Light_User_Control_
{

    public partial class Form1 : Form
    {

        private bool isFirstTrafficLightGreen = true;
        
        public Form1()
        {
            InitializeComponent();
            InitializeTrafficLights();
        }

        private void InitializeTrafficLights()
        {
            ctrlTrafficLight1.RedLightOn += TrafficLight1_RedLightOn;
            ctrlTrafficLight1.OrangeLightOn += TrafficLight1_OrangeLightOn;
            ctrlTrafficLight1.GreenLightOn += TrafficLight1_GreenLightOn;
            ctrlTrafficLight1.DelayBeforeOrange = 3; // Set a delay of 3 seconds for the first traffic light

            ctrlTrafficLight2.RedLightOn += TrafficLight2_RedLightOn;
            ctrlTrafficLight2.OrangeLightOn += TrafficLight2_OrangeLightOn;
            ctrlTrafficLight2.GreenLightOn += TrafficLight2_GreenLightOn;
            ctrlTrafficLight2.DelayBeforeOrange = 5; // Set a delay of 5 seconds for the second traffic light
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrlTrafficLight1.Start();
            ctrlTrafficLight2.Start();
        }

        private void TrafficLight1_RedLightOn(object sender, ctrlTrafficLight.TrafficLightEventArgs e)
        {
            if (isFirstTrafficLightGreen)
            {
                ctrlTrafficLight1.RaiseRedLightOff(); // Turn off the red light for the first traffic light
                ctrlTrafficLight2.RaiseGreenLightOn(); // Turn on the green light for the second traffic light
            }
        }

        private void TrafficLight1_OrangeLightOn(object sender, ctrlTrafficLight.TrafficLightEventArgs e)
        {
            //MessageBox.Show("Traffic Light 1: " + e.CurrentLight.ToString());
        }

        private void TrafficLight1_GreenLightOn(object sender, ctrlTrafficLight.TrafficLightEventArgs e)
        {
            isFirstTrafficLightGreen = true;
            //MessageBox.Show("Traffic Light 1: " + e.CurrentLight.ToString());
        }

        private void TrafficLight2_RedLightOn(object sender, ctrlTrafficLight.TrafficLightEventArgs e)
        {
            if (!isFirstTrafficLightGreen)
            {
                ctrlTrafficLight2.RaiseRedLightOff(); // Turn off the red light for the second traffic light
                ctrlTrafficLight1.RaiseGreenLightOn(); // Turn on the green light for the first traffic light
            }
        }

        private void TrafficLight2_OrangeLightOn(object sender, ctrlTrafficLight.TrafficLightEventArgs e)
        {
            //MessageBox.Show("Traffic Light 2: " + e.CurrentLight.ToString());
        }

        private void TrafficLight2_GreenLightOn(object sender, ctrlTrafficLight.TrafficLightEventArgs e)
        {
            isFirstTrafficLightGreen = false;
            // MessageBox.Show("Traffic Light 2: " + e.CurrentLight.ToString());
        }
    }

}