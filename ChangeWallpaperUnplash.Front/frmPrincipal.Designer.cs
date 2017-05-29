namespace ChangeWallpaperUnplash.Front
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnProximoWall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Hey, estamos aqui, não se preocupe!";
            this.notifyIcon.BalloonTipTitle = "Wallpaper from Unplash by LEOZD";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Wallpaper from Unplash by LEOZD";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // timer
            // 
            this.timer.Interval = 600000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(1, 7);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(200, 27);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Buscando imagem...";
            // 
            // btnProximoWall
            // 
            this.btnProximoWall.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnProximoWall.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnProximoWall.Location = new System.Drawing.Point(542, 3);
            this.btnProximoWall.Name = "btnProximoWall";
            this.btnProximoWall.Size = new System.Drawing.Size(87, 34);
            this.btnProximoWall.TabIndex = 1;
            this.btnProximoWall.Text = "Próxima";
            this.btnProximoWall.UseVisualStyleBackColor = false;
            this.btnProximoWall.Click += new System.EventHandler(this.btnProximoWall_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 41);
            this.Controls.Add(this.btnProximoWall);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallpaper from Unsplash by LEOZD";
            this.Resize += new System.EventHandler(this.frmPrincipal_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnProximoWall;
    }
}

