using System;
using System.Collections.Generic;
using Supeng.Hr.RemotingService.Entities;
using Supeng.Hr.RemotingService.Services;

namespace Supeng.Hr.RemotingService
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var list = new List<ServiceInfo>(2)
      {
        new ServiceInfo(typeof (UpdateService), "UpdateService.esu"),
        new ServiceInfo(typeof (DocumentReportService), "DocumentReportService.esu")
      };
      var service = new RemotingService(1001);
      if (service.Regist(list))
        Console.Read();
      else
        throw new Exception("Service cannot start.");
    }
  }
}