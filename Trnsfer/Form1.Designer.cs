namespace Trnsfer
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
            this.PDATables = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.OraTables = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PDAFields = new System.Windows.Forms.ListBox();
            this.OraFields = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SelectText = new System.Windows.Forms.TextBox();
            this.DeleteText = new System.Windows.Forms.TextBox();
            this.ClearText = new System.Windows.Forms.TextBox();
            this.InsertText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectPDAText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.FieldList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pDABaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PDATables
            // 
            this.PDATables.FormattingEnabled = true;
            this.PDATables.Location = new System.Drawing.Point(15, 38);
            this.PDATables.Name = "PDATables";
            this.PDATables.Size = new System.Drawing.Size(137, 368);
            this.PDATables.TabIndex = 0;
            this.PDATables.SelectedIndexChanged += new System.EventHandler(this.PDATables_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(502, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OraTables
            // 
            this.OraTables.FormattingEnabled = true;
            this.OraTables.Location = new System.Drawing.Point(158, 38);
            this.OraTables.Name = "OraTables";
            this.OraTables.Size = new System.Drawing.Size(136, 537);
            this.OraTables.TabIndex = 2;
            this.OraTables.SelectedIndexChanged += new System.EventHandler(this.OraTables_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "<<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(161, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = ">>>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PDAFields
            // 
            this.PDAFields.FormattingEnabled = true;
            this.PDAFields.Location = new System.Drawing.Point(158, 103);
            this.PDAFields.Name = "PDAFields";
            this.PDAFields.Size = new System.Drawing.Size(143, 303);
            this.PDAFields.TabIndex = 5;
            // 
            // OraFields
            // 
            this.OraFields.FormattingEnabled = true;
            this.OraFields.Location = new System.Drawing.Point(307, 103);
            this.OraFields.Name = "OraFields";
            this.OraFields.Size = new System.Drawing.Size(149, 303);
            this.OraFields.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 412);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "IsLight";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(78, 412);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(82, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "NeedExport";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(243, 412);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(307, 412);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "<<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // SelectText
            // 
            this.SelectText.Location = new System.Drawing.Point(108, 12);
            this.SelectText.Name = "SelectText";
            this.SelectText.Size = new System.Drawing.Size(347, 20);
            this.SelectText.TabIndex = 12;
            // 
            // DeleteText
            // 
            this.DeleteText.Location = new System.Drawing.Point(108, 64);
            this.DeleteText.Name = "DeleteText";
            this.DeleteText.Size = new System.Drawing.Size(347, 20);
            this.DeleteText.TabIndex = 13;
            // 
            // ClearText
            // 
            this.ClearText.Location = new System.Drawing.Point(108, 90);
            this.ClearText.Name = "ClearText";
            this.ClearText.Size = new System.Drawing.Size(347, 20);
            this.ClearText.TabIndex = 14;
            // 
            // InsertText
            // 
            this.InsertText.Location = new System.Drawing.Point(108, 116);
            this.InsertText.Name = "InsertText";
            this.InsertText.Size = new System.Drawing.Size(347, 20);
            this.InsertText.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "QryDelete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "QryClear";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "QryInsert";
            // 
            // SelectPDAText
            // 
            this.SelectPDAText.Location = new System.Drawing.Point(108, 38);
            this.SelectPDAText.Name = "SelectPDAText";
            this.SelectPDAText.Size = new System.Drawing.Size(347, 20);
            this.SelectPDAText.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "QrySelectPDA";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(377, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 22);
            this.button6.TabIndex = 22;
            this.button6.Text = "Применить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // FieldList
            // 
            this.FieldList.FormattingEnabled = true;
            this.FieldList.Location = new System.Drawing.Point(22, 103);
            this.FieldList.Name = "FieldList";
            this.FieldList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.FieldList.Size = new System.Drawing.Size(130, 472);
            this.FieldList.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Добавленные поля";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Доступные поля";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Поля таблицы Oracle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Таблицы Oracle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "QrySelectBM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "ID";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.SelectText);
            this.panel1.Controls.Add(this.SelectPDAText);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.DeleteText);
            this.panel1.Controls.Add(this.ClearText);
            this.panel1.Controls.Add(this.InsertText);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 157);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.PDATables);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.PDAFields);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.OraFields);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 446);
            this.panel2.TabIndex = 31;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(210, 15);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(125, 23);
            this.button9.TabIndex = 32;
            this.button9.Text = "Вашлшэбны гузик";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(158, 411);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 23);
            this.button8.TabIndex = 31;
            this.button8.Text = ">>>>";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(403, 412);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(52, 23);
            this.button7.TabIndex = 30;
            this.button7.Text = "<<<<";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.FieldList);
            this.panel3.Controls.Add(this.OraTables);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(492, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 585);
            this.panel3.TabIndex = 32;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(210, 44);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(125, 23);
            this.button10.TabIndex = 33;
            this.button10.Text = "Занести типы";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDABaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pDABaseToolStripMenuItem
            // 
            this.pDABaseToolStripMenuItem.Name = "pDABaseToolStripMenuItem";
            this.pDABaseToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.pDABaseToolStripMenuItem.Text = "PDABase";
            this.pDABaseToolStripMenuItem.Click += new System.EventHandler(this.pDABaseToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 637);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PDATables;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox OraTables;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox PDAFields;
        private System.Windows.Forms.ListBox OraFields;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox SelectText;
        private System.Windows.Forms.TextBox DeleteText;
        private System.Windows.Forms.TextBox ClearText;
        private System.Windows.Forms.TextBox InsertText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SelectPDAText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox FieldList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pDABaseToolStripMenuItem;
    }
}

