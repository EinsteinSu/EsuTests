using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskVisitWinFormControl.Tests
{
  public partial class Form1 : Form
  {
    private TaskScheduler scheduler;
    public Form1()
    {
      InitializeComponent();
      scheduler = TaskScheduler.FromCurrentSynchronizationContext();


    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      var parent = Task.Factory.StartNew(() =>
      {
        var ipEndPoint = new IPEndPoint(IPAddress.Broadcast, 7985);
        Byte[] bytes = Encoding.UTF8.GetBytes("quest:discover");
        using (var udpClient = new UdpClient())
        {
          udpClient.Send(bytes, bytes.Length, ipEndPoint);
          var datetime = DateTime.Now;
          var timeSpan = new TimeSpan(0, 0, 10);
          while ((DateTime.Now - datetime) <= timeSpan)
          {
            var receiveBytes = udpClient.Receive(ref ipEndPoint);
            var task = Task<string>.Factory.StartNew(() =>
            {
              string returnData = Encoding.UTF8.GetString(receiveBytes);
              if (!string.IsNullOrEmpty(returnData))
              {
                string[] splits = returnData.Split(new[] { ':' });
                if (splits.Length == 5)
                  return splits[2];
              }
              return string.Empty;
            });
            task.ContinueWith(t =>
            {
              if (!string.IsNullOrEmpty(t.Result))
              {
                comboBoxEdit1.Properties.Items.Add(t.Result);
              }
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
          }
        }
      });
      parent.ContinueWith((task) =>
      {
        MessageBox.Show(@"error has happened!");
      }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
    }

    private void comboBoxEdit1_Popup(object sender, EventArgs e)
    {

    }
  }
}
