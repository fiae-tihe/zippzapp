/*
 * User: tihe
 * Date: 12.11.2025
 * Time: 12:16
 */
using System;

namespace ZippZapp
{
	public enum Farbe{
		ROT,
		GELB,
		BLAU
	}
	/// <summary>
	/// Ein Ball braucht eine Richtung, denn sonst ist nicht klar, wohin es nach ping weiter geht.
	/// </summary>
	/// 
	public class Ball
	{
		public Farbe farbe;
		public bool imUhrzeigerSinn;
		
		public Ball()
		{
			farbe = Farbe.ROT;
			imUhrzeigerSinn = true;
		}
	}
}
