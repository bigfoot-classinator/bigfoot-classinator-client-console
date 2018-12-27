public class SightingResponse
{
  public string sighting { get; set; }

  public Classination classination { get; set; }

  public override string ToString()
  {
    return $"{this.GetType().Name}: {this.sighting} <{this.classination.ToString()}>";
  }
}
