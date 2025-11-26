/*
 * User: tihe
 * Date: 12.11.2025
 * Time: 12:15
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace ZippZapp
{
	
	// KEIN gutes Beispiel hier!! Bisher wurde immer mit Vererbung gearbeitet.
	// Es braucht ein größeres Beispiel, um zu verdeutlichen, warum Interfaces notwending sind!
	
	// Interfaces sind Verträge. Sie legen nur fest was ein Objekt können muss, nicht wie das gemacht wird.
	public interface KenntSpiel{
		
		// Ball geht weiter in Ballrichtung
		void zipp();
		
		// Ball wechselt die Richtung, geht also zum vorherigen Spieler
		void zapp();
		
		// Spieler kann den Ball zu einem beliebigen Mitspieler schicken
		void ping(Spieler ziel);
		
		// Spieler weicht aus, der Ball geht weiter.
		void boing();
		
		// Ist man Ziel von ping, kann man mit pong ablehnen.
		void pong();
		
		// Der Spieler soll seinen Zustand auf das Terminal schreiben.
		void print();
	}
	
	
	public interface TutEtwas{
		void tueEtwas();
	}
	
	// Exception stellt Fehler dar, die beim Ausführen einer Anwendung auftreten.
	// Sie können mit throw geworfen werden oder mit try/catch gefangen werden.
	// Wenn ich eine neue Instanz von BallAblehnenException erstelle wird lediglich ein "Zettel mit Fehlerbeschreibung" erstellt.
	// Dieser Zettel muss aber noch geworfen werden, um etwas auszulösen.
	public class BallAblehnenException : Exception{
		
	}
	
	/// <summary>
	/// Ein Spieler hat einem Namen und einen rechten und linken Nachbarn.
	/// Außerdem kann ein Spieler alle Aktionen des Spiels ausführen.
	/// 
	/// </summary>
	public class Spieler: KenntSpiel, TutEtwas
	{
		public string name;
		
		//Rechte und linke Nachbarn im Kreis
		public Spieler spieler_rechts;
		public Spieler spieler_links;
		
		// Spieler nutzen immer ihre rechte Hand, um den Ball zu halten
		// So könnt jeder dem Spieler etwas in die Hand drücken, ohne das er*sie es will.
		// public Ball hand_rechts;
		private Ball hand_rechts;	
		
		public Ball getHandRechts(){
			return this.hand_rechts;
		}
		
		public void setHandRechts(Ball ball){
			if(nimmtBallNichtAn){
				throw new BallAblehnenException();
			}
			this.hand_rechts = ball;
		}
		
		// Der Spieler wird den Ball nicht nehmen
		private bool nimmtBallNichtAn;
		public Spieler()
		{
			nimmtBallNichtAn = false;
		}
		
		private void ball_weiter_im_uhrzeigersinn(){
			spieler_links.hand_rechts = this.hand_rechts;
			this.hand_rechts = null;
		}
		
		private void ball_weiter_gegen_uhrzeigersinn(){
			spieler_rechts.hand_rechts = this.hand_rechts;
			this.hand_rechts = null;
		}
		
		public void zipp(){
			if(hand_rechts.imUhrzeigerSinn){
				ball_weiter_im_uhrzeigersinn();
			} else {
				ball_weiter_gegen_uhrzeigersinn();
			}
		}
		
		public void zapp(){
			if(!hand_rechts.imUhrzeigerSinn){
				ball_weiter_im_uhrzeigersinn();
			} else {
				ball_weiter_gegen_uhrzeigersinn();
			}
		}
		
		public void ping(Spieler ziel){
			ziel.hand_rechts = this.hand_rechts;
			this.hand_rechts = null;
		}
		
		
		
		// Ist boing eine Aktion oder eine Reaktion?
		public void boing(){
			//TODO[4]: Wie setzen wir boing um?
			// Machen wir die vorherige Aktion einfach rückgängig?
			// Geben wir den Ball einfach weiter zum nächsten? (Eigentlich wäre das ja zipp, oder?
			// Lassen wir erst gar nicht zu, dass einem der Ball in die Hand gedrückt wird?
		}
				
		public void pong(){
			
		}
		
		
		public void print(){
			Console.WriteLine(name.PadRight(15) + ": (" 
			                  + (hand_rechts==null ? " ": "*")
			                  + ")");
		}
		
		public virtual void tueEtwas(){
			// Ich kenne alle Methoden und tue trotzdem nichts :P
		}
				
	}
	
	public class SpielerNurZipp: Spieler {
		public override void tueEtwas(){
			zipp();
		}
	}
	
	public class SpielerMalZippMalZapp: Spieler {
		
		private bool jetzt_zipp = true;
		
		public override void tueEtwas(){
			if(jetzt_zipp){
				zipp();
			}else{
				zapp();
			}
			jetzt_zipp = !jetzt_zipp;
		}
	}
	
	public class SpielerMensch: Spieler {
		
		// Dictionaries sind wie Arrays, wir können aber beliebige Schlüssel verwenden (nicht nur Zahlen).
		Dictionary<char, string> actions_list = new Dictionary<char, string>(){
			{'1', "zipp"},
			{'2', "zapp"},
			{'3', "ping"},
			{'4', "boing"},
			{'5', "pong"}
		};
		
		public override void tueEtwas(){
			foreach(var item in actions_list){
				Console.WriteLine(item.Key +  " -> " +  item.Value);
			}
			Console.WriteLine("Aktion auswählen...");
			ConsoleKeyInfo key_pressed = Console.ReadKey(true);
			
			
			Console.WriteLine(actions_list[key_pressed.KeyChar]);
			Thread.Sleep(2000);
			//TODO[5]: Der menschliche Spieler drückt zwar eine Taste, aber es wird hier noch keine Aktion ausgeführt.
			// Ergänzen sie das. Verwenden sie dazu eine switch-Anweisung.
		}
	}
}
