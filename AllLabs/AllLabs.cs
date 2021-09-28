using System;
using System.Windows.Forms;
using Lab1;

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
            
            lab1.Show();
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
    }
}