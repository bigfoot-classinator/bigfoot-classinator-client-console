public class Classination
{
  public double class_a { get; set; }

  public double class_b { get; set; }

  public double class_c { get; set; }

  public string selected { get; set; }

  public override string ToString()
  {
    return $"{this.GetType().Name}: ClassA {this.class_a}, ClassB {this.class_b}, ClassC {this.class_c}, Selected {this.selected}";
  }
}
