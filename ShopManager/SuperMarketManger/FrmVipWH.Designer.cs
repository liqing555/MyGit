namespace SuperMarketManger
{
    partial class FrmVipWH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberStatu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelect = new SuperMarketCommon.SuperText(this.components);
            this.btnSelectOK = new System.Windows.Forms.Button();
            this.btnVipZX = new System.Windows.Forms.Button();
            this.btnVipOpen = new System.Windows.Forms.Button();
            this.btnVipStop = new System.Windows.Forms.Button();
            this.btnUpdateVid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemberId,
            this.MemberName,
            this.Points,
            this.PhoneNumber,
            this.MemberAddress,
            this.OpenTime,
            this.MemberStatu});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 340);
            this.dataGridView1.TabIndex = 0;
            // 
            // MemberId
            // 
            this.MemberId.DataPropertyName = "MemberId";
            this.MemberId.HeaderText = "会员卡号";
            this.MemberId.Name = "MemberId";
            this.MemberId.ReadOnly = true;
            this.MemberId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MemberName
            // 
            this.MemberName.DataPropertyName = "MemberName";
            this.MemberName.HeaderText = "会员姓名";
            this.MemberName.Name = "MemberName";
            this.MemberName.ReadOnly = true;
            this.MemberName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Points
            // 
            this.Points.DataPropertyName = "Points";
            this.Points.HeaderText = "会员积分";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "联系电话";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhoneNumber.Width = 150;
            // 
            // MemberAddress
            // 
            this.MemberAddress.DataPropertyName = "MemberAddress";
            this.MemberAddress.HeaderText = "联系地址";
            this.MemberAddress.Name = "MemberAddress";
            this.MemberAddress.ReadOnly = true;
            this.MemberAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MemberAddress.Width = 300;
            // 
            // OpenTime
            // 
            this.OpenTime.DataPropertyName = "OpenTime";
            this.OpenTime.HeaderText = "开户时间";
            this.OpenTime.Name = "OpenTime";
            this.OpenTime.ReadOnly = true;
            this.OpenTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OpenTime.Width = 150;
            // 
            // MemberStatu
            // 
            this.MemberStatu.DataPropertyName = "MemberStatu";
            this.MemberStatu.HeaderText = "会员状态";
            this.MemberStatu.Name = "MemberStatu";
            this.MemberStatu.ReadOnly = true;
            this.MemberStatu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(322, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询条件：";
            // 
            // txtSelect
            // 
            this.txtSelect.Location = new System.Drawing.Point(416, 33);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(172, 21);
            this.txtSelect.TabIndex = 2;
            // 
            // btnSelectOK
            // 
            this.btnSelectOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectOK.Location = new System.Drawing.Point(612, 29);
            this.btnSelectOK.Name = "btnSelectOK";
            this.btnSelectOK.Size = new System.Drawing.Size(104, 30);
            this.btnSelectOK.TabIndex = 3;
            this.btnSelectOK.Text = "提交查询";
            this.btnSelectOK.UseVisualStyleBackColor = true;
            this.btnSelectOK.Click += new System.EventHandler(this.btnSelectOK_Click);
            // 
            // btnVipZX
            // 
            this.btnVipZX.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVipZX.Location = new System.Drawing.Point(495, 454);
            this.btnVipZX.Name = "btnVipZX";
            this.btnVipZX.Size = new System.Drawing.Size(104, 30);
            this.btnVipZX.TabIndex = 4;
            this.btnVipZX.Text = "会员注销";
            this.btnVipZX.UseVisualStyleBackColor = true;
            this.btnVipZX.Click += new System.EventHandler(this.btnVipZX_Click);
            // 
            // btnVipOpen
            // 
            this.btnVipOpen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVipOpen.Location = new System.Drawing.Point(628, 454);
            this.btnVipOpen.Name = "btnVipOpen";
            this.btnVipOpen.Size = new System.Drawing.Size(104, 30);
            this.btnVipOpen.TabIndex = 5;
            this.btnVipOpen.Text = "会员激活";
            this.btnVipOpen.UseVisualStyleBackColor = true;
            this.btnVipOpen.Click += new System.EventHandler(this.btnVipOpen_Click);
            // 
            // btnVipStop
            // 
            this.btnVipStop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVipStop.Location = new System.Drawing.Point(765, 454);
            this.btnVipStop.Name = "btnVipStop";
            this.btnVipStop.Size = new System.Drawing.Size(104, 30);
            this.btnVipStop.TabIndex = 6;
            this.btnVipStop.Text = "会员冻结";
            this.btnVipStop.UseVisualStyleBackColor = true;
            this.btnVipStop.Click += new System.EventHandler(this.btnVipStop_Click);
            // 
            // btnUpdateVid
            // 
            this.btnUpdateVid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateVid.Location = new System.Drawing.Point(898, 454);
            this.btnUpdateVid.Name = "btnUpdateVid";
            this.btnUpdateVid.Size = new System.Drawing.Size(104, 30);
            this.btnUpdateVid.TabIndex = 7;
            this.btnUpdateVid.Text = "修改会员";
            this.btnUpdateVid.UseVisualStyleBackColor = true;
            this.btnUpdateVid.Click += new System.EventHandler(this.btnUpdateVid_Click);
            // 
            // FrmVipWH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 496);
            this.Controls.Add(this.btnUpdateVid);
            this.Controls.Add(this.btnVipStop);
            this.Controls.Add(this.btnVipOpen);
            this.Controls.Add(this.btnVipZX);
            this.Controls.Add(this.btnSelectOK);
            this.Controls.Add(this.txtSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmVipWH";
            this.Text = "会员维护";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberStatu;
        private System.Windows.Forms.Label label1;
        private SuperMarketCommon.SuperText txtSelect;
        private System.Windows.Forms.Button btnSelectOK;
        private System.Windows.Forms.Button btnVipZX;
        private System.Windows.Forms.Button btnVipOpen;
        private System.Windows.Forms.Button btnVipStop;
        private System.Windows.Forms.Button btnUpdateVid;
    }
}