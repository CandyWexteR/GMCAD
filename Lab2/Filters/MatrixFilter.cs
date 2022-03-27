namespace Lab2.Filters
{
    public class MatrixFilter : FilterBase
    {
        protected int RangX; // X and Y size of matrix
        protected int RangY;
        protected int[,] Matrix; // matrix pointer

        /// <inheritdoc/>
        public override unsafe bool TransformPix(ushort x, ushort y)
        {
            var xStart = 0;
            int dx = RangX / 2, dy = RangY / 2;
            if (x - dx < 0)
            {
	            xStart = dx - x;
            }

            var yStart = 0;
            if (y - dy < 0)
            {
	            yStart = dy - y;
            }

            var xFinish = RangX;

            if (x + dx > Buffer[Source].Width)
            {
	            xFinish -= (x + dx - Buffer[Source].Width);
            }

            var yFinish = RangY;
            if (y + dy > Buffer[Source].Height)
            {
	            yFinish -= (y + dy - Buffer[Source].Height);
            }

            // Calculating new pixel color values taking into
            // account neighbors falling into the transformation
            // matrix coverage area.
            var newBgr = new int[3];
            var count = 0;
            for (var c = 0; c < 3; c++)
            {
                newBgr[c] = 0; count = 0;
                var my = 0;
                for (my = yStart; my < yFinish; my++)
                {
	                var mx = 0;
	                for (mx = xStart; mx < xFinish; mx++)
	                {
		                // Source 
		                byte* pSPix = null;
		                if ((pSPix = GetPixelPointer((ushort)(x + (mx - dx)), (ushort)(y + (my - dy)), Source)) != null)
		                {
			                newBgr[c] += (Matrix[my, mx] * pSPix[c]);
			                count += Matrix[my, mx];
		                }

	                }
                }
            }

            // Pixel address in the destination image
            var pDPix = GetPixelPointer(x, y, Dest);

            // Reducing the value to the allowed range and setting into the destination
            if (pDPix != null)
            {
	            for (var c = 0; c < 3; c++)
	            {
		            if (count != 0)
		            {
			            newBgr[c] = newBgr[c] / count;
		            }

		            if (newBgr[c] < 0)
		            {
			            newBgr[c] = 0;
		            }
		            else if (newBgr[c] > 255)
		            {
			            newBgr[c] = 255;
		            }

		            pDPix[c] = (byte)newBgr[c];
	            }
            }

            return true;

        }
    }

}