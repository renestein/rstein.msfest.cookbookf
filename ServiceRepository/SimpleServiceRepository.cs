using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ServiceRepository
{
  public class SimpleServiceRepository : ISimpleServiceRepository
  {
    private readonly IDictionary<string, Object> m_namedServices;

    private readonly IDictionary<Type, Object> m_services;

    private bool m_isDisposed;

    protected SimpleServiceRepository()
    {
      m_services = new Dictionary<Type, object>();
      m_namedServices = new Dictionary<string, object>();
      m_isDisposed = false;
    }

    public static SimpleServiceRepository Instance
    {
      get
      {
        return SimpleServiceRepositoryCreator.Instance;
      }
    }

    public void RegisterService<R>(R implementor)
      where R : class
    {
      RegisterService(typeof (R), implementor);
    }

    public void RegisterService(Type serviceType, object implementor)
    {
      checkIfDisposed();
      if (serviceType == null)
      {
        throw new ArgumentNullException("serviceType");
      }
      if (implementor == null)
      {
        throw new ArgumentNullException("implementor");
      }

      m_services.Add(serviceType, implementor);
    }

    public R GetService<R>() where R : class
    {
      checkIfDisposed();
      return GetService(typeof (R)) as R;
    }

    public object GetService(Type interfaceType)
    {
      checkIfDisposed();
      checkInterfaceValid(interfaceType);
      object retValue;

      if (m_services.TryGetValue(interfaceType, out retValue))
      {
        return retValue;
      }

      return null;
    }

    public object RemoveNamedService(Type interfaceType, string name)
    {
      checkIfDisposed();
      if (name == null)
      {
        throw new ArgumentNullException("name");
      }
      checkInterfaceValid(interfaceType);
      object implementor = GetService(interfaceType, name);

      if (implementor != null)
      {
        m_namedServices.Remove(name);
      }
      return implementor;
    }

    public R RemoveNamedService<R>(string name) where R : class
    {
      checkIfDisposed();
      return (RemoveNamedService(typeof (R), name) as R);
    }

    public object RemoveService(Type interfaceType)
    {
      checkIfDisposed();
      checkInterfaceValid(interfaceType);
      object implementor = GetService(interfaceType);

      if (implementor != null)
      {
        m_services.Remove(interfaceType);
      }
      return implementor;
    }

    public R RemoveService<R>() where R : class
    {
      checkIfDisposed();
      return (RemoveService(typeof (R)) as R);
    }

    public object GetService(Type interfaceType, string name)
    {
      checkIfDisposed();
      checkInterfaceValid(interfaceType);


      if (String.IsNullOrEmpty(name))
      {
        return GetService(interfaceType);
      }

      object retValue;

      if (m_namedServices.TryGetValue(name, out retValue))
      {
        return retValue;
      }


      return null;
    }

    public R GetService<R>(string name) where R : class
    {
      checkIfDisposed();
      return GetService(typeof (R), name) as R;
    }

    public void RegisterNamedService<R>(string name, R implementor)
      where R : class
    {
      RegisterNamedService(name, typeof (R), implementor);
    }

    public void RegisterNamedService(string name, Type serviceType, object implementor)
    {
      checkIfDisposed();
      if (name == null)
      {
        throw new ArgumentNullException("name");
      }

      checkInterfaceValid(serviceType);

      if (implementor == null)
      {
        throw new ArgumentNullException("implementor");
      }

      m_namedServices.Add(name, implementor);
    }


    public void Dispose()
    {
      if (m_isDisposed)
      {
        return;
      }

      Dispose(true);
      GC.SuppressFinalize(this);
      m_isDisposed = true;
    }

    public void RemoveAllServices()
    {
      checkIfDisposed();
      //!!! Dispose !!!
      m_services.Clear();
      m_namedServices.Clear();
    }

    protected virtual void Dispose(bool disposing)
    {
      try
      {
        if (disposing)
        {
          m_services.Values
                    .Concat(m_namedServices.Values)
                    .OfType<IDisposable>()
                    .ToList()
                    .ForEach(service => service.Dispose());
        }
      }
      catch (Exception e)
      {
        Trace.WriteLine(e);
      }
    }

    private void checkInterfaceValid(Type interfaceType)
    {
      if (interfaceType == null)
      {
        throw new ArgumentNullException("interfaceType");
      }
    }

    private void checkIfDisposed()
    {
      if (m_isDisposed)
      {
        throw new ObjectDisposedException(GetType().Name);
      }
    }

    ~SimpleServiceRepository()
    {
      Dispose(false);
    }

    private static class SimpleServiceRepositoryCreator
    {
      public static SimpleServiceRepository Instance = new SimpleServiceRepository();
    }
  }
}