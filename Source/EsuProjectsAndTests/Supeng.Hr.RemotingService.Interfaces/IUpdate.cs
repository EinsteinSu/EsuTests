namespace Supeng.Hr.RemotingService.Interfaces
{
  public interface IUpdate
  {
    /// <summary>
    ///   get all files in specified directory
    /// </summary>
    /// <param name="directoryName">directory in service</param>
    /// <returns>josn</returns>
    string GetUpdateFiles(string directoryName);

    /// <summary>
    /// get specified file binary
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    byte[] GetData(string fileName);
  }
}