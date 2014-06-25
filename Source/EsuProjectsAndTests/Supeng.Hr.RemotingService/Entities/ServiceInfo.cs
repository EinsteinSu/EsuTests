using System;
using System.Runtime.Remoting;

namespace Supeng.Hr.RemotingService.Entities
{
  internal class ServiceInfo
  {
    public ServiceInfo(Type type, string name, WellKnownObjectMode mode = WellKnownObjectMode.SingleCall)
    {
      Type = type;
      Name = name;
      Mode = mode;
    }

    public Type Type { get; set; }

    public string Name { get; set; }

    public WellKnownObjectMode Mode { get; set; }
  }
}