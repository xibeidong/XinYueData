namespace XinyueData
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_sp = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_inpath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_num = new System.Windows.Forms.TextBox();
            this.textBox_level = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_backup = new System.Windows.Forms.Label();
            this.label_plan_state = new System.Windows.Forms.Label();
            this.button_plan_start = new System.Windows.Forms.Button();
            this.button_path2 = new System.Windows.Forms.Button();
            this.button_path1 = new System.Windows.Forms.Button();
            this.button_bak_begin = new System.Windows.Forms.Button();
            this.textBox_path1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_path2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择文件夹";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "开始执行";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(427, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(347, 605);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "分割符（可为空）：";
            // 
            // textBox_sp
            // 
            this.textBox_sp.Location = new System.Drawing.Point(139, 83);
            this.textBox_sp.Name = "textBox_sp";
            this.textBox_sp.Size = new System.Drawing.Size(103, 21);
            this.textBox_sp.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(34, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "检查数据库";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox_inpath);
            this.groupBox1.Controls.Add(this.textBox_sp);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 171);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入到数据库";
            // 
            // textBox_inpath
            // 
            this.textBox_inpath.Location = new System.Drawing.Point(139, 49);
            this.textBox_inpath.Name = "textBox_inpath";
            this.textBox_inpath.Size = new System.Drawing.Size(217, 21);
            this.textBox_inpath.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_num);
            this.groupBox2.Controls.Add(this.textBox_level);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(24, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 151);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "从数据库导出";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "所有记录设置为未导出状态=>";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(212, 122);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "重置";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "导出数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "心悦等级：";
            // 
            // textBox_num
            // 
            this.textBox_num.Location = new System.Drawing.Point(91, 73);
            this.textBox_num.Name = "textBox_num";
            this.textBox_num.Size = new System.Drawing.Size(100, 21);
            this.textBox_num.TabIndex = 4;
            this.textBox_num.Text = "1000";
            // 
            // textBox_level
            // 
            this.textBox_level.Location = new System.Drawing.Point(91, 28);
            this.textBox_level.Name = "textBox_level";
            this.textBox_level.Size = new System.Drawing.Size(100, 21);
            this.textBox_level.TabIndex = 4;
            this.textBox_level.Text = "1";
            this.textBox_level.TextChanged += new System.EventHandler(this.textBox_level_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(212, 73);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "导出";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "查询总数";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_backup);
            this.groupBox3.Controls.Add(this.label_plan_state);
            this.groupBox3.Controls.Add(this.button_plan_start);
            this.groupBox3.Controls.Add(this.button_path2);
            this.groupBox3.Controls.Add(this.button_path1);
            this.groupBox3.Controls.Add(this.button_bak_begin);
            this.groupBox3.Controls.Add(this.textBox_path1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_path2);
            this.groupBox3.Location = new System.Drawing.Point(24, 449);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 168);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "计划";
            // 
            // label_backup
            // 
            this.label_backup.AutoSize = true;
            this.label_backup.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_backup.Location = new System.Drawing.Point(114, 115);
            this.label_backup.Name = "label_backup";
            this.label_backup.Size = new System.Drawing.Size(77, 12);
            this.label_backup.TabIndex = 6;
            this.label_backup.Text = "没有备份记录";
            // 
            // label_plan_state
            // 
            this.label_plan_state.AutoSize = true;
            this.label_plan_state.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_plan_state.Location = new System.Drawing.Point(113, 150);
            this.label_plan_state.Name = "label_plan_state";
            this.label_plan_state.Size = new System.Drawing.Size(125, 12);
            this.label_plan_state.TabIndex = 6;
            this.label_plan_state.Text = "状态：定时任务未开启";
            // 
            // button_plan_start
            // 
            this.button_plan_start.Location = new System.Drawing.Point(10, 145);
            this.button_plan_start.Name = "button_plan_start";
            this.button_plan_start.Size = new System.Drawing.Size(85, 23);
            this.button_plan_start.TabIndex = 5;
            this.button_plan_start.Text = "开启定时任务";
            this.button_plan_start.UseVisualStyleBackColor = true;
            this.button_plan_start.Click += new System.EventHandler(this.button_plan_start_Click);
            // 
            // button_path2
            // 
            this.button_path2.Location = new System.Drawing.Point(10, 70);
            this.button_path2.Name = "button_path2";
            this.button_path2.Size = new System.Drawing.Size(75, 23);
            this.button_path2.TabIndex = 5;
            this.button_path2.Text = "选择路径2：";
            this.button_path2.UseVisualStyleBackColor = true;
            this.button_path2.Click += new System.EventHandler(this.button_path2_Click);
            // 
            // button_path1
            // 
            this.button_path1.Location = new System.Drawing.Point(10, 41);
            this.button_path1.Name = "button_path1";
            this.button_path1.Size = new System.Drawing.Size(75, 23);
            this.button_path1.TabIndex = 5;
            this.button_path1.Text = "选择路径1：";
            this.button_path1.UseVisualStyleBackColor = true;
            this.button_path1.Click += new System.EventHandler(this.button_path1_Click);
            // 
            // button_bak_begin
            // 
            this.button_bak_begin.Location = new System.Drawing.Point(10, 110);
            this.button_bak_begin.Name = "button_bak_begin";
            this.button_bak_begin.Size = new System.Drawing.Size(85, 23);
            this.button_bak_begin.TabIndex = 5;
            this.button_bak_begin.Text = "开始备份";
            this.button_bak_begin.UseVisualStyleBackColor = true;
            this.button_bak_begin.Click += new System.EventHandler(this.button_bak_begin_Click);
            // 
            // textBox_path1
            // 
            this.textBox_path1.Location = new System.Drawing.Point(91, 43);
            this.textBox_path1.Name = "textBox_path1";
            this.textBox_path1.Size = new System.Drawing.Size(265, 21);
            this.textBox_path1.TabIndex = 4;
            this.textBox_path1.TextChanged += new System.EventHandler(this.textBox_level_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(81, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "提示：从路径1备份到路径2，路径1的内容会被清理";
            // 
            // textBox_path2
            // 
            this.textBox_path2.Location = new System.Drawing.Point(91, 70);
            this.textBox_path2.Name = "textBox_path2";
            this.textBox_path2.Size = new System.Drawing.Size(265, 21);
            this.textBox_path2.TabIndex = 4;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(281, 29);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "测试Excel";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 639);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_sp;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_num;
        private System.Windows.Forms.TextBox textBox_level;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox_inpath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_plan_start;
        private System.Windows.Forms.Button button_bak_begin;
        private System.Windows.Forms.TextBox textBox_path1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_path2;
        private System.Windows.Forms.Button button_path2;
        private System.Windows.Forms.Button button_path1;
        private System.Windows.Forms.Label label_plan_state;
        private System.Windows.Forms.Label label_backup;
        private System.Windows.Forms.Button button7;
    }
}

