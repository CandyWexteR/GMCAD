using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Lab1Form : Form
    {
        /// <summary>
        /// Исходное изображение
        /// </summary>
        private Image _image;
        /// <summary>
        /// Измененное изображение, построенное на основе <see cref="_image"/>
        /// </summary>
        private Bitmap _sizedImage;
        /// <summary>
        /// Путь к исходному изображению
        /// </summary>
        private string _pathToImage;
        /// <summary>
        /// Величина масштаба.
        /// </summary>
        private double _scale;

        public Lab1Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Функция открытия файла. Загружает данные в <see cref="_image"/> и обновляет изображение <see cref="_sizedImage"/>.
        /// После этого наносит <see cref="_sizedImage"/> на <see cref="ImagePictureBox"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            _sizedImage = new Bitmap(_image);
            _scale = 1.0;
            UpdateImage();
        }

        private void Lab1Form_Resize(object sender, EventArgs e)
        {
            UpdateImage();
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

        /// <summary>
        /// Функция поворота изображения. Поворачивает только исходное в памяти.
        /// </summary>
        /// <param name="type"></param>
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

        /// <summary>
        /// Нанесение изображения из <see cref="_sizedImage"/> на <see cref="ImagePictureBox"/>.
        /// </summary>
        private void UpdateImage()
        {
            if (_image == null)
            {
                return;
            }
            
            ImagePictureBox.Image = _sizedImage;

            ImagePanel.AutoScroll = true;
            ImagePanel.AutoScrollMinSize = _sizedImage.Size;
            ImagePanel.Invalidate();
        }

        /// <summary>
        /// Изменение машстаба изображения. Меняется только изображение <see cref="_sizedImage"/>.
        /// </summary>
        /// <param name="multiplier">Множитель изменения масштаба</param>
        private void SetScale(double multiplier)
        {
            if (_image.IsNull())
            {
                return;
            }

            _scale *= multiplier;

            _sizedImage = new Bitmap(_image,
                new Size((int) (_image.Width * _scale), (int) (_image.Height * _scale)));
            UpdateImage();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(1.25);
            UpdateImage();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(1.5);
            UpdateImage();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(1.75);
            UpdateImage();
        }

        private void вернутьИсходныйМасштабToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            _sizedImage = new Bitmap(_image);
            _scale = 1.0;
            UpdateImage();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(0.75);
            UpdateImage();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(0.5);
            UpdateImage();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (_image.IsNull())
            {
                return;
            }

            SetScale(0.25);
            UpdateImage();
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

        private void ImagePictureBox_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateImage();
        }
    }
}