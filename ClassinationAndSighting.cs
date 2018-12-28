using Newtonsoft.Json;

namespace BigfootClassinator
{
  public class ClassinationAndSighting
  {
    [JsonProperty(PropertyName = "sighting")]
    public string Sighting { get; set; }

    [JsonProperty(PropertyName = "classination")]
    public Classination Classination { get; set; }
  }
}
