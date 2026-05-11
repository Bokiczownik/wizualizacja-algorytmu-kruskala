namespace projekt2algorytmy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Dodaj_wierzcholek_btn = new Button();
            Polacz_wierzcholki_btn = new Button();
            oblicz_droge_btn = new Button();
            clear_all_btn = new Button();
            panel1 = new Panel();
            listBox1 = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            Dodaj_wiele_wierzcholkow_btn = new Button();
            Polacz_wiele_btn = new Button();
            SuspendLayout();
            // 
            // Dodaj_wierzcholek_btn
            // 
            Dodaj_wierzcholek_btn.Location = new Point(24, 13);
            Dodaj_wierzcholek_btn.Name = "Dodaj_wierzcholek_btn";
            Dodaj_wierzcholek_btn.Size = new Size(190, 23);
            Dodaj_wierzcholek_btn.TabIndex = 0;
            Dodaj_wierzcholek_btn.Text = "Dodaj wierzchołki";
            Dodaj_wierzcholek_btn.UseVisualStyleBackColor = true;
            Dodaj_wierzcholek_btn.Click += Dodaj_wierzcholek_btn_Click;
            // 
            // Polacz_wierzcholki_btn
            // 
            Polacz_wierzcholki_btn.Location = new Point(24, 42);
            Polacz_wierzcholki_btn.Name = "Polacz_wierzcholki_btn";
            Polacz_wierzcholki_btn.Size = new Size(190, 23);
            Polacz_wierzcholki_btn.TabIndex = 1;
            Polacz_wierzcholki_btn.Text = "Połącz wierzchołki";
            Polacz_wierzcholki_btn.UseVisualStyleBackColor = true;
            Polacz_wierzcholki_btn.Click += Polacz_wierzcholki_btn_Click;
            // 
            // oblicz_droge_btn
            // 
            oblicz_droge_btn.Location = new Point(24, 129);
            oblicz_droge_btn.Name = "oblicz_droge_btn";
            oblicz_droge_btn.Size = new Size(190, 23);
            oblicz_droge_btn.TabIndex = 2;
            oblicz_droge_btn.Text = "Najkrótsza droga";
            oblicz_droge_btn.UseVisualStyleBackColor = true;
            oblicz_droge_btn.Click += oblicz_droge_btn_Click;
            // 
            // clear_all_btn
            // 
            clear_all_btn.Location = new Point(24, 158);
            clear_all_btn.Name = "clear_all_btn";
            clear_all_btn.Size = new Size(190, 23);
            clear_all_btn.TabIndex = 3;
            clear_all_btn.Text = "Wyszyść wszystko";
            clear_all_btn.UseVisualStyleBackColor = true;
            clear_all_btn.Click += clear_all_btn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(247, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 426);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // listBox1
            // 
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(779, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(79, 429);
            listBox1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            contextMenuStrip1.Text = "Usuń wierzchołek";
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 187);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(229, 251);
            textBox1.TabIndex = 6;
            // 
            // Dodaj_wiele_wierzcholkow_btn
            // 
            Dodaj_wiele_wierzcholkow_btn.Location = new Point(24, 71);
            Dodaj_wiele_wierzcholkow_btn.Name = "Dodaj_wiele_wierzcholkow_btn";
            Dodaj_wiele_wierzcholkow_btn.Size = new Size(190, 23);
            Dodaj_wiele_wierzcholkow_btn.TabIndex = 7;
            Dodaj_wiele_wierzcholkow_btn.Text = "Dodaj wiele wierzchołków";
            Dodaj_wiele_wierzcholkow_btn.UseVisualStyleBackColor = true;
            Dodaj_wiele_wierzcholkow_btn.Click += Dodaj_wiele_wierzcholkow_btn_Click;
            // 
            // Polacz_wiele_btn
            // 
            Polacz_wiele_btn.Location = new Point(24, 100);
            Polacz_wiele_btn.Name = "Polacz_wiele_btn";
            Polacz_wiele_btn.Size = new Size(190, 23);
            Polacz_wiele_btn.TabIndex = 8;
            Polacz_wiele_btn.Text = "Połącz wiele wierzchołków";
            Polacz_wiele_btn.UseVisualStyleBackColor = true;
            Polacz_wiele_btn.Click += Polacz_wiele_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 450);
            Controls.Add(textBox1);
            Controls.Add(Polacz_wiele_btn);
            Controls.Add(Dodaj_wiele_wierzcholkow_btn);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(clear_all_btn);
            Controls.Add(oblicz_droge_btn);
            Controls.Add(Polacz_wierzcholki_btn);
            Controls.Add(Dodaj_wierzcholek_btn);
            Name = "Form1";
            Text = "Wizualizacja algorytmu Kruskala";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Dodaj_wierzcholek_btn;
        private Button Polacz_wierzcholki_btn;
        private Button oblicz_droge_btn;
        private Button clear_all_btn;
        private Panel panel1;
        private ListBox listBox1;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private Button Dodaj_wiele_wierzcholkow_btn;
        private Button Polacz_wiele_btn;
    }
}
