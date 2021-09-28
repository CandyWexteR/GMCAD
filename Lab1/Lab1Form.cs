using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Lab1Form : Form
    {
        private Image _image;
        private string _pathToImage;
        
        public Lab1Form()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                _image = Image.FromFile(openDialog.FileName);
                _pathToImage = openDialog.FileName;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Ошибка чтения картинки");
                return;
            }

            ImagePanel.AutoScroll = true;
            ImagePanel.AutoScrollMinSize = _image.Size;
            ImagePanel.BackgroundImage = _image;
        }

        private void Lab1Form_Resize(object sender, EventArgs e)
        {
            ImagePanel.Size = Size;
        }

        private void Lab1Form_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }
            
            _image.Save(_pathToImage);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }
            
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JPG files (*.jpg)|*.jpg|JPEG files (*.jpeg)|*.jpeg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2 ;
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            _image.Save(saveDialog.FileName);
        }

        private void поЧасовойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate90FlipNone);
        }

        private void противЧасовойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate270FlipNone);
        }

        private void поГоризонталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.RotateNoneFlipX);
        }

        private void поВертикалиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.RotateNoneFlipY);
        }

        private void RotateImage(RotateFlipType type)
        {
            if (_image.IsNull())
            {
                return;
            }
            
            _image.RotateFlip(type);
        }
    }
}