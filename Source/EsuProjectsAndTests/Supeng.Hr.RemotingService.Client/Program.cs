using System;
using Supeng.Hr.RemotingService.Interfaces;

namespace Supeng.Hr.RemotingService.Client
{
  public class Program
  {
    private static void Main(string[] args)
    {
      var service =
       (IUpdate)Activator.GetObject(typeof(IUpdate), "tcp://localhost:1001/UpdateService.esu");
      var data = service.GetUpdateFiles("");
      Console.WriteLine(data);
      Console.Read();
    }
  }
}
