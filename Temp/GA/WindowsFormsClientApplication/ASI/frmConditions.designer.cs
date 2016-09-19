namespace WindowsFormsClientApplication
{
    partial class frmConditions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConditions));
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.colChkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Channels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_operator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_limit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_logic = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.AllowUserToDeleteRows = false;
            this.dgvConditions.AllowUserToResizeRows = false;
            this.dgvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConditions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dgvConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChkBox,
            this.col_id,
            this.col_Channels,
            this.colDataType,
            this.col_operator,
            this.col_limit,
            this.col_logic});
            this.dgvConditions.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConditions.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvConditions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvConditions.EnableHeadersVisualStyles = false;
            this.dgvConditions.Location = new System.Drawing.Point(12, 12);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.RowHeadersVisible = false;
            this.dgvConditions.Size = new System.Drawing.Size(807, 214);
            this.dgvConditions.TabIndex = 2;
            this.dgvConditions.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConditions_CellMouseClick);
            this.dgvConditions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellValueChanged);
            this.dgvConditions.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvConditions_CurrentCellDirtyStateChanged);
            this.dgvConditions.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvConditions_EditingControlShowing);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::WindowsFormsClientApplication.Properties.Resources._32check1;
            this.btnClose.Location = new System.Drawing.Point(781, 232);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.BackColor = System.Drawing.Color.White;
            this.lblFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(21, 241);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(64, 18);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "WHERE ";
            // 
            // colChkBox
            // 
            this.colChkBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colChkBox.DataPropertyName = "useIt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.NullValue = false;
            this.colChkBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChkBox.FalseValue = "False";
            this.colChkBox.HeaderText = "Use";
            this.colChkBox.MinimumWidth = 50;
            this.colChkBox.Name = "colChkBox";
            this.colChkBox.TrueValue = "True";
            this.colChkBox.Width = 50;
            // 
            // col_id
            // 
            this.col_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.col_id.DataPropertyName = "id";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.col_id.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_id.HeaderText = "RowId";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_id.Visible = false;
            this.col_id.Width = 57;
            // 
            // col_Channels
            // 
            this.col_Channels.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_Channels.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Channels.HeaderText = "Root Channels";
            this.col_Channels.MinimumWidth = 150;
            this.col_Channels.Name = "col_Channels";
            this.col_Channels.ReadOnly = true;
            this.col_Channels.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Channels.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDataType
            // 
            this.colDataType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDataType.DataPropertyName = "dataType";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.colDataType.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDataType.HeaderText = "Type";
            this.colDataType.MinimumWidth = 50;
            this.colDataType.Name = "colDataType";
            this.colDataType.ReadOnly = true;
            this.colDataType.Width = 50;
            // 
            // col_operator
            // 
            this.col_operator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_operator.DataPropertyName = "operator";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_operator.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_operator.HeaderText = "Op";
            this.col_operator.MinimumWidth = 70;
            this.col_operator.Name = "col_operator";
            this.col_operator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_operator.Width = 70;
            // 
            // col_limit
            // 
            this.col_limit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_limit.DataPropertyName = "limitValue";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_limit.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_limit.HeaderText = "Limit Value";
            this.col_limit.MinimumWidth = 160;
            this.col_limit.Name = "col_limit";
            this.col_limit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_limit.Width = 160;
            // 
            // col_logic
            // 
            this.col_logic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_logic.DataPropertyName = "logic";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_logic.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_logic.HeaderText = "Logic";
            this.col_logic.MinimumWidth = 90;
            this.col_logic.Name = "col_logic";
            this.col_logic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_logic.Width = 90;
            // 
            // frmConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(831, 273);
            this.ControlBox = false;
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvConditions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConditions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Filtering";
            this.Load += new System.EventHandler(this.frmConditions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConditions;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Channels;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_limit;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_logic;
    }
}