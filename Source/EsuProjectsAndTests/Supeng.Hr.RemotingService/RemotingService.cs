using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Supeng.Hr.RemotingService.Entities;

namespace Supeng.Hr.RemotingService
{
  internal class RemotingService
  {
    private readonly int channel;

    public RemotingService(int channel)
    {
      this.channel = channel;
    }

    public bool Regist(IList<ServiceInfo> serviceList = null)
    {
      try
      {
        var serverChannel = new TcpServerChannel(channel);
        ChannelServices.RegisterChannel(serverChannel, false);
        if (serviceList != null)
        {
          foreach (ServiceInfo serviceInfo in serviceList)
          {
            RemotingConfiguration.RegisterWellKnownServiceType(serviceInfo.Type, serviceInfo.Name, serviceInfo.Mode);
            Console.WriteLine("Service {0} has been started.", serviceInfo.Name);
          }
        }
        Console.WriteLine("Channel Name:{0}", serverChannel.ChannelName);
        Console.WriteLine("Channel Priority:{0}", serverChannel.ChannelPriority);

        var data = (ChannelDataStore)serverChannel.ChannelData;
        foreach (string channelUri in data.ChannelUris)
        {
          Console.WriteLine("Uri:{0}", channelUri);
        }
        Console.WriteLine("Start listening");
        return true;
      }
      catch
      {
        Console.WriteLine("Service channel has not regist.");
        return false;
      }
    }
  }
}