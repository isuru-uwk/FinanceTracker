using System.Text.Json;

namespace FinanceTracker.Shared
{
    public static class JsonConfiguration
    {
        public static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}
