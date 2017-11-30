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
    private PlayerForm MainForm
    {
      get
      {
        return (PlayerForm)this.Parent.Parent;
      }
    }

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
          this.BackColor = Color.GreenYellow;
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
      MainForm.SetActiveProgramGroupItem(this);
    }

    private void lblTitle_Click(object sender, EventArgs e)
    {
      ProgramItemViewControl_Click(sender, e);
    }

    private void ProgramGroupItemViewControl_MouseEnter(object sender, EventArgs e)
    {
      if (MainForm.IsMediaPlaying)
      {
        this.Cursor = Cursors.No;
      }
      else
      {
        this.Cursor = Cursors.Hand;
      }
    }
  }
}
