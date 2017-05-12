namespace SetIIS
{
    partial class frmConfig
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
            this.clbSites = new System.Windows.Forms.CheckedListBox();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblSitePath = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.chkReset = new System.Windows.Forms.CheckBox();
            this.gbIIS = new System.Windows.Forms.GroupBox();
            this.gbSites = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnRefreshSites = new System.Windows.Forms.Button();
            this.gbBranch = new System.Windows.Forms.GroupBox();
            this.btnBranchUpdate = new System.Windows.Forms.Button();
            this.btnBranchInsert = new System.Windows.Forms.Button();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.btnBranchDelete = new System.Windows.Forms.Button();
            this.clbBranch = new System.Windows.Forms.CheckedListBox();
            this.gbIIS.SuspendLayout();
            this.gbSites.SuspendLayout();
            this.gbBranch.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbSites
            // 
            this.clbSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbSites.FormattingEnabled = true;
            this.clbSites.Location = new System.Drawing.Point(78, 59);
            this.clbSites.Name = "clbSites";
            this.clbSites.Size = new System.Drawing.Size(283, 214);
            this.clbSites.TabIndex = 0;
            this.clbSites.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbSites_ItemCheck);
            this.clbSites.SelectedIndexChanged += new System.EventHandler(this.clbSites_SelectedIndexChanged);
            // 
            // cbBranch
            // 
            this.cbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(78, 32);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(283, 21);
            this.cbBranch.TabIndex = 1;
            this.cbBranch.SelectedIndexChanged += new System.EventHandler(this.cbBranch_SelectedIndexChanged);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(78, 340);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(283, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // lblSiteName
            // 
            this.lblSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.Location = new System.Drawing.Point(25, 317);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(47, 13);
            this.lblSiteName.TabIndex = 4;
            this.lblSiteName.Text = "Nombre:";
            // 
            // lblSitePath
            // 
            this.lblSitePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSitePath.AutoSize = true;
            this.lblSitePath.Location = new System.Drawing.Point(25, 343);
            this.lblSitePath.Name = "lblSitePath";
            this.lblSitePath.Size = new System.Drawing.Size(32, 13);
            this.lblSitePath.TabIndex = 5;
            this.lblSitePath.Text = "Path:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(569, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSet.Location = new System.Drawing.Point(12, 437);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(80, 23);
            this.btnSet.TabIndex = 6;
            this.btnSet.Text = "Ok";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // chkReset
            // 
            this.chkReset.AutoSize = true;
            this.chkReset.Location = new System.Drawing.Point(6, 19);
            this.chkReset.Name = "chkReset";
            this.chkReset.Size = new System.Drawing.Size(83, 17);
            this.chkReset.TabIndex = 8;
            this.chkReset.Text = "Reiniciar IIS";
            this.chkReset.UseVisualStyleBackColor = true;
            this.chkReset.CheckedChanged += new System.EventHandler(this.chkReset_CheckedChanged);
            // 
            // gbIIS
            // 
            this.gbIIS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIIS.Controls.Add(this.chkReset);
            this.gbIIS.Location = new System.Drawing.Point(12, 384);
            this.gbIIS.Name = "gbIIS";
            this.gbIIS.Size = new System.Drawing.Size(637, 47);
            this.gbIIS.TabIndex = 10;
            this.gbIIS.TabStop = false;
            this.gbIIS.Text = "IIS";
            // 
            // gbSites
            // 
            this.gbSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSites.Controls.Add(this.lblName);
            this.gbSites.Controls.Add(this.btnRefreshSites);
            this.gbSites.Controls.Add(this.cbBranch);
            this.gbSites.Controls.Add(this.clbSites);
            this.gbSites.Controls.Add(this.txtPath);
            this.gbSites.Controls.Add(this.lblSitePath);
            this.gbSites.Controls.Add(this.lblSiteName);
            this.gbSites.Location = new System.Drawing.Point(282, 12);
            this.gbSites.Name = "gbSites";
            this.gbSites.Size = new System.Drawing.Size(367, 366);
            this.gbSites.TabIndex = 11;
            this.gbSites.TabStop = false;
            this.gbSites.Text = "Sites";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(78, 317);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 9;
            // 
            // btnRefreshSites
            // 
            this.btnRefreshSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSites.Location = new System.Drawing.Point(78, 285);
            this.btnRefreshSites.Name = "btnRefreshSites";
            this.btnRefreshSites.Size = new System.Drawing.Size(283, 23);
            this.btnRefreshSites.TabIndex = 8;
            this.btnRefreshSites.Text = "Actualizar";
            this.btnRefreshSites.UseVisualStyleBackColor = true;
            this.btnRefreshSites.Click += new System.EventHandler(this.btnRefreshSites_Click);
            // 
            // gbBranch
            // 
            this.gbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbBranch.Controls.Add(this.btnBranchUpdate);
            this.gbBranch.Controls.Add(this.btnBranchInsert);
            this.gbBranch.Controls.Add(this.txtBranch);
            this.gbBranch.Controls.Add(this.lblBranch);
            this.gbBranch.Controls.Add(this.btnBranchDelete);
            this.gbBranch.Controls.Add(this.clbBranch);
            this.gbBranch.Location = new System.Drawing.Point(12, 12);
            this.gbBranch.Name = "gbBranch";
            this.gbBranch.Size = new System.Drawing.Size(264, 366);
            this.gbBranch.TabIndex = 12;
            this.gbBranch.TabStop = false;
            this.gbBranch.Text = "Branch";
            // 
            // btnBranchUpdate
            // 
            this.btnBranchUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBranchUpdate.Location = new System.Drawing.Point(178, 333);
            this.btnBranchUpdate.Name = "btnBranchUpdate";
            this.btnBranchUpdate.Size = new System.Drawing.Size(80, 23);
            this.btnBranchUpdate.TabIndex = 11;
            this.btnBranchUpdate.Text = "Actualizar";
            this.btnBranchUpdate.UseVisualStyleBackColor = true;
            this.btnBranchUpdate.Click += new System.EventHandler(this.btnBranchUpdate_Click);
            // 
            // btnBranchInsert
            // 
            this.btnBranchInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBranchInsert.Location = new System.Drawing.Point(92, 333);
            this.btnBranchInsert.Name = "btnBranchInsert";
            this.btnBranchInsert.Size = new System.Drawing.Size(80, 23);
            this.btnBranchInsert.TabIndex = 10;
            this.btnBranchInsert.Text = "Insertar";
            this.btnBranchInsert.UseVisualStyleBackColor = true;
            this.btnBranchInsert.Click += new System.EventHandler(this.btnBranchInsert_Click);
            // 
            // txtBranch
            // 
            this.txtBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranch.Location = new System.Drawing.Point(61, 307);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(197, 20);
            this.txtBranch.TabIndex = 8;
            // 
            // lblBranch
            // 
            this.lblBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(3, 310);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(47, 13);
            this.lblBranch.TabIndex = 9;
            this.lblBranch.Text = "Nombre:";
            // 
            // btnBranchDelete
            // 
            this.btnBranchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBranchDelete.Location = new System.Drawing.Point(6, 333);
            this.btnBranchDelete.Name = "btnBranchDelete";
            this.btnBranchDelete.Size = new System.Drawing.Size(80, 23);
            this.btnBranchDelete.TabIndex = 7;
            this.btnBranchDelete.Text = "Eliminar";
            this.btnBranchDelete.UseVisualStyleBackColor = true;
            this.btnBranchDelete.Click += new System.EventHandler(this.btnBranchDelete_Click);
            // 
            // clbBranch
            // 
            this.clbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbBranch.FormattingEnabled = true;
            this.clbBranch.Location = new System.Drawing.Point(61, 32);
            this.clbBranch.Name = "clbBranch";
            this.clbBranch.Size = new System.Drawing.Size(197, 259);
            this.clbBranch.TabIndex = 1;
            this.clbBranch.SelectedIndexChanged += new System.EventHandler(this.clbBranch_SelectedIndexChanged);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 472);
            this.Controls.Add(this.gbBranch);
            this.Controls.Add(this.gbSites);
            this.Controls.Add(this.gbIIS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSet);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(677, 511);
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.gbIIS.ResumeLayout(false);
            this.gbIIS.PerformLayout();
            this.gbSites.ResumeLayout(false);
            this.gbSites.PerformLayout();
            this.gbBranch.ResumeLayout(false);
            this.gbBranch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbSites;
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblSitePath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox chkReset;
        private System.Windows.Forms.GroupBox gbIIS;
        private System.Windows.Forms.GroupBox gbSites;
        private System.Windows.Forms.GroupBox gbBranch;
        private System.Windows.Forms.CheckedListBox clbBranch;
        private System.Windows.Forms.Button btnBranchUpdate;
        private System.Windows.Forms.Button btnBranchInsert;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Button btnBranchDelete;
        private System.Windows.Forms.Button btnRefreshSites;
        private System.Windows.Forms.Label lblName;
    }
}