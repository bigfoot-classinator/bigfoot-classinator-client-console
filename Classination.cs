using Newtonsoft.Json;

namespace BigfootClassinator
{
  public class Classination
  {
    [JsonProperty(PropertyName = "class_a")]
    public double ClassA { get; set; }

    [JsonProperty(PropertyName = "class_b")]
    public double ClassB { get; set; }

    [JsonProperty(PropertyName = "selected")]
    public string Selected { get; set; }
  }
}
