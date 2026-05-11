using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projekt2algorytmy
{
    public partial class FormPolacz : Form
    {
        public string StartowaNazwa { get; private set; }
        public string DocelowaNazwa { get; private set; }
        public int Waga { get; private set; }

        public FormPolacz(List<string> nazwyWierzcholkow)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(nazwyWierzcholkow.ToArray());
            comboBox2.Items.AddRange(nazwyWierzcholkow.ToArray());

            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 1) comboBox2.SelectedIndex = 1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Pobieramy dane z kontrolek
            StartowaNazwa = comboBox1.SelectedItem?.ToString();
            DocelowaNazwa = comboBox2.SelectedItem?.ToString();
            Waga = (int)numericUpDown1.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}