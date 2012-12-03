using System;

namespace RStein.Cookbook.Business.Core
{
  public class Amount : BusinessObjectBase
  {
    protected Amount() {}

    public Amount(Unit unit, double howMany)
    {
      if (unit == null)
      {
        throw new ArgumentNullException("unit");
      }
      Unit = unit;
      HowMany = howMany;
    }

    public Unit Unit
    {
      get;
      set;
    }

    public double HowMany
    {
      get;
      set;
    }
  }
}