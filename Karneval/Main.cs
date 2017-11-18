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
  public partial class Main : Form
  {
    private List<ProgramItem> recurringItems;
    private List<ProgramItem> programItems;
    private ProgramItem currentItem;

    public Main()
    {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      
    }

    private void itemOpen_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      fileDialog.Title = "Datei auswählen";
      fileDialog.Filter = "JSON files (*.json)|*.json";
      fileDialog.CheckFileExists = true;
      
      if (fileDialog.ShowDialog() == DialogResult.OK)
      {
        string fileName = fileDialog.FileName;
        LoadProgramFile(fileName);
        currentItem = recurringItems[0];
        
        mediaPlayer.URL = currentItem.FilePath;
        mediaPlayer.Ctlcontrols.stop();
      }
    }

    private bool LoadProgramFile(string filePath)
    {
      if (File.Exists(filePath))
      {
        try
        {
          JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));

          recurringItems = jsonFile["recurringItems"].Select(x => x.ToObject<ProgramItem>()).ToList();
          programItems = jsonFile["programItems"].Select(x => x.ToObject<ProgramItem>()).ToList();
        }
        catch (Exception)
        {
          MessageBox.Show("Fehler beim Lesen der JSON Datei");
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
  }
}
