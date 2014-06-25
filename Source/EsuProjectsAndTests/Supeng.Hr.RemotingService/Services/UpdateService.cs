using System;
using Supeng.Hr.RemotingService.Interfaces;

namespace Supeng.Hr.RemotingService.Services
{
  public class UpdateService : MarshalByRefObject, IUpdate
  {
    public string GetUpdateFiles(string directoryName)
    {
      return "list";
    }

    public byte[] GetData(string fileName)
    {
      return new byte[0];
    }
  }
}
