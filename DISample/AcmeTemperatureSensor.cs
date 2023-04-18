using Microsoft.Extensions.Options;

namespace DISample
{
    public class AcmeTemperatureSensor : ITemperatureSensor
{
    public string SerialNumber { get; }

    public AcmeTemperatureSensor(IOptions<TemperatureSensorOptions> options)
    {
        //SerialNumber = options.Value.SerialNumber;
    }

    public double GetTemperature()
    {
        return 25.0;
    }
}
}