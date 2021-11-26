import java.util.ArrayList;

public class Main
{


	public static int _ShipCount = 10;
	
	public static void main(String[] args) {
		
		GameFrame frame = new GameFrame();
		Mapini pMap = new Mapini("Player");
		Mapini cMap = new Mapini("Computer");
		Mapini pHitMap = new Mapini("Player-HitMap");
		Mapini cHitMap = new Mapini("Computer-HitMap");
		Ai Bob = new Ai(cHitMap);
		
		pMap.initialize();
		pHitMap.initialize();
		cMap.initialize();

		int AiHp;
		int PlayerHp;

		do
		{

			//
			// Hier werden die Schiffe der Ai gesetzt
			//

			cHitMap.initialize();
			ArrayList<Ship> AiShips = new ArrayList<Ship>(Bob.DeployShips(_ShipCount));
			AiHp = calcHP(AiShips);

		}
		while(AiHp != 30);
		
		//do
		//{					geht noch nich :C

			//
			// Hier platziert der Spieler seine Schiffe
			//

			//Player player = new Player(pMap);

			//ArrayList<Ship> PlayerShips = new ArrayList<Ship>(player.Player_DeployShips(_ShipCount, pMap));
			//PlayerHp = calcHP(PlayerShips);
		//}
		//while(PlayerHp != 30);

		do
		{
		
			//Hier findet das Spiel statt
		}
		while(true);
	}
	
	//
	// Methoden
	//

	public static void showMessage(String text) //Muss umgeschrieben werden
	{

		//
		// Zeigt den eingegebenen Text in einer Box an
		// Die Größe der Box passt sich an die Text Größe an
		//

		int count = text.length();

		if(text == "default") Mapini.println(">------------------------<");
		else
		{

		String spacerSymbol = "-";
		String bigSpacer = "-";
		String smallSpacer = "-";

		for(int i = 0; i < count; i++) bigSpacer = bigSpacer + spacerSymbol; 
		for(int i = 0; i <count/2; i++) {bigSpacer = bigSpacer + spacerSymbol + spacerSymbol; smallSpacer = smallSpacer + spacerSymbol;}

		Mapini.println("\n /" + bigSpacer + "\\\n" + "|" + smallSpacer + text + smallSpacer +"-|\n" + " \\" + bigSpacer + "/\n");
		}
	}
	
	//
	// Hilfsmethoen
	//

	static int calcHP(ArrayList<Ship> list)
	{
		int hp = 0;
		for(int i = 0;i<list.size();i++)
		{
			hp = hp + list.get(i)._Hp;
		}
		return hp;
	}
}


