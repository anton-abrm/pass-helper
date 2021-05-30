namespace PassHelper.Forms {

    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.txtEncryptedData = new System.Windows.Forms.TextBox();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.btnType = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbCerts = new System.Windows.Forms.ComboBox();
            this.ttCert = new System.Windows.Forms.ToolTip(this.components);
            this.ttSrc = new System.Windows.Forms.ToolTip(this.components);
            this.ttFormat = new System.Windows.Forms.ToolTip(this.components);
            this.ttEncryptedData = new System.Windows.Forms.ToolTip(this.components);
            this.ttSecret = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtSrc
            // 
            this.txtSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrc.Location = new System.Drawing.Point(13, 55);
            this.txtSrc.Margin = new System.Windows.Forms.Padding(4);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(437, 29);
            this.txtSrc.TabIndex = 0;
            // 
            // txtSecret
            // 
            this.txtSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecret.Location = new System.Drawing.Point(14, 266);
            this.txtSecret.Margin = new System.Windows.Forms.Padding(4);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.Size = new System.Drawing.Size(437, 29);
            this.txtSecret.TabIndex = 1;
            this.txtSecret.UseSystemPasswordChar = true;
            // 
            // txtEncryptedData
            // 
            this.txtEncryptedData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncryptedData.Location = new System.Drawing.Point(14, 92);
            this.txtEncryptedData.Margin = new System.Windows.Forms.Padding(4);
            this.txtEncryptedData.Multiline = true;
            this.txtEncryptedData.Name = "txtEncryptedData";
            this.txtEncryptedData.Size = new System.Drawing.Size(549, 128);
            this.txtEncryptedData.TabIndex = 3;
            this.txtEncryptedData.UseSystemPasswordChar = true;
            // 
            // cbFormat
            // 
            this.cbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "12hhhh",
            "12hhhx",
            "16hhhs",
            "08xxax",
            "04xxax"});
            this.cbFormat.Location = new System.Drawing.Point(458, 54);
            this.cbFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(104, 30);
            this.cbFormat.TabIndex = 7;
            // 
            // btnType
            // 
            this.btnType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnType.BackColor = System.Drawing.Color.White;
            this.btnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnType.Image = ((System.Drawing.Image)(resources.GetObject("btnType.Image")));
            this.btnType.Location = new System.Drawing.Point(534, 266);
            this.btnType.Margin = new System.Windows.Forms.Padding(4);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(30, 30);
            this.btnType.TabIndex = 10;
            this.btnType.UseVisualStyleBackColor = false;
            this.btnType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnType_MouseDown);
            this.btnType.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnType_MouseUp);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.BackColor = System.Drawing.Color.White;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(460, 266);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(30, 30);
            this.btnShow.TabIndex = 11;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnShow_MouseDown);
            this.btnShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnShow_MouseUp);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(497, 266);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbCommand
            // 
            this.cbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Items.AddRange(new object[] {
            "Generate Password",
            "Generate Keyfile",
            "Encrypt Secret",
            "Decrypt Data"});
            this.cbCommand.Location = new System.Drawing.Point(14, 228);
            this.cbCommand.Margin = new System.Windows.Forms.Padding(4);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(437, 30);
            this.cbCommand.TabIndex = 13;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.BackColor = System.Drawing.Color.White;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(460, 226);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 34);
            this.btnGo.TabIndex = 14;
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(534, 226);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(30, 31);
            this.btnReset.TabIndex = 15;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbCerts
            // 
            this.cbCerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCerts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCerts.FormattingEnabled = true;
            this.cbCerts.Location = new System.Drawing.Point(14, 13);
            this.cbCerts.Margin = new System.Windows.Forms.Padding(4);
            this.cbCerts.Name = "cbCerts";
            this.cbCerts.Size = new System.Drawing.Size(548, 30);
            this.cbCerts.TabIndex = 16;
            // 
            // ttCert
            // 
            this.ttCert.ToolTipTitle = "Certificate";
            // 
            // ttSrc
            // 
            this.ttSrc.ToolTipTitle = "Source";
            // 
            // ttFormat
            // 
            this.ttFormat.ToolTipTitle = "Format";
            // 
            // ttEncryptedData
            // 
            this.ttEncryptedData.ToolTipTitle = "Encrypted data";
            // 
            // ttSecret
            // 
            this.ttSecret.ToolTipTitle = "Secret";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(578, 304);
            this.Controls.Add(this.cbCerts);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cbCommand);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.cbFormat);
            this.Controls.Add(this.txtEncryptedData);
            this.Controls.Add(this.txtSecret);
            this.Controls.Add(this.txtSrc);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pass Helper";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.TextBox txtEncryptedData;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.ComboBox cbCommand;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbCerts;
        private System.Windows.Forms.ToolTip ttCert;
        private System.Windows.Forms.ToolTip ttSrc;
        private System.Windows.Forms.ToolTip ttFormat;
        private System.Windows.Forms.ToolTip ttEncryptedData;
        private System.Windows.Forms.ToolTip ttSecret;
    }
}

