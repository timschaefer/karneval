﻿using System;
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
  public partial class ProgramItemViewControl : UserControl
  {
    public ProgramItem ProgramItem
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

    public ProgramItemViewControl(ProgramItem programItem)
    {
      InitializeComponent();
      this.ProgramItem = programItem;
      lblTitle.Text = programItem.Title;
    }

    private void ProgramItemViewControl_DoubleClick(object sender, EventArgs e)
    {
      Main mainForm = (Main) this.Parent;
      mainForm.SetActiveProgramItem(this);
    }

    private void lblTitle_DoubleClick(object sender, EventArgs e)
    {
      ProgramItemViewControl_DoubleClick(sender, e);
    }
  }
}