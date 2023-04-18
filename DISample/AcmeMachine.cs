namespace DISample
{
    public class AcmeMachine : IAcmeMachine
    {
        public AcmeMachine(ITemperatureSensor WaterSensor)
        {
            this.WaterSensor = WaterSensor;
            // How inject the temperature sensors?
        }

        ITemperatureSensor WaterSensor;
        ITemperatureSensor AirSensor;
    }
}