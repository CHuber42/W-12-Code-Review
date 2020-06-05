using System.Collections.Generic;
namespace SweetSavory.Models
{
  public class Treat
  {
    public int TreatId {get; set;}
    public string Name {get; set;}

    public ICollection<FlavorTreat> FlavorTreats {get; set;}
    public Treat()
    {
      this.FlavorTreats = new HashSet<FlavorTreat>();
    }

  }
}