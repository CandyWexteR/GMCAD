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

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
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
            ImagePanel.AutoSize = true;
            ImagePanel.BackgroundImage = _image;
        }

        private void Lab1Form_Resize(object sender, EventArgs e)
        {
            ImagePanel.Size = Size;
        }

        private void Lab1Form_Load(object sender, EventArgs e)
        {
        }

        private void закрытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            _image.Save(_pathToImage);
        }

        private void сохранитьКакToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter =
                "JPG files (*.jpg)|*.jpg|JPEG files (*.jpeg)|*.jpeg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            _image.Save(saveDialog.FileName);
        }

        private void поЧасовойToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate90FlipNone);
            ImagePanel.Size = _image.Size;
        }

        private void противЧасовойToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate270FlipNone);
        }

        private void поГоризонталиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.RotateNoneFlipX);
        }

        private void поВертикалиToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            ImagePanel.Size = _image.Size;
            ImagePanel.BackgroundImage = _image;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            противЧасовойToolStripMenuItem_Click_1(sender, e);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            поЧасовойToolStripMenuItem_Click_1(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            поГоризонталиToolStripMenuItem_Click_1(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            поВертикалиToolStripMenuItem_Click_1(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            открытьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem_Click_1(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            сохранитьКакToolStripMenuItem_Click_1(sender, e);
        }
    }
}