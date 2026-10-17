namespace PressurizationStationPro
{
    partial class MeterShow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_ParamName = new System.Windows.Forms.Label();
            this.lbl_paramValue = new System.Windows.Forms.Label();
            this.meter_Param = new xbd.ControlLib.xbdAnalogMeter();
            this.SuspendLayout();
            // 
            // lbl_ParamName
            // 
            this.lbl_ParamName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_ParamName.ForeColor = System.Drawing.Color.White;
            this.lbl_ParamName.Location = new System.Drawing.Point(0, 137);
            this.lbl_ParamName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ParamName.Name = "lbl_ParamName";
            this.lbl_ParamName.Size = new System.Drawing.Size(147, 31);
            this.lbl_ParamName.TabIndex = 0;
            this.lbl_ParamName.Text = "出水管温度";
            this.lbl_ParamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_paramValue
            // 
            this.lbl_paramValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_paramValue.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_paramValue.Location = new System.Drawing.Point(30, 115);
            this.lbl_paramValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_paramValue.Name = "lbl_paramValue";
            this.lbl_paramValue.Size = new System.Drawing.Size(88, 27);
            this.lbl_paramValue.TabIndex = 2;
            this.lbl_paramValue.Text = "0.00℃";
            this.lbl_paramValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // meter_Param
            // 
            this.meter_Param.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.meter_Param.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.meter_Param.Location = new System.Drawing.Point(0, 0);
            this.meter_Param.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.meter_Param.MaxValue = 100D;
            this.meter_Param.MinValue = 0D;
            this.meter_Param.Name = "meter_Param";
            this.meter_Param.NeedleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.meter_Param.Renderer = null;
            this.meter_Param.ScaleColor = System.Drawing.Color.White;
            this.meter_Param.ScaleDivisions = 11;
            this.meter_Param.ScaleSubDivisions = 4;
            this.meter_Param.Size = new System.Drawing.Size(147, 146);
            this.meter_Param.TabIndex = 1;
            this.meter_Param.Value = 0D;
            this.meter_Param.ViewGlass = false;
            // 
            // MeterShow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.lbl_ParamName);
            this.Controls.Add(this.lbl_paramValue);
            this.Controls.Add(this.meter_Param);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MeterShow";
            this.Size = new System.Drawing.Size(147, 168);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ParamName;
        private xbd.ControlLib.xbdAnalogMeter meter_Param;
        private System.Windows.Forms.Label lbl_paramValue;
    }
}
