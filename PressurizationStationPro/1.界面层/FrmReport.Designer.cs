namespace PressurizationStationPro
{
    partial class FrmReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReport));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Top_Panel = new System.Windows.Forms.Panel();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Query = new System.Windows.Forms.Button();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtp_ReportTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.出口温度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.rdb_Avg = new System.Windows.Forms.RadioButton();
            this.rdb_Min = new System.Windows.Forms.RadioButton();
            this.rdb_Max = new System.Windows.Forms.RadioButton();
            this.cmb_ReportType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Top_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PressurizationStationPro.Properties.Resources.History_png;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Print
            // 
            this.btn_Print.AutoSize = true;
            this.btn_Print.BackgroundImage = global::PressurizationStationPro.Properties.Resources.Yellow_png;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.btn_Print.Location = new System.Drawing.Point(1252, 90);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(108, 40);
            this.btn_Print.TabIndex = 5;
            this.btn_Print.Text = "打印记录";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.AutoSize = true;
            this.btn_Export.BackgroundImage = global::PressurizationStationPro.Properties.Resources.Green_png;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.btn_Export.Location = new System.Drawing.Point(1122, 90);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(108, 40);
            this.btn_Export.TabIndex = 5;
            this.btn_Export.Text = "导出记录";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Exit.ForeColor = System.Drawing.Color.White;
            this.lbl_Exit.Location = new System.Drawing.Point(1385, 13);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(26, 27);
            this.lbl_Exit.TabIndex = 3;
            this.lbl_Exit.Text = "X";
            this.lbl_Exit.Click += new System.EventHandler(this.lbl_Exit_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(52, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(106, 31);
            this.lbl_Title.TabIndex = 3;
            this.lbl_Title.Text = "数据报表";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1414, 1);
            this.label1.TabIndex = 1;
            // 
            // Top_Panel
            // 
            this.Top_Panel.Controls.Add(this.lbl_Exit);
            this.Top_Panel.Controls.Add(this.lbl_Title);
            this.Top_Panel.Controls.Add(this.pictureBox1);
            this.Top_Panel.Controls.Add(this.label1);
            this.Top_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Panel.Location = new System.Drawing.Point(1, 1);
            this.Top_Panel.Name = "Top_Panel";
            this.Top_Panel.Size = new System.Drawing.Size(1414, 52);
            this.Top_Panel.TabIndex = 1;
            this.Top_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.Top_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "PressureTankOut";
            this.Column9.HeaderText = "水箱出口压力";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "LevelTank1";
            this.Column8.HeaderText = "水箱液位2";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 105;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "LevelTank1";
            this.Column7.HeaderText = "水箱液位1";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 105;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PressureTank2";
            this.Column6.HeaderText = "水箱压力2";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 105;
            // 
            // btn_Query
            // 
            this.btn_Query.AutoSize = true;
            this.btn_Query.BackgroundImage = global::PressurizationStationPro.Properties.Resources.Pink_png;
            this.btn_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.btn_Query.Location = new System.Drawing.Point(988, 90);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(108, 40);
            this.btn_Query.TabIndex = 5;
            this.btn_Query.Text = "查询记录";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "PressureTank1";
            this.Column5.HeaderText = "水箱压力1";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 105;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "TempIn2";
            this.Column10.HeaderText = "进口温度2";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 105;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TempIn1";
            this.Column4.HeaderText = "进口温度1";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 105;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PressureOut";
            this.Column3.HeaderText = "出口压力";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PressureIn";
            this.Column2.HeaderText = "进口压力";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "InsertTime";
            this.Column1.HeaderText = "时间日期";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 180;
            // 
            // dtp_ReportTime
            // 
            this.dtp_ReportTime.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_ReportTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ReportTime.Location = new System.Drawing.Point(412, 94);
            this.dtp_ReportTime.Name = "dtp_ReportTime";
            this.dtp_ReportTime.Size = new System.Drawing.Size(212, 31);
            this.dtp_ReportTime.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(300, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "日期时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "报表类型";
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            this.dgv_data.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.dgv_data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_data.ColumnHeadersHeight = 45;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column10,
            this.出口温度,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_data.EnableHeadersVisualStyles = false;
            this.dgv_data.Location = new System.Drawing.Point(25, 199);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowHeadersWidth = 55;
            this.dgv_data.RowTemplate.Height = 35;
            this.dgv_data.Size = new System.Drawing.Size(1372, 612);
            this.dgv_data.TabIndex = 2;
            this.dgv_data.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_data_RowPostPaint);
            // 
            // 出口温度
            // 
            this.出口温度.DataPropertyName = "TempOut";
            this.出口温度.HeaderText = "出口温度";
            this.出口温度.MinimumWidth = 6;
            this.出口温度.Name = "出口温度";
            this.出口温度.ReadOnly = true;
            this.出口温度.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.出口温度.Width = 125;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.rdb_Avg);
            this.MainPanel.Controls.Add(this.rdb_Min);
            this.MainPanel.Controls.Add(this.rdb_Max);
            this.MainPanel.Controls.Add(this.cmb_ReportType);
            this.MainPanel.Controls.Add(this.btn_Print);
            this.MainPanel.Controls.Add(this.btn_Export);
            this.MainPanel.Controls.Add(this.btn_Query);
            this.MainPanel.Controls.Add(this.dtp_ReportTime);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.dgv_data);
            this.MainPanel.Controls.Add(this.Top_Panel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(1);
            this.MainPanel.Size = new System.Drawing.Size(1418, 849);
            this.MainPanel.TabIndex = 1;
            // 
            // rdb_Avg
            // 
            this.rdb_Avg.AutoSize = true;
            this.rdb_Avg.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.rdb_Avg.ForeColor = System.Drawing.Color.White;
            this.rdb_Avg.Location = new System.Drawing.Point(872, 94);
            this.rdb_Avg.Name = "rdb_Avg";
            this.rdb_Avg.Size = new System.Drawing.Size(96, 32);
            this.rdb_Avg.TabIndex = 7;
            this.rdb_Avg.Text = "平均值";
            this.rdb_Avg.UseVisualStyleBackColor = true;
            // 
            // rdb_Min
            // 
            this.rdb_Min.AutoSize = true;
            this.rdb_Min.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.rdb_Min.ForeColor = System.Drawing.Color.White;
            this.rdb_Min.Location = new System.Drawing.Point(763, 95);
            this.rdb_Min.Name = "rdb_Min";
            this.rdb_Min.Size = new System.Drawing.Size(96, 32);
            this.rdb_Min.TabIndex = 7;
            this.rdb_Min.Text = "最小值";
            this.rdb_Min.UseVisualStyleBackColor = true;
            // 
            // rdb_Max
            // 
            this.rdb_Max.AutoSize = true;
            this.rdb_Max.Checked = true;
            this.rdb_Max.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.rdb_Max.ForeColor = System.Drawing.Color.White;
            this.rdb_Max.Location = new System.Drawing.Point(654, 95);
            this.rdb_Max.Name = "rdb_Max";
            this.rdb_Max.Size = new System.Drawing.Size(96, 32);
            this.rdb_Max.TabIndex = 7;
            this.rdb_Max.TabStop = true;
            this.rdb_Max.Text = "最大值";
            this.rdb_Max.UseVisualStyleBackColor = true;
            // 
            // cmb_ReportType
            // 
            this.cmb_ReportType.FormattingEnabled = true;
            this.cmb_ReportType.Location = new System.Drawing.Point(137, 95);
            this.cmb_ReportType.Name = "cmb_ReportType";
            this.cmb_ReportType.Size = new System.Drawing.Size(138, 31);
            this.cmb_ReportType.TabIndex = 6;
            this.cmb_ReportType.SelectedIndexChanged += new System.EventHandler(this.cmb_ReportType_SelectedIndexChanged);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 849);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReport";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Top_Panel.ResumeLayout(false);
            this.Top_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label lbl_Exit;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Top_Panel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DateTimePicker dtp_ReportTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出口温度;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ComboBox cmb_ReportType;
        private System.Windows.Forms.RadioButton rdb_Avg;
        private System.Windows.Forms.RadioButton rdb_Min;
        private System.Windows.Forms.RadioButton rdb_Max;
    }
}