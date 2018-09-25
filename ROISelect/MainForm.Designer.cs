namespace ROISelect
{
    partial class form_main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_full = new System.Windows.Forms.PictureBox();
            this.tabPage_selectRoi = new System.Windows.Forms.TabPage();
            this.pictureBox_part = new System.Windows.Forms.PictureBox();
            this.button_next = new System.Windows.Forms.Button();
            this.button_prev = new System.Windows.Forms.Button();
            this.tabPage_selectCenter = new System.Windows.Forms.TabPage();
            this.tabPage_browse = new System.Windows.Forms.TabPage();
            this.groupBox_browse = new System.Windows.Forms.GroupBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.label_path = new System.Windows.Forms.Label();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_full)).BeginInit();
            this.tabPage_selectRoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_part)).BeginInit();
            this.tabPage_browse.SuspendLayout();
            this.groupBox_browse.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_full
            // 
            this.pictureBox_full.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_full.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox_full.Location = new System.Drawing.Point(674, 58);
            this.pictureBox_full.Name = "pictureBox_full";
            this.pictureBox_full.Size = new System.Drawing.Size(500, 500);
            this.pictureBox_full.TabIndex = 0;
            this.pictureBox_full.TabStop = false;
            this.pictureBox_full.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_main_Paint);
            // 
            // tabPage_selectRoi
            // 
            this.tabPage_selectRoi.Controls.Add(this.button_prev);
            this.tabPage_selectRoi.Controls.Add(this.button_next);
            this.tabPage_selectRoi.Controls.Add(this.pictureBox_part);
            this.tabPage_selectRoi.Location = new System.Drawing.Point(4, 22);
            this.tabPage_selectRoi.Name = "tabPage_selectRoi";
            this.tabPage_selectRoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_selectRoi.Size = new System.Drawing.Size(621, 631);
            this.tabPage_selectRoi.TabIndex = 2;
            this.tabPage_selectRoi.Text = "Select Roi";
            this.tabPage_selectRoi.UseVisualStyleBackColor = true;
            // 
            // pictureBox_part
            // 
            this.pictureBox_part.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox_part.Location = new System.Drawing.Point(141, 24);
            this.pictureBox_part.Name = "pictureBox_part";
            this.pictureBox_part.Size = new System.Drawing.Size(250, 250);
            this.pictureBox_part.TabIndex = 0;
            this.pictureBox_part.TabStop = false;
            this.pictureBox_part.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_part_Paint);
            this.pictureBox_part.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_part_MouseDown);
            this.pictureBox_part.MouseLeave += new System.EventHandler(this.pictureBox_part_MouseLeave);
            this.pictureBox_part.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_part_MouseMove);
            this.pictureBox_part.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_part_MouseUp);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(426, 132);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 1;
            this.button_next.Text = ">>";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_prev
            // 
            this.button_prev.Location = new System.Drawing.Point(32, 132);
            this.button_prev.Name = "button_prev";
            this.button_prev.Size = new System.Drawing.Size(75, 23);
            this.button_prev.TabIndex = 1;
            this.button_prev.Text = "<<";
            this.button_prev.UseVisualStyleBackColor = true;
            this.button_prev.Click += new System.EventHandler(this.button_prev_Click);
            // 
            // tabPage_selectCenter
            // 
            this.tabPage_selectCenter.Location = new System.Drawing.Point(4, 22);
            this.tabPage_selectCenter.Name = "tabPage_selectCenter";
            this.tabPage_selectCenter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_selectCenter.Size = new System.Drawing.Size(621, 631);
            this.tabPage_selectCenter.TabIndex = 1;
            this.tabPage_selectCenter.Text = "Select Center";
            this.tabPage_selectCenter.UseVisualStyleBackColor = true;
            // 
            // tabPage_browse
            // 
            this.tabPage_browse.Controls.Add(this.groupBox_browse);
            this.tabPage_browse.Location = new System.Drawing.Point(4, 22);
            this.tabPage_browse.Name = "tabPage_browse";
            this.tabPage_browse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_browse.Size = new System.Drawing.Size(621, 631);
            this.tabPage_browse.TabIndex = 0;
            this.tabPage_browse.Text = "Browse";
            this.tabPage_browse.UseVisualStyleBackColor = true;
            // 
            // groupBox_browse
            // 
            this.groupBox_browse.Controls.Add(this.label_path);
            this.groupBox_browse.Controls.Add(this.button_browse);
            this.groupBox_browse.Location = new System.Drawing.Point(6, 6);
            this.groupBox_browse.Name = "groupBox_browse";
            this.groupBox_browse.Size = new System.Drawing.Size(557, 100);
            this.groupBox_browse.TabIndex = 2;
            this.groupBox_browse.TabStop = false;
            this.groupBox_browse.Text = "Select Image File";
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(6, 41);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 1;
            this.button_browse.Text = "Browse...";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(6, 26);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(19, 12);
            this.label_path.TabIndex = 2;
            this.label_path.Text = "C:\\";
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_browse);
            this.tabControl_main.Controls.Add(this.tabPage_selectCenter);
            this.tabControl_main.Controls.Add(this.tabPage_selectRoi);
            this.tabControl_main.Location = new System.Drawing.Point(12, 12);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(629, 657);
            this.tabControl_main.TabIndex = 3;
            this.tabControl_main.SelectedIndexChanged += new System.EventHandler(this.tabControl_main_SelectedIndexChanged);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.pictureBox_full);
            this.Name = "form_main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_full)).EndInit();
            this.tabPage_selectRoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_part)).EndInit();
            this.tabPage_browse.ResumeLayout(false);
            this.groupBox_browse.ResumeLayout(false);
            this.groupBox_browse.PerformLayout();
            this.tabControl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_full;
        private System.Windows.Forms.TabPage tabPage_selectRoi;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.PictureBox pictureBox_part;
        private System.Windows.Forms.TabPage tabPage_selectCenter;
        private System.Windows.Forms.TabPage tabPage_browse;
        private System.Windows.Forms.GroupBox groupBox_browse;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TabControl tabControl_main;
    }
}

