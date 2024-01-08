
using System.Windows.Forms;

namespace TypesClassNameExtractor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.PanelTop = new System.Windows.Forms.Panel();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.IconPictureBoxLoading = new FontAwesome.Sharp.IconPictureBox();
            this.ButtonLoadFile = new FontAwesome.Sharp.IconButton();
            this.PanelTop.SuspendLayout();
            this.PanelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.AllowDrop = true;
            this.PanelTop.BackColor = System.Drawing.Color.Transparent;
            this.PanelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelTop.Controls.Add(this.LabelStatus);
            this.PanelTop.Controls.Add(this.PanelButton);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(330, 157);
            this.PanelTop.TabIndex = 0;
            this.PanelTop.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.PanelTop.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AllowDrop = true;
            this.LabelStatus.BackColor = System.Drawing.Color.Transparent;
            this.LabelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelStatus.ForeColor = System.Drawing.Color.White;
            this.LabelStatus.Location = new System.Drawing.Point(0, 50);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(0);
            this.LabelStatus.MaximumSize = new System.Drawing.Size(334, 111);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(330, 107);
            this.LabelStatus.TabIndex = 8;
            this.LabelStatus.Text = "Drop or Load Types.xml";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelStatus.UseMnemonic = false;
            this.LabelStatus.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.LabelStatus.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            // 
            // PanelButton
            // 
            this.PanelButton.BackColor = System.Drawing.Color.Transparent;
            this.PanelButton.Controls.Add(this.IconPictureBoxLoading);
            this.PanelButton.Controls.Add(this.ButtonLoadFile);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelButton.Location = new System.Drawing.Point(0, 0);
            this.PanelButton.Margin = new System.Windows.Forms.Padding(0);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(330, 50);
            this.PanelButton.TabIndex = 9;
            // 
            // IconPictureBoxLoading
            // 
            this.IconPictureBoxLoading.BackColor = System.Drawing.Color.Transparent;
            this.IconPictureBoxLoading.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconPictureBoxLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(15)))), ((int)(((byte)(0)))));
            this.IconPictureBoxLoading.IconChar = FontAwesome.Sharp.IconChar.Hourglass;
            this.IconPictureBoxLoading.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(15)))), ((int)(((byte)(0)))));
            this.IconPictureBoxLoading.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconPictureBoxLoading.IconSize = 50;
            this.IconPictureBoxLoading.Location = new System.Drawing.Point(0, 0);
            this.IconPictureBoxLoading.Margin = new System.Windows.Forms.Padding(0);
            this.IconPictureBoxLoading.Name = "IconPictureBoxLoading";
            this.IconPictureBoxLoading.Size = new System.Drawing.Size(50, 50);
            this.IconPictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconPictureBoxLoading.TabIndex = 10;
            this.IconPictureBoxLoading.TabStop = false;
            this.IconPictureBoxLoading.Visible = false;
            // 
            // ButtonLoadFile
            // 
            this.ButtonLoadFile.AllowDrop = true;
            this.ButtonLoadFile.BackColor = System.Drawing.Color.Transparent;
            this.ButtonLoadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoadFile.FlatAppearance.BorderSize = 0;
            this.ButtonLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ButtonLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ButtonLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoadFile.ForeColor = System.Drawing.Color.White;
            this.ButtonLoadFile.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.ButtonLoadFile.IconColor = System.Drawing.Color.White;
            this.ButtonLoadFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonLoadFile.IconSize = 45;
            this.ButtonLoadFile.Location = new System.Drawing.Point(0, 0);
            this.ButtonLoadFile.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonLoadFile.Name = "ButtonLoadFile";
            this.ButtonLoadFile.Size = new System.Drawing.Size(330, 50);
            this.ButtonLoadFile.TabIndex = 7;
            this.ButtonLoadFile.TabStop = false;
            this.ButtonLoadFile.UseVisualStyleBackColor = false;
            this.ButtonLoadFile.Click += new System.EventHandler(this.ButtonLoadFile_Click);
            this.ButtonLoadFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.ButtonLoadFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.BackgroundImage = global::xscr33mLabs_TypesClassNameExtractor.Properties.Resources.xscr33mLabs_Splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(330, 157);
            this.Controls.Add(this.PanelTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Noto Sans", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(350, 500);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "TypesClassNameExtractor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.PanelTop.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBoxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PanelTop;
        private FontAwesome.Sharp.IconButton ButtonLoadFile;
        public Label LabelStatus;
        private Panel PanelButton;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxLoading;
    }
}

