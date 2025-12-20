class Car 
{
  public string color;
  public int speed;

  private string? model;
  public string? Model
    {
        get { return model; }
        set { model = value; }
    }


  public Car(string color)
  {
    this.color = color;

  }

  public Car(string color, int speed)
  {
    this.color = color;
    this.speed = speed;
  }

 
}

class f1 : Car
{
   public string team;
    public f1(string color, int speed, string team) : base(color, speed)
    {
        this.team = team;
    }
}