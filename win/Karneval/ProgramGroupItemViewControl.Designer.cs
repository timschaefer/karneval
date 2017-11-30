namespace Karneval
{
  partial class ProgramGroupItemViewControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lblTitle = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(3, 11);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(23, 13);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "title";
      this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
      // 
      // ProgramGroupItemViewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Controls.Add(this.lblTitle);
      this.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Name = "ProgramGroupItemViewControl";
      this.Size = new System.Drawing.Size(148, 48);
      this.Click += new System.EventHandler(this.ProgramItemViewControl_Click);
      this.MouseEnter += new System.EventHandler(this.ProgramGroupItemViewControl_MouseEnter);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
  }
}
