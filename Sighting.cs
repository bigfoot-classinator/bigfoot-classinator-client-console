using Newtonsoft.Json;

namespace BigfootClassinator
{
  public class Sighting
  {
    [JsonProperty(PropertyName = "latitude")]
    public double Latitude { get; set; }

    [JsonProperty(PropertyName = "longitude")]
    public string Longitude { get; set; }

    [JsonProperty(PropertyName = "sighting")]
    public string Text { get; set; }
  }
}
