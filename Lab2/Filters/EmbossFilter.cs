namespace Lab2.Filters
{
	/// <summary>
	/// Фильтр рельефа
	/// </summary>
	public class EmbossFilter : DotFilter
	{
		public const int StoneOffsetX = 3;
		public const int StoneOffsetY = -3;

		/// <inheritdoc/>
		public override unsafe bool TransformPix(ushort x, ushort y)
		{
			// Source
			var pSPix = GetPixelPointer(x, y, Source);
			// Destination
			var pDPix = GetPixelPointer(x, y, Dest);

			if (pSPix == null || pDPix == null)
			{
				return false;
			}

			var x2 = x + StoneOffsetX;
			if (x2 < 0)
			{
				x2 = 0;
			}

			var y2 = y + StoneOffsetY;
			if (y2 < 0)
			{
				y2 = 0;
			}

			// Offset pixel
			byte* pSPix2 = null;
			if ((pSPix2 = GetPixelPointer((ushort)x2, y2, Source)) == null)
			{
				pSPix2 = pSPix;
			}

			// Brightness calculation	
			var Y1 = GetY(pSPix);
			var Y2 = GetY(pSPix2);

			// Finding the difference and moving it into the gray area
			var d = (byte)((Y1 - Y2 + 255) / 2);

			// Pixel gets new values
			pDPix[0] = d;
			pDPix[1] = d;
			pDPix[2] = d;

			return true;
		}
	}
}