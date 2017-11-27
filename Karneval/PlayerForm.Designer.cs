﻿namespace Karneval
{
    partial class PlayerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
      this.grpCurrentItem = new System.Windows.Forms.GroupBox();
      this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
      this.mnuMain = new System.Windows.Forms.MenuStrip();
      this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.itemNew = new System.Windows.Forms.ToolStripMenuItem();
      this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.itemQuit = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlProgramItems = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlRecurringItems = new System.Windows.Forms.FlowLayoutPanel();
      this.rtxtInfo = new System.Windows.Forms.RichTextBox();
      this.lblInfo = new System.Windows.Forms.Label();
      this.grpCurrentItem.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
      this.mnuMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpCurrentItem
      // 
      this.grpCurrentItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.grpCurrentItem.Controls.Add(this.mediaPlayer);
      this.grpCurrentItem.Location = new System.Drawing.Point(234, 196);
      this.grpCurrentItem.Name = "grpCurrentItem";
      this.grpCurrentItem.Size = new System.Drawing.Size(267, 115);
      this.grpCurrentItem.TabIndex = 0;
      this.grpCurrentItem.TabStop = false;
      this.grpCurrentItem.Text = "Aktueller Programmpunkt";
      // 
      // mediaPlayer
      // 
      this.mediaPlayer.Enabled = true;
      this.mediaPlayer.Location = new System.Drawing.Point(6, 47);
      this.mediaPlayer.Name = "mediaPlayer";
      this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
      this.mediaPlayer.Size = new System.Drawing.Size(244, 46);
      this.mediaPlayer.TabIndex = 1;
      // 
      // mnuMain
      // 
      this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
      this.mnuMain.Location = new System.Drawing.Point(0, 0);
      this.mnuMain.Name = "mnuMain";
      this.mnuMain.Size = new System.Drawing.Size(724, 24);
      this.mnuMain.TabIndex = 1;
      this.mnuMain.Text = "mainMenu";
      // 
      // dateiToolStripMenuItem
      // 
      this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNew,
            this.itemOpen,
            this.itemQuit});
      this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
      this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.dateiToolStripMenuItem.Text = "Datei";
      // 
      // itemNew
      // 
      this.itemNew.Name = "itemNew";
      this.itemNew.Size = new System.Drawing.Size(120, 22);
      this.itemNew.Text = "Neu";
      // 
      // itemOpen
      // 
      this.itemOpen.Name = "itemOpen";
      this.itemOpen.Size = new System.Drawing.Size(120, 22);
      this.itemOpen.Text = "Öffnen";
      this.itemOpen.Click += new System.EventHandler(this.itemOpen_Click);
      // 
      // itemQuit
      // 
      this.itemQuit.Name = "itemQuit";
      this.itemQuit.Size = new System.Drawing.Size(120, 22);
      this.itemQuit.Text = "Beenden";
      this.itemQuit.Click += new System.EventHandler(this.itemQuit_Click);
      // 
      // pnlProgramItems
      // 
      this.pnlProgramItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlProgramItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlProgramItems.Location = new System.Drawing.Point(10, 25);
      this.pnlProgramItems.Name = "pnlProgramItems";
      this.pnlProgramItems.Size = new System.Drawing.Size(697, 165);
      this.pnlProgramItems.TabIndex = 4;
      // 
      // pnlRecurringItems
      // 
      this.pnlRecurringItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlRecurringItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlRecurringItems.Location = new System.Drawing.Point(10, 326);
      this.pnlRecurringItems.Name = "pnlRecurringItems";
      this.pnlRecurringItems.Size = new System.Drawing.Size(697, 105);
      this.pnlRecurringItems.TabIndex = 0;
      // 
      // rtxtInfo
      // 
      this.rtxtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.rtxtInfo.Location = new System.Drawing.Point(522, 212);
      this.rtxtInfo.Name = "rtxtInfo";
      this.rtxtInfo.Size = new System.Drawing.Size(185, 99);
      this.rtxtInfo.TabIndex = 5;
      this.rtxtInfo.Text = "";
      // 
      // lblInfo
      // 
      this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.lblInfo.AutoSize = true;
      this.lblInfo.Location = new System.Drawing.Point(523, 196);
      this.lblInfo.Name = "lblInfo";
      this.lblInfo.Size = new System.Drawing.Size(181, 13);
      this.lblInfo.TabIndex = 6;
      this.lblInfo.Text = "Allgemeine Info zum Programmpunkt:";
      this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // PlayerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(724, 442);
      this.Controls.Add(this.lblInfo);
      this.Controls.Add(this.rtxtInfo);
      this.Controls.Add(this.pnlRecurringItems);
      this.Controls.Add(this.pnlProgramItems);
      this.Controls.Add(this.grpCurrentItem);
      this.Controls.Add(this.mnuMain);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.mnuMain;
      this.MinimumSize = new System.Drawing.Size(700, 450);
      this.Name = "PlayerForm";
      this.Text = "Karneval";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerForm_FormClosed);
      this.Load += new System.EventHandler(this.Main_Load);
      this.grpCurrentItem.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
      this.mnuMain.ResumeLayout(false);
      this.mnuMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.GroupBox grpCurrentItem;
    private System.Windows.Forms.MenuStrip mnuMain;
    private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem itemOpen;
    private System.Windows.Forms.ToolStripMenuItem itemNew;
    private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    private System.Windows.Forms.FlowLayoutPanel pnlProgramItems;
    private System.Windows.Forms.FlowLayoutPanel pnlRecurringItems;
    private System.Windows.Forms.RichTextBox rtxtInfo;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.ToolStripMenuItem itemQuit;
  }
}

