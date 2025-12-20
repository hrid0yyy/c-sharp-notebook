abstract class Animal 
{
  public abstract void animalSound();
  public void sleep() 
  {
    Console.WriteLine("Zzz"); // Output: Zzz
  }
}

class Pig : Animal
{
  public override void animalSound()
  {
    // The body of animalSound() is provided here
    Console.WriteLine("The pig says: wee wee"); // Output: The pig says: wee wee
  }
   public new void sleep() 
  {
    Console.WriteLine("pig Zzz"); // Output: pig Zzz
  }
}