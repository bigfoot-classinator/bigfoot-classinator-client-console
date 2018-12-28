namespace BigfootClassinator
{
  public class ClassinationRequest
  {
    public string sighting { get; set; }

    public override string ToString()
    {
      return $"{this.GetType().Name}: {this.sighting}";
    }
  }
}
