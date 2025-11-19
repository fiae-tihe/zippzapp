/*
 * User: tihe
 * Date: 12.11.2025
 * Time: 12:33
 */
using System;

namespace ZippZapp
{
	/// <summary>
	/// Description of Spielkreis.
	/// </summary>
	public class Spielkreis
	{
		public Spieler start_spieler;
		public int runde_nummer = 0;
		public Spielkreis()
		{
		}
		
		private void spielerZumKreis(Spieler neuerSpieler){
			if(start_spieler == null){
				start_spieler = neuerSpieler;
				start_spieler.spieler_links = start_spieler;
				start_spieler.spieler_rechts = start_spieler;
			} else {
				// TODO[2]: Zeichnen für den Zustand vor der Ausführung der folgenden drei Codezeilen jeweils ein Objektdiagramm.
				// Beschreiben sie mit dem Diagramm einen Zustand, der während der Ausführung der Methode erzeugeTestKreis() auftreten kann.
				neuerSpieler.spieler_links = start_spieler.spieler_links;
				start_spieler.spieler_links = neuerSpieler;
				neuerSpieler.spieler_rechts = start_spieler;			
			}
		}
		
		public void spielerZumKreis(string name){
			Spieler neuerSpielerMitName = new SpielerNurZipp();
			neuerSpielerMitName.name = name;
			spielerZumKreis(neuerSpielerMitName);
		}
		
		public void neuerBall(){
			if(start_spieler!=null){
				start_spieler.hand_rechts = new Ball();
			}
		}
		
		public static Spielkreis erzeugeTestKreis(){
			Spielkreis neuerKreis = new Spielkreis();
			neuerKreis.spielerZumKreis("Tick");
			neuerKreis.spielerZumKreis("Trick");
			neuerKreis.spielerZumKreis("Track");
			neuerKreis.spielerZumKreis("Onkel Dagobert");
			neuerKreis.spielerZumKreis("Donald (Duck)");
			return neuerKreis;
		}
		
		public void printKreis(){
			Console.Clear();
			runde_nummer++;
			
			Console.WriteLine("Runde " + runde_nummer);
			if(start_spieler==null){
				Console.WriteLine("Keine Spieler da :(");
			} else {
				Spieler aktuellerSpieler = start_spieler;
				
				aktuellerSpieler.print();
				aktuellerSpieler = aktuellerSpieler.spieler_links;
				
				while (aktuellerSpieler != start_spieler){
					aktuellerSpieler.print();
					aktuellerSpieler = aktuellerSpieler.spieler_links;
				}			
			}
			Console.WriteLine("".PadRight(20,'-'));
		}
	}
}
