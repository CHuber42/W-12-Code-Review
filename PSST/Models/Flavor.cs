using System.Collections.Generic;
namespace SweetSavory.Models
{
  public class Flavor
  {
    public int FlavorId {get; set;}
    public string Name {get; set;}

    public ICollection<FlavorTreat> FlavorTreats {get; set;}
    public Flavor()
    {
      this.FlavorTreats = new HashSet<FlavorTreat>();
    }

  }
}