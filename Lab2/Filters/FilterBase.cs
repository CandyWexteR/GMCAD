using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Lab2.Filters
{
	public abstract class FilterBase
	{
        public static readonly int Source = 0;
        public static readonly int Dest = 1;

        private readonly Bitmap[] _bitmaps;
        // Bitmap data
        protected BitmapData[] Buffer;


        protected FilterBase()
        {
            _bitmaps = new Bitmap[2];
            Buffer = new BitmapData[2];
        }

        public static unsafe byte GetY(byte* pPix)
        {
            return ((byte)(0.11 * pPix[0] + 0.59 * pPix[1] + 0.3 * pPix[2]));
        }


        public bool SetBuffers(Bitmap source, Bitmap dest)
        {
            _bitmaps[Source] = source;
            _bitmaps[Dest] = dest;

            if (_bitmaps[Source] == null || _bitmaps[Dest] == null)
                return false;

            // return result
            var result = false;

            try
            {
                // Getting direct access to data            
                if (// indicating that source read only
                    (Buffer[Source] = _bitmaps[Source].LockBits(new Rectangle(Point.Empty, _bitmaps[Source].Size),
                    ImageLockMode.ReadOnly, _bitmaps[Source].PixelFormat)) == null ||
                    // indicating that destination write mode
                    (Buffer[Dest] = _bitmaps[Dest].LockBits(new Rectangle(Point.Empty, _bitmaps[Dest].Size),
                    ImageLockMode.WriteOnly, _bitmaps[Dest].PixelFormat)) == null)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool ReleaseBuffers()
        {
            // Check
            if (_bitmaps[Source] == null || _bitmaps[Dest] == null)
                return false;
            // Releasing buffers
            _bitmaps[Source].UnlockBits(Buffer[Source]);
            _bitmaps[Dest].UnlockBits(Buffer[Dest]);

            return true;
        }

        /// <summary>
        /// Получить указатель на пиксель
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public unsafe byte* GetPixelPointer(ushort x, int y, int source)
        {
            if (source != 1 && source != 0)
                return null;

            if (Buffer[source].Scan0 == IntPtr.Zero || x >= Buffer[source].Width || y >= Buffer[source].Height)
                return null;

            // Byte per pixel calculation
            byte bpp = 0;

            unchecked
            {
                bpp = (byte)(((byte)((int)Buffer[source].PixelFormat >> 8)) / 8);
            }

            // Address determination
            return ((byte*)Buffer[source].Scan0) + Buffer[source].Stride * y + x * bpp;
        }


        /// <summary>
        /// Изменение пикселя
        /// </summary>
        /// <param name="x">Координата пискеля по X</param>
        /// <param name="y">Координата пискеля по Y</param>
        /// <returns></returns>
        public abstract bool TransformPix(ushort x, ushort y);
    }
}