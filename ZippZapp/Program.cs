/*
 * User: tihe
 * Date: 12.11.2025
 * Time: 12:15
 */
using System;
using System.Threading;

namespace ZippZapp
{
	class Program
	{
		public static void Main(string[] args)
		{	
			
			// neuen Spielkreis anlegen
			Spielkreis testKreis =  Spielkreis.erzeugeTestKreis();
			testKreis.printKreis();
			Thread.Sleep(1000);
			
			// neuen Ball zum Spielkreis hinzufügen
			testKreis.neuerBall();
			testKreis.printKreis();
			waitForKeypress();
			
			// der Startspieler macht zipp
			testKreis.start_spieler.zipp();
			testKreis.printKreis();
			waitForKeypress();
			
			// der Spieler links vom Startspieler (müsste nach zipp den Ball haben) tut irgendetwas
			testKreis.start_spieler.spieler_links.tueEtwas();
			testKreis.printKreis();
			waitForKeypress();
			
			//TODO[4]: Um im Spielablauf weiter zu kommen, müsste das Folgende funktionieren.
			// Wie lösen wir die nächste Aktion aus?
			// Wer macht etwas? -> Auf welchem Objekt rufe ich eine Methode auf?
			// Was wird gemacht? -> Welche Methode wird aufgerufen bzw. was tut diese Methode?
			
			
			//try {
				Spieler spielerMitBall = null;
				spielerMitBall.tueEtwas();
				testKreis.printKreis();
				waitForKeypress();
			//} catch (Exception e){
			//	System.Console.WriteLine(e.Message);
			//}
			
			
			
			Console.WriteLine();
			Console.WriteLine("Ende");
			Console.ReadKey(true);
		}
		
		public static void waitForKeypress(){
			Console.WriteLine();
			Console.WriteLine("Weiter");
			Console.ReadKey(true);
		}
	}
}