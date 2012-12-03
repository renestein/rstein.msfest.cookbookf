using System;

namespace ServiceRepository
{
  public interface ISimpleServiceRepository : IDisposable
  {
    void RegisterService<R>(R implementor)
      where R : class;

    void RegisterService(Type serviceType, object implementor);

    R GetService<R>() where R : class;

    object GetService(Type interfaceType);

    R GetService<R>(string name) where R : class;

    object GetService(Type interfaceType, string name);

    object RemoveNamedService(Type interfaceType, string name);

    R RemoveNamedService<R>(string name) where R : class;

    object RemoveService(Type interfaceType);

    R RemoveService<R>() where R : class;

    void RegisterNamedService<R>(string name, R implementor)
      where R : class;

    void RegisterNamedService(string name, Type serviceType, object implementor);
  }
}