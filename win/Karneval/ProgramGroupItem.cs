using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karneval
{
  public class ProgramGroupItem
  {
    public string Title { get; set; }

    public string Info { get; set; }

    public bool Auto { get; set; }

    private List<ProgramItem> programItems;

    public List<ProgramItem> ProgramItems
    {
      get
      {
        if (programItems == null)
        {
          programItems = new List<ProgramItem>();
        }
        return programItems;
      }
    }

    public ProgramGroupItem(string title, string info, bool auto, List<ProgramItem> programItems)
    {
      this.Title = title;
      this.Info = info;
      this.programItems = programItems;
      this.Auto = auto;
    }
  }
}
