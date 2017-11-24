namespace Karneval
{
  partial class InitialForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialForm));
      this.cmdOpenFile = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cmdOpenFile
      // 
      this.cmdOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.cmdOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpenFile.Image")));
      this.cmdOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.cmdOpenFile.Location = new System.Drawing.Point(12, 35);
      this.cmdOpenFile.Name = "cmdOpenFile";
      this.cmdOpenFile.Size = new System.Drawing.Size(135, 74);
      this.cmdOpenFile.TabIndex = 0;
      this.cmdOpenFile.Text = "Datei öffnen..";
      this.cmdOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.cmdOpenFile.UseVisualStyleBackColor = true;
      this.cmdOpenFile.Click += new System.EventHandler(this.cmdOpenFile_Click);
      // 
      // InitialForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(386, 140);
      this.Controls.Add(this.cmdOpenFile);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "InitialForm";
      this.Text = "Karneval";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InitialForm_FormClosed);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button cmdOpenFile;
  }
}