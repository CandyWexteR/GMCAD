using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1;
using Lab2.Filters;

namespace Lab2
{
    public partial class Lab2Form : Form
    {
        private const string EmbossExists = "Рельеф (V)";
        private const string EmbossDoesNotExists = "Рельеф";
        private const string SharpExists = "Четкость (V)";
        private const string SharpDoesNotExists = "Четкость";

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

        private int _brightness;

        public ManualResetEvent EventDoTransform = new ManualResetEvent(false);
        private int _executedPercent = 0;
        private bool _emboss;
        private bool _sharp;


        public Lab2Form()
        {
            InitializeComponent();
            _brightness = 0;
            рельефToolStripMenuItem.Text = EmbossDoesNotExists;
            _emboss = false;
            четкостьToolStripMenuItem.Text = SharpDoesNotExists;
            _sharp = false;
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
            рельефToolStripMenuItem.Text = EmbossDoesNotExists;
            _emboss = false;
            четкостьToolStripMenuItem.Text = SharpDoesNotExists;
            _sharp = false;
            _brightness = 0;
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

            рельефToolStripMenuItem.Text = EmbossDoesNotExists;
            _emboss = false;
            четкостьToolStripMenuItem.Text = SharpDoesNotExists;
            _sharp = false;
            _brightness = 0;

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
            _scale = 0;
            _brightness = 0;
            рельефToolStripMenuItem.Text = EmbossDoesNotExists;
            _emboss = false;
            четкостьToolStripMenuItem.Text = SharpDoesNotExists;
            _sharp = false;
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

            _sizedImage = new Bitmap(_image,
                new Size((int)(_image.Width * _scale), (int)(_image.Height * _scale)));

            if (_brightness != 0)
            {
                var filter = new Brightness();

                filter.Init(_brightness);
                var filtered = FilterBitmap(filter);
                if (filtered != null)
                    _sizedImage = filtered;
            }

            if (_emboss)
            {
                var filter = new EmbossFilter();
                var filtered = FilterBitmap(filter);

                if (filtered != null)
                    _sizedImage = filtered;
            }

            if (_sharp)
            {
                var filter = new SharpFilter();
                var filtered = FilterBitmap(filter);

                if (filtered != null)
                    _sizedImage = filtered;
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

        private void рельефToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (рельефToolStripMenuItem.Text == EmbossExists)
            {
                рельефToolStripMenuItem.Text = EmbossDoesNotExists;
                _emboss = false;
            }
            else
            {
                рельефToolStripMenuItem.Text = EmbossExists;
                _emboss = true;
            }

            UpdateImage();
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _executedPercent = 0;
            var form = new BrightnessScaleForm();
            if (form.ShowDialog(this) != DialogResult.OK) return;

            _brightness = form.ScrollValue;
            UpdateImage();
        }


        private Bitmap FilterBitmap(FilterBase filter)
        {
            var pDbm = (Bitmap)_sizedImage.Clone();

            if (!filter.SetBuffers(_sizedImage, pDbm))
            {
                return null;
            }

            var width = (ushort)_sizedImage.Width;
            var height = (ushort)_sizedImage.Height;

            for (ushort y = 0; y < height; y++)
            {
                Interlocked.Exchange(ref _executedPercent, 100 * y / height);
                if (EventDoTransform.WaitOne(0, true))
                {
                    filter.ReleaseBuffers();
                    return null;
                }

                for (ushort x = 0; x < width; x++)
                {
                    filter.TransformPix(x, y);
                }
            }

            return (Bitmap)pDbm.Clone();
        }

        private void четкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (четкостьToolStripMenuItem.Text == SharpDoesNotExists)
            {
                четкостьToolStripMenuItem.Text = SharpExists;
                _sharp = true;
            }
            else
            {
                четкостьToolStripMenuItem.Text = SharpDoesNotExists;
                _sharp = false;
            }
            UpdateImage();
        }
    }
}