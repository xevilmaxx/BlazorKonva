using System.Text.Json;

namespace BlazorKonva.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize(object Data)
        {
            return JsonSerializer.Serialize(Data, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }
    }
}
