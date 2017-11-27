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
    private List<ProgramGroupItem> programGroupItems;
    private ProgramGroupItem currentItem;

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
        pnlProgramItems.Controls.Clear();
        pnlRecurringItems.Controls.Clear();
        
        LoadProgramFile(fileDialog.FileName);
      }
    }

    private bool LoadProgramFile(string filePath)
    {
      if (File.Exists(filePath))
      {
        try
        {
          JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));

          programGroupItems = new List<ProgramGroupItem>();

          recurringItems = jsonFile["recurringItems"].Select(p => p.ToObject<ProgramItem>()).ToList();
          foreach (JToken token in jsonFile["programGroupItems"])
          {
            List<ProgramItem> programItems = token["programItems"].Select(p => p.ToObject<ProgramItem>()).ToList();
            string info = token["info"] == null ? "" : token["info"].ToString();
            programGroupItems.Add(new ProgramGroupItem(token["title"].ToString(), info, programItems));
          }
        }
        catch (Exception)
        {
          MessageBox.Show("Fehler beim Lesen der JSON Datei");
        }

        
        // create controls for all program items
        foreach (ProgramGroupItem item in programGroupItems)
        {
          ProgramGroupItemViewControl control = new ProgramGroupItemViewControl(item);
          pnlProgramItems.Controls.Add(control);
        }
        
        foreach (ProgramItem item in recurringItems)
        {
          Button button = new Button();
          button.Text = item.Name;
          button.Height = 40;
          button.Click += (_, __) => mediaPlayer.URL = item.FilePath;
          pnlRecurringItems.Controls.Add(button);
        }
        
        string baseDir = new DirectoryInfo(filePath).Parent.FullName;

        ResolveFilePaths(recurringItems, baseDir);
        foreach (ProgramGroupItem item in programGroupItems)
        {
          ResolveFilePaths(item.ProgramItems, baseDir);
        }
        
        // set first program item to active
        SetActiveProgramGroupItem((ProgramGroupItemViewControl)pnlProgramItems.Controls[0]);
        
        return true;
      }
      return false;
    }

    #region ResolveFilePaths
    public void ResolveFilePaths(List<ProgramItem> items, string baseDir)
    {
      foreach (ProgramItem item in items)
      {
        if (!File.Exists(item.FilePath))
        {
          // try to resolve the file name against the project file location
          string path = Path.Combine(baseDir, item.FilePath);
          if (File.Exists(path))
          {
            item.FilePath = path;
          }
          else
          {
            MessageBox.Show(string.Format("Datei '{0}' existiert nicht (Pfad: {1})", item.Name, item.FilePath), "Datei existiert nicht");
          }
        }
      }
    }
    #endregion

    public void SetActiveProgramGroupItem(ProgramGroupItemViewControl programGroupItem)
    {
      if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
      {
        return;
      }
      foreach (Control control in pnlProgramItems.Controls)
      {
        if (control is ProgramGroupItemViewControl)
        {
          ((ProgramGroupItemViewControl)control).Active = false;
        }
      }
      programGroupItem.Active = true;
      currentItem = programGroupItem.ProgramGroupItem;

      grpCurrentItem.Text = currentItem.Title;

      rtxtInfo.Text = currentItem.Info;

      mediaPlayer.URL = currentItem.ProgramItems[0].FilePath;
      mediaPlayer.Ctlcontrols.stop();
    }

    private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void itemQuit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
