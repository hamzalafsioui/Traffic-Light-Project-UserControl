using System;
using System.Drawing;
using System.Windows.Forms;
using Traffic_Light_Project_Idea__Traffic_Light_User_Control_.Properties;

namespace Traffic_Light_Project_Idea__Traffic_Light_User_Control_
{
    public partial class ctrlTrafficLight : UserControl
    {
        public enum lightEnum { Red = 0, Orange = 1, Green = 2 }
        private lightEnum _CurrentLight = lightEnum.Red;

        private int _RedTime = 10;
        private int _OrangeTime = 3;
        private int _GreenTime = 5;

        private int _CurrentCountDownValue;


        public class TrafficLightEventArgs : EventArgs
        {
            public lightEnum CurrentLight { get; }
            public int LightDuration { get; }

            public TrafficLightEventArgs(lightEnum currentLight, int lightDuration)
            {
                this.CurrentLight = currentLight;
                this.LightDuration = lightDuration;
            }
        }

        // RedLightOn
        public event EventHandler<TrafficLightEventArgs> RedLightOn;
        public void RaiseRedLightOn()
        {
            RaiseRedLightOn(new TrafficLightEventArgs(lightEnum.Red, _RedTime));
        }

        protected void RaiseRedLightOn(TrafficLightEventArgs e)
        {
            RedLightOn?.Invoke(this, e);
        }
        // RedLightOff
        public event EventHandler<TrafficLightEventArgs> RedLightOff;
        public void RaiseRedLightOff()
        {
            RaiseRedLightOff(new TrafficLightEventArgs(lightEnum.Red, _RedTime));
        }

        protected void RaiseRedLightOff(TrafficLightEventArgs e)
        {
            RedLightOff?.Invoke(this, e);
        }

        // OrangeLightOn
        public event EventHandler<TrafficLightEventArgs> OrangeLightOn;
        public void RaiseOrangeLightOn()
        {
            RaiseOrangeLightOn(new TrafficLightEventArgs(lightEnum.Orange, _OrangeTime));
        }
        protected virtual void RaiseOrangeLightOn(TrafficLightEventArgs e)
        {
            OrangeLightOn?.Invoke(this, e);
        }
        // OrangeLightOff
        public event EventHandler<TrafficLightEventArgs> OrangeLightOff;
        public void RaiseOrangeLightOff()
        {
            RaiseOrangeLightOff(new TrafficLightEventArgs(lightEnum.Orange, _OrangeTime));
        }
        protected virtual void RaiseOrangeLightOff(TrafficLightEventArgs e)
        {
            OrangeLightOn?.Invoke(this, e);
        }

        // GreenLightOn
        public event EventHandler<TrafficLightEventArgs> GreenLightOn;
        public void RaiseGreenLightOn()
        {
            RaiseGreenLightOn(new TrafficLightEventArgs(lightEnum.Green, _GreenTime));
        }
        protected virtual void RaiseGreenLightOn(TrafficLightEventArgs e)
        {
            GreenLightOn?.Invoke(this, e);
        }
        // GreenLightOff
        public event EventHandler<TrafficLightEventArgs> GreenLightOff;
        public void RaiseGreenLightOff()
        {
            RaiseGreenLightOff(new TrafficLightEventArgs(lightEnum.Orange, _OrangeTime));
        }
        protected virtual void RaiseGreenLightOff(TrafficLightEventArgs e)
        {
            RedLightOn?.Invoke(this, e);
        }
        // Initial Logic 
        private int _DelayBeforeOrange = 3; // Default delay of 3 seconds

        public int DelayBeforeOrange
        {
            get { return _DelayBeforeOrange; }
            set { _DelayBeforeOrange = value; }
        }

        public lightEnum CurrentLight
        {
            get { return _CurrentLight; }
            set
            {
                _CurrentLight = value;
                switch (_CurrentLight)
                {
                    case lightEnum.Red:
                        pbTrafficLight.Image = Resources.Red;
                        lblCounter.ForeColor = Color.Red;
                        break;
                    case lightEnum.Orange:
                        pbTrafficLight.Image = Resources.Orange;
                        lblCounter.ForeColor = Color.Orange;
                        break;
                    case lightEnum.Green:
                        pbTrafficLight.Image = Resources.Green;
                        lblCounter.ForeColor = Color.Green;
                        break;

                    default:
                        lblCounter.ForeColor = Color.Red;
                        break;

                }
            }
        }

        public int RedTime
        {
            get { return _RedTime; }
            set
            {
                _RedTime = value;
            }
        }

        public int OrangeTime
        {
            get { return _OrangeTime; }
            set
            {
                _OrangeTime = value;
            }
        }

        public int GreenTime
        {
            get { return _GreenTime; }
            set
            {
                _GreenTime = value;
            }
        }

        public int GetCurrentTime()
        {
            switch (_CurrentLight)
            {
                case lightEnum.Orange:
                    return _OrangeTime;
                case lightEnum.Green:
                    return _GreenTime;
                case lightEnum.Red:
                    return _RedTime;

                default:
                    return _RedTime;
            }
        }

        public void Start()
        {
            _CurrentCountDownValue = GetCurrentTime();
            LightTimer.Start();
        }

        public void Stop()
        {
            LightTimer.Stop();
        }
        public ctrlTrafficLight()
        {
            InitializeComponent();
        }



        private void LightTimer_Tick(object sender, EventArgs e)
        {
            lblCounter.Text = _CurrentCountDownValue.ToString();
            if (_CurrentCountDownValue == 0)
            {
                _ChangeLight();
            }
            else
            {
                --_CurrentCountDownValue;
            }
        }

        private lightEnum _LightAfterOrangeGreenOrRed;

        private void _ChangeLight()
        {
            switch (_CurrentLight)
            {
                case lightEnum.Red:
                    _LightAfterOrangeGreenOrRed = lightEnum.Green;
                    CurrentLight = lightEnum.Orange;
                    _CurrentCountDownValue = OrangeTime;
                    lblCounter.Text = _CurrentCountDownValue.ToString();
                    RaiseOrangeLightOn();
                    RaiseRedLightOff();
                    break;

                case lightEnum.Orange:
                    if (_LightAfterOrangeGreenOrRed == lightEnum.Green)
                    {
                        CurrentLight = lightEnum.Green;
                        _CurrentCountDownValue = GreenTime;
                        lblCounter.Text = _CurrentCountDownValue.ToString();

                        RaiseGreenLightOn();
                        RaiseOrangeLightOff();

                    }
                    else
                    {
                        CurrentLight = lightEnum.Red;
                        _CurrentCountDownValue = RedTime;
                        lblCounter.Text = _CurrentCountDownValue.ToString();
                        RaiseRedLightOn();
                        RaiseOrangeLightOff();


                    }

                    break;

                case lightEnum.Green:
                    _LightAfterOrangeGreenOrRed = lightEnum.Red;

                    CurrentLight = lightEnum.Orange;
                    _CurrentCountDownValue = OrangeTime;
                    lblCounter.Text = _CurrentCountDownValue.ToString();
                    RaiseOrangeLightOn();
                    RaiseGreenLightOff();
                    break;

                default:
                    pbTrafficLight.Image = Resources.Red;
                    break;
            }
        }
    }
}
