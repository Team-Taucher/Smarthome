using Windows.Devices.Gpio;

namespace Gelp.SmartHome.Communication.Raspberry
{
    public class RaspberryConnector
    {
        /// <summary>
        /// Gpio Controller for accessing Raspberry's GPIO pins
        /// </summary>
        private readonly GpioController _gpioController;

        public RaspberryConnector()
        {
            _gpioController = GpioController.GetDefault();
        }
        
        /// <summary>
        /// Give voltage to pin
        /// </summary>
        /// <param name="pinToOpen">The pin to open</param>
        public void SetHigh(int pinToOpen)
        {
            // Open the GPIO pin for usage
            using (GpioPin pin = _gpioController.OpenPin(pinToOpen))
            {
                pin.Write(GpioPinValue.High);
            }   
        }
        
        /// <summary>
        /// Remove voltage from pin
        /// </summary>
        /// <param name="pinToOpen"></param>
        public void SetLow(int pinToOpen)
        {
            using (GpioPin pin = _gpioController.OpenPin(pinToOpen))
            {
                pin.Write(GpioPinValue.Low);
            }
        }
    }
}