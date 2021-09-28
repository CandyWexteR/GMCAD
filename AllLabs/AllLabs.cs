using System;
using System.Windows.Forms;
using Lab1;

namespace AllLabs
{
    public partial class AllLabs : Form
    {
        private Lab1Form _lab1;
        public AllLabs()
        {
            InitializeComponent();
            _lab1 = null;
        }

        private void Lab1Button_Click(object sender, EventArgs e)
        {
            if(_lab1==null)
                _lab1 = new Lab1Form();
            
            _lab1.Show();
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