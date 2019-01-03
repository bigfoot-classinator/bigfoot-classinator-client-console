using Newtonsoft.Json;

namespace BigfootClassinator
{
  public class ApplicationInfo
  {
    [JsonProperty(PropertyName = "app")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "version")]
    public string Version { get; set; }

    [JsonProperty(PropertyName = "attribution")]
    public string Attribution { get; set; }
  }
}
