using System;
using System.Windows.Forms;
using Lab1;
using Lab2;

namespace AllLabs
{
    public partial class AllLabs : Form
    {
        public AllLabs()
        {
            InitializeComponent();
        }

        private void Lab1Button_Click(object sender, EventArgs e)
        {
            var lab1 = new Lab1Form();
            
            lab1.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AllLabs_Load(object sender, EventArgs e)
        {
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lab2 = new Lab2Form();
            
            lab2.ShowDialog(this);
        }
    }
}