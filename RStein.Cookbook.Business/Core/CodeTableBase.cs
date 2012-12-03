using System;

namespace RStein.Cookbook.Business.Core
{
  public abstract class CodeTableBase : BusinessObjectBase
  {
    protected CodeTableBase()
    {
      Note = String.Empty;
    }

    protected CodeTableBase(string name)
      : this()
    {
      if (name == null)
      {
        throw new ArgumentNullException("name");
      }

      Name = name;
    }

    public virtual string Name
    {
      get;
      set;
    }

    public virtual string Note
    {
      get;
      set;
    }
  }
}