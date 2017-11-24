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
  }
}
