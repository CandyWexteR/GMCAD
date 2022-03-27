namespace Lab2.Filters
{
	/// <summary>
	/// Фильтр четкости
	/// </summary>
	public class SharpFilter : MatrixFilter
	{
		public const int SharpCoeff = 3;

		public SharpFilter()
		{
			RangX = 5;
			RangY = 5;
			Matrix = new int[,]{
				{1,1,1,1,1},
				{1,1,1,1,1},
				{1,1,1,1,1},
				{1,1,1,1,1},
				{1,1,1,1,1}};
		}

		/// <inheritdoc/>
		public override unsafe bool TransformPix(ushort x, ushort y)
		{
			// Dithering the pixel
			if (!base.TransformPix(x, y))
			{
				return false;
			}

			// Source
			var pSPix = GetPixelPointer(x, y, Source);
			// Destination
			var pDPix = GetPixelPointer(x, y, Dest);

			if (pSPix == null || pDPix == null)
			{
				return false;
			}

			for (var c = 0; c < 3; c++)
			{
				// finding difference
				var d = pSPix[c] - pDPix[c];
				// Amplifying the difference
				d *= SharpCoeff;
				// Assigning new value to pixel
				if ((int)pDPix[c] + d < 0)
				{
					pDPix[c] = 0;
				}
				else if (pDPix[c] + d > 255)
				{
					pDPix[c] = 255;
				}
				else
				{
					pDPix[c] += (byte)d;
				}
			}

			return true;
		}
	}
}