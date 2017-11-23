using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karneval
{
  public class ProgramItem
  {
    public ProgramItem(string title, string filePath)
    {
      Title = title;
      FilePath = filePath;
    }

    public string Title { get; set; }

    public string FilePath { get; set; }

    public string Info { get; set; }
  }
}
