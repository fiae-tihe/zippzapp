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
	
	// TODO[1]: NEW
	public interface KenntSpiel{
		void zipp();
		void zapp();
		void ping(Spieler ziel);
		void boing();
		void pong();
		void print();
	}
	
	public interface TutEtwas{
		void tueEtwas();
	}
	
	// TODO[1]: NEW
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
		//TODO[3]: So kann jeder dem Spieler etwas in die Hand drücken, ohne das er*sie es will. Methode zum Ball geben stattdessen.
		public Ball hand_rechts;
		
		public Spieler()
		{
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
			//TODO[3]: Machen wir die vorherige Aktion einfach rückgängig?
			// Geben wir den Ball weiter?
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
		
		//TODO[4]: NEW
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
			// Ergänzen sie das
			
		}
	}
}
