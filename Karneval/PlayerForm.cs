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
    #region Properties
    private List<ProgramItem> recurringItems;
    private List<ProgramGroupItem> programGroupItems;
    private ProgramGroupItem currentItem;

    public bool IsMediaPlaying
    {
      get
      {
        return mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying;
      }
    }
    #endregion
    #region Constructor
    public PlayerForm()
    {
      InitializeComponent();
    }
    #endregion

    #region LoadFile
    public void LoadFile()
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      fileDialog.Title = "Datei auswählen";
      fileDialog.Filter = string.Format("{0}|*.{1}", Program.FILE_EXTENSION_FILTER, Program.FILE_EXTENSION);
      fileDialog.CheckFileExists = true;

      if (fileDialog.ShowDialog() == DialogResult.OK)
      {
        LoadProgramFile(fileDialog.FileName);
      }
    }
    #endregion
    #region LoadProgramFile
    public bool LoadProgramFile(string filePath)
    {
      pnlProgramGroupItems.Controls.Clear();
      pnlRecurringItems.Controls.Clear();
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
          pnlProgramGroupItems.Controls.Add(control);
        }
        
        foreach (ProgramItem item in recurringItems)
        {
          Button button = new Button();
          button.Text = item.Name;
          button.Height = 40;
          button.Click += (_, __) => InitializeMediaPlayer(item.FilePath, true);
          pnlRecurringItems.Controls.Add(button);
        }
        
        string baseDir = new DirectoryInfo(filePath).Parent.FullName;

        ResolveFilePaths(recurringItems, baseDir);
        foreach (ProgramGroupItem item in programGroupItems)
        {
          ResolveFilePaths(item.ProgramItems, baseDir);
        }
        
        // set first program item to active
        SetActiveProgramGroupItem((ProgramGroupItemViewControl)pnlProgramGroupItems.Controls[0]);
        
        return true;
      }
      return false;
    }
    #endregion
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
    #region SetActiveProgramGroupItem
    public void SetActiveProgramGroupItem(ProgramGroupItemViewControl programGroupItem)
    {
      if (IsMediaPlaying)
      {
        return;
      }
      // set all group items to inactive
      foreach (Control control in pnlProgramGroupItems.Controls)
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

      // populate the program items of the current item to the list view
      PopulateProgramItems(currentItem.ProgramItems);

      // configure the player with the first item
      InitializeMediaPlayer(currentItem.ProgramItems[0].FilePath);
    }
    #endregion
    #region InitializeMediaPlayer
    private void InitializeMediaPlayer(string filePath, bool autoplay = false)
    {
      mediaPlayer.URL = filePath;
      lblCurrentItem.Text = filePath;
      if (!autoplay)
      {
        mediaPlayer.Ctlcontrols.stop();
      }
    }
    #endregion
    #region PopulateProgramItems
    private void PopulateProgramItems(List<ProgramItem> items)
    {
      lvProgramItems.Items.Clear();
      lvProgramItems.Columns.Clear();
      lvProgramItems.Columns.Add("Unterpunkt", lvProgramItems.Width - 4);
      foreach (ProgramItem item in items)
      {
        ListViewItem lvItem = new ListViewItem(new string[] { item.Name })
        {
          Tag = item
        };
        lvProgramItems.Items.Add(lvItem);
      }
    }
    #endregion

    #region Event Handler
    private void lvProgramItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (IsMediaPlaying)
      {
        if (e.IsSelected)
        {
          e.Item.Selected = false;
        }
      }
      ProgramItem programItem = (ProgramItem)e.Item.Tag;
      if (!IsMediaPlaying)
      {
        InitializeMediaPlayer(programItem.FilePath);
      }
    }

    private void lvProgramItems_MouseEnter(object sender, EventArgs e)
    {
      if (IsMediaPlaying)
      {
        lvProgramItems.Cursor = Cursors.No;
      }
      else
      {
        lvProgramItems.Cursor = Cursors.Default;
      }
    }

    private void itemOpen_Click(object sender, EventArgs e)
    {
      LoadFile();
    }

    private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void itemQuit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    #endregion
  }
}
