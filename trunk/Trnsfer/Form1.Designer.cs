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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectPDAText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PDATables
            // 
            this.PDATables.FormattingEnabled = true;
            this.PDATables.Location = new System.Drawing.Point(10, 51);
            this.PDATables.Name = "PDATables";
            this.PDATables.Size = new System.Drawing.Size(137, 368);
            this.PDATables.TabIndex = 0;
            this.PDATables.SelectedIndexChanged += new System.EventHandler(this.PDATables_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-3, -3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OraTables
            // 
            this.OraTables.FormattingEnabled = true;
            this.OraTables.Location = new System.Drawing.Point(554, 51);
            this.OraTables.Name = "OraTables";
            this.OraTables.Size = new System.Drawing.Size(136, 368);
            this.OraTables.TabIndex = 2;
            this.OraTables.SelectedIndexChanged += new System.EventHandler(this.OraTables_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(502, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "<<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(153, 63);
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
            this.PDAFields.Location = new System.Drawing.Point(184, 168);
            this.PDAFields.Name = "PDAFields";
            this.PDAFields.Size = new System.Drawing.Size(143, 251);
            this.PDAFields.TabIndex = 5;
            // 
            // OraFields
            // 
            this.OraFields.FormattingEnabled = true;
            this.OraFields.Location = new System.Drawing.Point(366, 168);
            this.OraFields.Name = "OraFields";
            this.OraFields.Size = new System.Drawing.Size(149, 251);
            this.OraFields.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 429);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "IsLight";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(65, 429);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(82, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "NeedExport";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(269, 425);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(366, 425);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "<<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // SelectText
            // 
            this.SelectText.Location = new System.Drawing.Point(104, 468);
            this.SelectText.Name = "SelectText";
            this.SelectText.Size = new System.Drawing.Size(508, 20);
            this.SelectText.TabIndex = 12;
            // 
            // DeleteText
            // 
            this.DeleteText.Location = new System.Drawing.Point(104, 523);
            this.DeleteText.Name = "DeleteText";
            this.DeleteText.Size = new System.Drawing.Size(508, 20);
            this.DeleteText.TabIndex = 13;
            // 
            // ClearText
            // 
            this.ClearText.Location = new System.Drawing.Point(104, 549);
            this.ClearText.Name = "ClearText";
            this.ClearText.Size = new System.Drawing.Size(508, 20);
            this.ClearText.TabIndex = 14;
            // 
            // InsertText
            // 
            this.InsertText.Location = new System.Drawing.Point(104, 575);
            this.InsertText.Name = "InsertText";
            this.InsertText.Size = new System.Drawing.Size(508, 20);
            this.InsertText.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "QrySelectBM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "QryDelete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "QryClear";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 582);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "QryInsert";
            // 
            // SelectPDAText
            // 
            this.SelectPDAText.Location = new System.Drawing.Point(104, 495);
            this.SelectPDAText.Name = "SelectPDAText";
            this.SelectPDAText.Size = new System.Drawing.Size(508, 20);
            this.SelectPDAText.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "QrySelectPDA";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(618, 573);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 22);
            this.button6.TabIndex = 22;
            this.button6.Text = "Применить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 618);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelectPDAText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InsertText);
            this.Controls.Add(this.ClearText);
            this.Controls.Add(this.DeleteText);
            this.Controls.Add(this.SelectText);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.OraFields);
            this.Controls.Add(this.PDAFields);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OraTables);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PDATables);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SelectPDAText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
    }
}

