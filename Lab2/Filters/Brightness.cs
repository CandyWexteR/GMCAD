namespace Lab2.Filters
{
	/// <summary>
	/// Класс фильтра "яркость"
	/// </summary>
	public class Brightness : DotFilter
	{
		/// <summary>
		/// Инициализация фильтра яркости
		/// </summary>
		/// <param name="bOffset"></param>
		/// <returns></returns>
		public bool Init(int bOffset)
		{
			for (var t = 0; t < 3; t++)
			{
				for (var i  = 0; i < 256; i++)
				{
					if (i + bOffset > 255)
					{
						BgrTransTable[t, i] = 255;
					}
					else if (i + bOffset < 0)
					{
						BgrTransTable[t, i] = 0;
					}
					else
					{
						BgrTransTable[t, i] = (byte)(i + bOffset);
					}
				}
			}

			return true;
		}

	}

}