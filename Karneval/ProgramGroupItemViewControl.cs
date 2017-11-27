using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karneval
{
  public partial class ProgramGroupItemViewControl : UserControl
  {
    public ProgramGroupItem ProgramGroupItem
    {
      get; set;
    }

    public bool Active
    {
      set
      {
        if (value)
        {
          this.BackColor = Color.PaleTurquoise;
        }
        else
        {
          this.BackColor = SystemColors.Control;
        }
      }
    }

    public ProgramGroupItemViewControl()
    {
      InitializeComponent();
    }

    public ProgramGroupItemViewControl(ProgramGroupItem programGroupItem)
    {
      InitializeComponent();
      this.ProgramGroupItem = programGroupItem;
      lblTitle.Text = programGroupItem.Title;
    }

    private void ProgramItemViewControl_Click(object sender, EventArgs e)
    {
      PlayerForm mainForm = (PlayerForm) this.Parent.Parent;
      mainForm.SetActiveProgramGroupItem(this);
    }

    private void lblTitle_Click(object sender, EventArgs e)
    {
      ProgramItemViewControl_Click(sender, e);
    }
  }
}
