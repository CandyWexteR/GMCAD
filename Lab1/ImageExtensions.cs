using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public static class ImageExtensions
    {
        public static bool IsNull(this Image image)
        {
            if (image != default) return false;
            MessageBox.Show("Сначала загрузите изображение!");
            return true;

        }
    }
}