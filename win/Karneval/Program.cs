using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karneval
{
  static class Program
  {
    public const string FILE_EXTENSION = "karneval";
    public const string FILE_EXTENSION_FILTER = "Karneval Dateien (*.karneval)";
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      var initial = new InitialForm();
      initial.Show();
      Application.Run();
    }
  }
}
