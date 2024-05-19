using System.Diagnostics.Metrics;

namespace DockerProject.WebApi.Diags
{
    public static class DiagnosticConfigs
    {
        public const string ServiceName = "PeopleApp";

        public static Meter Meter = new(ServiceName);

        public static Counter<int> RegistrationsCounter = Meter.CreateCounter<int>("registrations.count");
    }
}
