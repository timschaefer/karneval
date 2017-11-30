using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karneval
{
  public class ProgramItem
  {
    public ProgramItem(string name, string filePath)
    {
      Name = name;
      FilePath = filePath;
    }

    public string Name { get; set; }

    public string FilePath { get; set; }

    public string Info { get; set; }
  }
}
