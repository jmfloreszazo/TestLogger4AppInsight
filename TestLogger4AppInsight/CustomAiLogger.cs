using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace TestLogger4AppInsight;

public class CustomAiLogger : ICustomLogger
{
    private readonly TelemetryClient _client;

    public CustomAiLogger(TelemetryClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public void Dependency(string dependencyTypeName, string dependencyName, string data, DateTimeOffset startTime,
        TimeSpan duration, bool success)
    {
        _client.TrackDependency(dependencyTypeName, dependencyName, data, startTime, duration, success);
    }

    public void Error(string message, IDictionary<string, string> properties = null!)
    {
        _client.TrackTrace(message, SeverityLevel.Error, properties);
    }

    public void Event(string eventName, IDictionary<string, string> properties = null!,
        IDictionary<string, double> metrics = null!)
    {
        _client.TrackEvent(eventName, properties, metrics);
    }
    public void Exception(Exception exception, IDictionary<string, string> properties = null!)
    {
        _client.TrackException(exception, properties);
    }
    public void Information(string message, IDictionary<string, string> properties = null!)
    {
        _client.TrackTrace(message, SeverityLevel.Information, properties);
    }

    public void Metric(string name, long value, IDictionary<string, string> properties = null!)
    {
        _client.TrackMetric(name, value, properties);
    }

    public void Request(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
    {
        _client.TrackRequest(name, startTime, duration, responseCode, success);
    }

    public void Verbose(string message, IDictionary<string, string> properties = null!)
    {
        _client.TrackTrace(message, SeverityLevel.Verbose, properties);
    }
    public void Warning(string message, IDictionary<string, string> properties = null!)
    {
        _client.TrackTrace(message, SeverityLevel.Warning, properties);
    }

}