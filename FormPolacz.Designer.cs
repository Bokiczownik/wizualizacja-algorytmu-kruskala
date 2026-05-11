namespace projekt2algorytmy
{
    partial class FormPolacz
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            btnOk = new Button();
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(173, 25);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(191, 23);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(173, 25);
            comboBox2.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(370, 23);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 3);
            label1.Name = "label1";
            label1.Size = new Size(86, 17);
            label1.TabIndex = 3;
            label1.Text = "wierzchołek 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 3);
            label2.Name = "label2";
            label2.Size = new Size(86, 17);
            label2.TabIndex = 4;
            label2.Text = "wierzchołek 2";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(370, 88);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(85, 25);
            numericUpDown1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 68);
            label3.Name = "label3";
            label3.Size = new Size(39, 17);
            label3.TabIndex = 6;
            label3.Text = "waga";
            // 
            // FormPolacz
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 137);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Name = "FormPolacz";
            Text = "FormPolacz";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button btnOk;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
    }
}