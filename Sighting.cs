using Newtonsoft.Json;

namespace BigfootClassinator
{
  public class Sighting
  {
    [JsonProperty(PropertyName = "sighting")]
    public string Text { get; set; }
  }
}
