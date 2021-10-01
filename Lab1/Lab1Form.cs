using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Lab1Form : Form
    {
        private Image _image;
        private Bitmap _sizedImage;
        private string _pathToImage;
        private PictureBox _box;
        private double _scale;

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
                _box = new PictureBox();

                _box.Image = _image;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Ошибка чтения картинки");
                return;
            }

            _sizedImage = new Bitmap(_image);
            _scale = 1.0;
            UpdateBackgroundImage();
        }

        private void Lab1Form_Resize(object sender, EventArgs e)
        {
            UpdateBackgroundImage();
        }

        private void Lab1Form_Load(object sender, EventArgs e)
        {
            //Минимальный размер окна
            MinimumSize = new Size(500, 300);
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

            _sizedImage.Save(_pathToImage);
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
            _sizedImage.Save(saveDialog.FileName);
            _image = _sizedImage;
        }

        private void поЧасовойToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate90FlipNone);
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
            SetScale(1);
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

        private void UpdateBackgroundImage()
        {
            var temppp = 0.98;
            if (_image == null)
            {
                ImagePanel.Size = new Size((int) (Size.Width * temppp), (int) (Size.Height * temppp));
                return;
            }

            if(Size.Height > _sizedImage.Size.Height && Size.Width > _sizedImage.Size.Width || _image == null)
                ImagePanel.Size = new Size(_sizedImage.Width, _sizedImage.Height);
            if (Size.Height < _sizedImage.Size.Height && Size.Width > _sizedImage.Size.Width)
                ImagePanel.Size = new Size(_sizedImage.Width, (int) (Size.Height * temppp));
            if (Size.Height > _sizedImage.Size.Height && Size.Width < _sizedImage.Size.Width)
                ImagePanel.Size = new Size((int) (Size.Width * temppp), _sizedImage.Height);
            if (Size.Height < _sizedImage.Size.Height && Size.Width < _sizedImage.Size.Width)
                ImagePanel.Size = new Size((int) (Size.Width * temppp), (int) (Size.Height * temppp));
            
            ImagePanel.BackgroundImage = _sizedImage;

            ImagePanel.AutoScroll = true;
            ImagePanel.AutoScrollMinSize = _image.Size;
        }

        /// <summary>
        /// Изменение машстаба
        /// </summary>
        /// <param name="multiplier">Множитель изменения масштаба</param>
        private void SetScale(double multiplier)
        {
            if (_image.IsNull())
            {
                return;
            }

            _scale = _scale * multiplier;

            _sizedImage = new Bitmap(_image,
                new Size((int) (_image.Width * _scale), (int) (_image.Height * _scale)));
            UpdateBackgroundImage();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(1.25);
            UpdateBackgroundImage();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(1.5);
            UpdateBackgroundImage();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(1.75);
            UpdateBackgroundImage();
        }

        private void вернутьИсходныйМасштабToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            _sizedImage = new Bitmap(_image);
            _scale = 1.0;
            UpdateBackgroundImage();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(0.75);
            UpdateBackgroundImage();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(0.5);
            UpdateBackgroundImage();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(0.25);
            UpdateBackgroundImage();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2_Click(sender, e);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            toolStripMenuItem6_Click(sender, e);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            вернутьИсходныйМасштабToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            _box.Show();
        }

        private void ImagePanel_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateBackgroundImage();
        }
    }
}