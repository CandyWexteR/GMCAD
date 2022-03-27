using System;
using System.Windows.Forms;

namespace Lab2
{
    public partial class BrightnessScaleForm : Form
    {
        public BrightnessScaleForm()
        {
            InitializeComponent();
        }

        public int ScrollValue => hScrollBar1.Value;

        private void BrightnessScaleForm_Load(object sender, EventArgs e)
        {
            label1.Text = "0";
            hScrollBar1.Value = 0;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = hScrollBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BrightnessScaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }
    }
}