namespace NaturalnieApp.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.pMenu = new System.Windows.Forms.Panel();
            this.pCashRegisterSubMenu = new System.Windows.Forms.Panel();
            this.bCashRegisterSettings = new System.Windows.Forms.Button();
            this.bCashRegisterInfo = new System.Windows.Forms.Button();
            this.bCashRegister = new System.Windows.Forms.Button();
            this.bMainMenu = new System.Windows.Forms.Button();
            this.pLogo = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pControl = new System.Windows.Forms.Panel();
            this.pMenu.SuspendLayout();
            this.pCashRegisterSubMenu.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.Color.White;
            this.pMenu.Controls.Add(this.pCashRegisterSubMenu);
            this.pMenu.Controls.Add(this.bCashRegister);
            this.pMenu.Controls.Add(this.bMainMenu);
            this.pMenu.Controls.Add(this.pLogo);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMenu.Location = new System.Drawing.Point(0, 30);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(200, 420);
            this.pMenu.TabIndex = 0;
            // 
            // pCashRegisterSubMenu
            // 
            this.pCashRegisterSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pCashRegisterSubMenu.Controls.Add(this.bCashRegisterSettings);
            this.pCashRegisterSubMenu.Controls.Add(this.bCashRegisterInfo);
            this.pCashRegisterSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCashRegisterSubMenu.Location = new System.Drawing.Point(0, 156);
            this.pCashRegisterSubMenu.Name = "pCashRegisterSubMenu";
            this.pCashRegisterSubMenu.Size = new System.Drawing.Size(200, 60);
            this.pCashRegisterSubMenu.TabIndex = 3;
            // 
            // bCashRegisterSettings
            // 
            this.bCashRegisterSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCashRegisterSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegisterSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegisterSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegisterSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegisterSettings.ForeColor = System.Drawing.Color.White;
            this.bCashRegisterSettings.Location = new System.Drawing.Point(0, 30);
            this.bCashRegisterSettings.Name = "bCashRegisterSettings";
            this.bCashRegisterSettings.Size = new System.Drawing.Size(200, 30);
            this.bCashRegisterSettings.TabIndex = 5;
            this.bCashRegisterSettings.Text = "Ustawienia";
            this.bCashRegisterSettings.UseVisualStyleBackColor = false;
            // 
            // bCashRegisterInfo
            // 
            this.bCashRegisterInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCashRegisterInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bCashRegisterInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegisterInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegisterInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegisterInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegisterInfo.ForeColor = System.Drawing.Color.White;
            this.bCashRegisterInfo.Location = new System.Drawing.Point(0, 0);
            this.bCashRegisterInfo.Name = "bCashRegisterInfo";
            this.bCashRegisterInfo.Size = new System.Drawing.Size(200, 30);
            this.bCashRegisterInfo.TabIndex = 4;
            this.bCashRegisterInfo.Text = "Informacje";
            this.bCashRegisterInfo.UseVisualStyleBackColor = false;
            // 
            // bCashRegister
            // 
            this.bCashRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCashRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegister.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegister.ForeColor = System.Drawing.Color.White;
            this.bCashRegister.Location = new System.Drawing.Point(0, 116);
            this.bCashRegister.Name = "bCashRegister";
            this.bCashRegister.Size = new System.Drawing.Size(200, 40);
            this.bCashRegister.TabIndex = 2;
            this.bCashRegister.Text = "Kasa fiskalna";
            this.bCashRegister.UseVisualStyleBackColor = false;
            this.bCashRegister.Click += new System.EventHandler(this.bCashRegister_Click);
            // 
            // bMainMenu
            // 
            this.bMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bMainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.bMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMainMenu.ForeColor = System.Drawing.Color.White;
            this.bMainMenu.Location = new System.Drawing.Point(0, 76);
            this.bMainMenu.Name = "bMainMenu";
            this.bMainMenu.Size = new System.Drawing.Size(200, 40);
            this.bMainMenu.TabIndex = 1;
            this.bMainMenu.Text = "Menu główne";
            this.bMainMenu.UseVisualStyleBackColor = false;
            // 
            // pLogo
            // 
            this.pLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pLogo.BackgroundImage")));
            this.pLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pLogo.Location = new System.Drawing.Point(0, 0);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(200, 76);
            this.pLogo.TabIndex = 0;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pHeader.Controls.Add(this.button1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(800, 30);
            this.pHeader.TabIndex = 4;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(770, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pControl
            // 
            this.pControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.pControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pControl.Location = new System.Drawing.Point(200, 30);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(600, 420);
            this.pControl.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.pControl);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "ElzabCommands";
            this.pMenu.ResumeLayout(false);
            this.pCashRegisterSubMenu.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Button bMainMenu;
        private System.Windows.Forms.Panel pCashRegisterSubMenu;
        private System.Windows.Forms.Button bCashRegisterSettings;
        private System.Windows.Forms.Button bCashRegisterInfo;
        private System.Windows.Forms.Button bCashRegister;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pControl;
    }
}