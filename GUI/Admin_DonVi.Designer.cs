namespace HTTT_QLTienAn.GUI
{
    partial class Admin_DonVi
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvDV = new DevExpress.XtraGrid.GridControl();
            this.dgvDV_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.Thêm = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnThemDV = new DevExpress.XtraEditors.SimpleButton();
            this.txtThemTenDV = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtSuaMaDV = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSuaTenDV = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSuaDV = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thêm)).BeginInit();
            this.Thêm.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThemTenDV.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaMaDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaTenDV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dgvDV);
            this.groupControl1.Location = new System.Drawing.Point(0, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1024, 375);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin đơn vị";
            // 
            // dgvDV
            // 
            this.dgvDV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDV.Location = new System.Drawing.Point(2, 28);
            this.dgvDV.MainView = this.dgvDV_View;
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.Size = new System.Drawing.Size(1020, 347);
            this.dgvDV.TabIndex = 0;
            this.dgvDV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDV_View});
            // 
            // dgvDV_View
            // 
            this.dgvDV_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.dgvDV_View.GridControl = this.dgvDV;
            this.dgvDV_View.Name = "dgvDV_View";
            this.dgvDV_View.OptionsView.ShowGroupPanel = false;
            this.dgvDV_View.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvDV_View_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã đơn vị";
            this.gridColumn1.FieldName = "MaDonVi";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên đơn vị";
            this.gridColumn2.FieldName = "TenDonVi";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 94;
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.Thêm);
            this.groupControl3.Location = new System.Drawing.Point(3, 384);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1019, 218);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Chỉnh sửa thông tin đơn vị";
            // 
            // Thêm
            // 
            this.Thêm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Thêm.Location = new System.Drawing.Point(2, 28);
            this.Thêm.Name = "Thêm";
            this.Thêm.SelectedTabPage = this.xtraTabPage1;
            this.Thêm.Size = new System.Drawing.Size(1015, 188);
            this.Thêm.TabIndex = 0;
            this.Thêm.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnThemDV);
            this.xtraTabPage1.Controls.Add(this.txtThemTenDV);
            this.xtraTabPage1.Controls.Add(this.label3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1013, 156);
            this.xtraTabPage1.Text = "Thêm";
            // 
            // btnThemDV
            // 
            this.btnThemDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemDV.Location = new System.Drawing.Point(408, 52);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(99, 58);
            this.btnThemDV.TabIndex = 14;
            this.btnThemDV.Text = "Thêm";
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // txtThemTenDV
            // 
            this.txtThemTenDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtThemTenDV.EditValue = "";
            this.txtThemTenDV.Location = new System.Drawing.Point(62, 69);
            this.txtThemTenDV.Name = "txtThemTenDV";
            this.txtThemTenDV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtThemTenDV.Size = new System.Drawing.Size(283, 24);
            this.txtThemTenDV.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên đơn vị";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtSuaMaDV);
            this.xtraTabPage2.Controls.Add(this.label1);
            this.xtraTabPage2.Controls.Add(this.txtSuaTenDV);
            this.xtraTabPage2.Controls.Add(this.label13);
            this.xtraTabPage2.Controls.Add(this.btnSuaDV);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1013, 156);
            this.xtraTabPage2.Text = "Sửa";
            // 
            // txtSuaMaDV
            // 
            this.txtSuaMaDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSuaMaDV.EditValue = "";
            this.txtSuaMaDV.Enabled = false;
            this.txtSuaMaDV.Location = new System.Drawing.Point(54, 48);
            this.txtSuaMaDV.Name = "txtSuaMaDV";
            this.txtSuaMaDV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuaMaDV.Size = new System.Drawing.Size(283, 24);
            this.txtSuaMaDV.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã đơn vị";
            // 
            // txtSuaTenDV
            // 
            this.txtSuaTenDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSuaTenDV.EditValue = "";
            this.txtSuaTenDV.Location = new System.Drawing.Point(54, 111);
            this.txtSuaTenDV.Name = "txtSuaTenDV";
            this.txtSuaTenDV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuaTenDV.Size = new System.Drawing.Size(283, 24);
            this.txtSuaTenDV.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(51, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 18);
            this.label13.TabIndex = 23;
            this.label13.Text = "Tên đơn vị";
            // 
            // btnSuaDV
            // 
            this.btnSuaDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaDV.Location = new System.Drawing.Point(404, 66);
            this.btnSuaDV.Name = "btnSuaDV";
            this.btnSuaDV.Size = new System.Drawing.Size(110, 60);
            this.btnSuaDV.TabIndex = 21;
            this.btnSuaDV.Text = "Sửa";
            this.btnSuaDV.Click += new System.EventHandler(this.btnSuaDV_Click);
            // 
            // Admin_DonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Name = "Admin_DonVi";
            this.Size = new System.Drawing.Size(1027, 605);
            this.Load += new System.EventHandler(this.Admin_DonVi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Thêm)).EndInit();
            this.Thêm.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThemTenDV.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaMaDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaTenDV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgvDV;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDV_View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraTab.XtraTabControl Thêm;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnThemDV;
        private DevExpress.XtraEditors.TextEdit txtThemTenDV;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit txtSuaTenDV;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.SimpleButton btnSuaDV;
        private DevExpress.XtraEditors.TextEdit txtSuaMaDV;
        private System.Windows.Forms.Label label1;
    }
}
