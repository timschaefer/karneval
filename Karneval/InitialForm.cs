using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karneval
{
  public partial class InitialForm : Form
  {
    public InitialForm()
    {
      InitializeComponent();
    }

    private void cmdOpenFile_Click(object sender, EventArgs e)
    {
      PlayerForm playerForm = new PlayerForm();
      playerForm.LoadFile();
      playerForm.Show();
      this.Close();
    }

    private void InitialForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (Application.OpenForms.Count == 0)
      {
        Application.Exit();
      }
    }

    private void InitialForm_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.None;
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        if (files.Length == 1 && files[0].EndsWith(Program.FILE_EXTENSION))
        {
          e.Effect = DragDropEffects.Copy;
        }
      }
    }

    private void InitialForm_DragDrop(object sender, DragEventArgs e)
    {
      string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
      PlayerForm playerForm = new PlayerForm();
      playerForm.LoadProgramFile(file);
      playerForm.Show();
      this.Close();
    }
  }
}
