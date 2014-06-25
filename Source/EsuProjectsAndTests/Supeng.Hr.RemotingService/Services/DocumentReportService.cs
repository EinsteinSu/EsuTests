using System;
using Supeng.Hr.RemotingService.Interfaces;

namespace Supeng.Hr.RemotingService.Services
{
  public class DocumentReportService : MarshalByRefObject, IDocumentReport
  {
    public byte[] GetDocument(string projectId)
    {
      //implement create word document and return data
      return new byte[0];
    }
  }
}
