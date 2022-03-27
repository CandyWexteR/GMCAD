namespace Lab2.Filters
{
	/// <summary>
	/// Точечный фильтр 
	/// </summary>
	public class DotFilter : FilterBase
	{
		protected byte[,] BgrTransTable = new byte[3, 256];
		
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

			// Transforming and setting pixel in the source image
			pDPix[0] = BgrTransTable[0, pSPix[0]];
			pDPix[1] = BgrTransTable[1, pSPix[1]];
			pDPix[2] = BgrTransTable[2, pSPix[2]];

			return true;
		}
	}

}