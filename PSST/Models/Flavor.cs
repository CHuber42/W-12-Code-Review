using System.Collections.Generic;
namespace SweetSavory.Models
{
  public class Flavor
  {
    public int FlavorId {get; set;}
    public string Name {get; set;}

    public ICollection<FlavorTreat> FlavorTreat {get; set;}
    public Flavor()
    {
      this.FlavorTreat = new HashSet<FlavorTreat>();
    }

  }
}