namespace QLSPa_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelQL = new System.Windows.Forms.Label();
            this.lstKQQL = new System.Windows.Forms.ListBox();
            this.lstKQKH = new System.Windows.Forms.ListBox();
            this.labelKH = new System.Windows.Forms.Label();
            this.buttonQL = new System.Windows.Forms.Button();
            this.buttonKH = new System.Windows.Forms.Button();
            this.cboQuanLy = new System.Windows.Forms.ComboBox();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.txtInputQL = new System.Windows.Forms.TextBox();
            this.txtInputKH = new System.Windows.Forms.TextBox();
            this.pictureBoxKH = new System.Windows.Forms.PictureBox();
            this.pictureBoxQL = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQL)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQL
            // 
            resources.ApplyResources(this.labelQL, "labelQL");
            this.labelQL.Name = "labelQL";
            // 
            // lstKQQL
            // 
            this.lstKQQL.FormattingEnabled = true;
            resources.ApplyResources(this.lstKQQL, "lstKQQL");
            this.lstKQQL.Name = "lstKQQL";
            this.lstKQQL.Sorted = true;
            this.lstKQQL.SelectedIndexChanged += new System.EventHandler(this.lstKQQL_SelectedIndexChanged);
            // 
            // lstKQKH
            // 
            this.lstKQKH.FormattingEnabled = true;
            resources.ApplyResources(this.lstKQKH, "lstKQKH");
            this.lstKQKH.Name = "lstKQKH";
            // 
            // labelKH
            // 
            resources.ApplyResources(this.labelKH, "labelKH");
            this.labelKH.Name = "labelKH";
            // 
            // buttonQL
            // 
            resources.ApplyResources(this.buttonQL, "buttonQL");
            this.buttonQL.Name = "buttonQL";
            this.buttonQL.UseVisualStyleBackColor = true;
            this.buttonQL.Click += new System.EventHandler(this.btnBatDauQL_Click);
            // 
            // buttonKH
            // 
            resources.ApplyResources(this.buttonKH, "buttonKH");
            this.buttonKH.Name = "buttonKH";
            this.buttonKH.UseVisualStyleBackColor = true;
            this.buttonKH.Click += new System.EventHandler(this.btnBatDauKH_Click);
            // 
            // cboQuanLy
            // 
            this.cboQuanLy.FormattingEnabled = true;
            resources.ApplyResources(this.cboQuanLy, "cboQuanLy");
            this.cboQuanLy.Name = "cboQuanLy";
            this.cboQuanLy.SelectedIndexChanged += new System.EventHandler(this.cboQuanLy_SelectedIndexChanged);
            this.cboQuanLy.Click += new System.EventHandler(this.cboQuanLy_SelectedIndexChanged);
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.FormattingEnabled = true;
            resources.ApplyResources(this.cboKhachHang, "cboKhachHang");
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);
            this.cboKhachHang.Click += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);
            // 
            // txtInputQL
            // 
            resources.ApplyResources(this.txtInputQL, "txtInputQL");
            this.txtInputQL.Name = "txtInputQL";
            // 
            // txtInputKH
            // 
            resources.ApplyResources(this.txtInputKH, "txtInputKH");
            this.txtInputKH.Name = "txtInputKH";
            // 
            // pictureBoxKH
            // 
            this.pictureBoxKH.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            resources.ApplyResources(this.pictureBoxKH, "pictureBoxKH");
            this.pictureBoxKH.Name = "pictureBoxKH";
            this.pictureBoxKH.TabStop = false;
            this.pictureBoxKH.Click += new System.EventHandler(this.pictureBoxKH_Click);
            // 
            // pictureBoxQL
            // 
            this.pictureBoxQL.Cursor = System.Windows.Forms.Cursors.SizeAll;
            resources.ApplyResources(this.pictureBoxQL, "pictureBoxQL");
            this.pictureBoxQL.Name = "pictureBoxQL";
            this.pictureBoxQL.TabStop = false;
            this.pictureBoxQL.Click += new System.EventHandler(this.pictureBoxQL_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBoxQL);
            this.Controls.Add(this.pictureBoxKH);
            this.Controls.Add(this.txtInputKH);
            this.Controls.Add(this.txtInputQL);
            this.Controls.Add(this.cboKhachHang);
            this.Controls.Add(this.cboQuanLy);
            this.Controls.Add(this.buttonKH);
            this.Controls.Add(this.buttonQL);
            this.Controls.Add(this.labelKH);
            this.Controls.Add(this.lstKQKH);
            this.Controls.Add(this.lstKQQL);
            this.Controls.Add(this.labelQL);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQL;
        private System.Windows.Forms.ListBox lstKQQL;
        private System.Windows.Forms.ListBox lstKQKH;
        private System.Windows.Forms.Label labelKH;
        private System.Windows.Forms.Button buttonQL;
        private System.Windows.Forms.Button buttonKH;
        private System.Windows.Forms.ComboBox cboQuanLy;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.TextBox txtInputQL;
        private System.Windows.Forms.TextBox txtInputKH;
        private System.Windows.Forms.PictureBox pictureBoxKH;
        private System.Windows.Forms.PictureBox pictureBoxQL;
    }
}