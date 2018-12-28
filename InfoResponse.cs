namespace BigfootClassinator
{
  public class InfoResponse
  {
    public string app { get; set; }
    public string version { get; set; }

    public override string ToString()
    {
      return $"{this.GetType().Name}: {this.app} {this.version}";
    }
  }
}
