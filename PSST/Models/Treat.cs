using System.Collections.Generic;
namespace SweetSavory.Models
{
  public class Treat
  {
    public int TreatId {get; set;}
    public string Name {get; set;}

    public ICollection<FlavorTreat> FlavorTreat {get; set;}
    public Treat()
    {
      this.FlavorTreat = new HashSet<FlavorTreat>();
    }

  }
}