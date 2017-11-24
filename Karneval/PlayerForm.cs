using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Karneval
{
  public partial class PlayerForm : Form
  {
    private List<ProgramItem> recurringItems;
    private List<ProgramItem> programItems;
    private ProgramItem currentItem;

    public PlayerForm()
    {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      
    }

    private void itemOpen_Click(object sender, EventArgs e)
    {
      LoadFile();
    }

    public void LoadFile()
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      fileDialog.Title = "Datei auswählen";
      fileDialog.Filter = "JSON files (*.json)|*.json";
      fileDialog.CheckFileExists = true;

      if (fileDialog.ShowDialog() == DialogResult.OK)
      {
        string fileName = fileDialog.FileName;
        LoadProgramFile(fileName);
      }
    }

    private bool LoadProgramFile(string filePath)
    {
      if (File.Exists(filePath))
      {
        try
        {
          JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));

          recurringItems = jsonFile["recurringItems"].Select(p => p.ToObject<ProgramItem>()).ToList();
          programItems = jsonFile["programItems"].Select(p => p.ToObject<ProgramItem>()).ToList();
        }
        catch (Exception)
        {
          MessageBox.Show("Fehler beim Lesen der JSON Datei");
        }

        foreach (ProgramItem item in programItems)
        {
          ProgramItemViewControl control = new ProgramItemViewControl(item);
          pnlProgramItems.Controls.Add(control);
        }
        // set first program item to active
        SetActiveProgramItem((ProgramItemViewControl) pnlProgramItems.Controls[0]);

        foreach (ProgramItem item in recurringItems)
        {
          Button button = new Button();
          button.Text = item.Title;
          button.Click += (_, __) => mediaPlayer.URL = item.FilePath;
          pnlRecurringItems.Controls.Add(button);
        }

        DirectoryInfo programDefinitionLocation = new DirectoryInfo(filePath);
        foreach (ProgramItem item in recurringItems)
        {
          if (!File.Exists(item.FilePath))
          {
            MessageBox.Show(string.Format("Datei '{0}' existiert nicht (Pfad: {1})", item.Title, item.FilePath), "Datei existiert nicht");
          }
        }

        return true;
      }
      return false;
    }

    public void SetActiveProgramItem(ProgramItemViewControl programItem)
    {
      if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
      {
        return;
      }
      foreach (Control control in pnlProgramItems.Controls)
      {
        if (control is ProgramItemViewControl)
        {
          ((ProgramItemViewControl)control).Active = false;
        }
      }
      programItem.Active = true;
      currentItem = programItem.ProgramItem;

      grpCurrentItem.Text = currentItem.Title;

      rtxtInfo.Text = currentItem.Info;

      mediaPlayer.URL = currentItem.FilePath;
      mediaPlayer.Ctlcontrols.stop();
    }

    private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }
  }
}
