import java.util.ArrayList;
import java.util.Scanner;



public class Player{
    
	static Mapini _Map;

	//
	// Konstruktor
	//

    public Player(Mapini map) {
        _Map = map;
    }

    //
    // Methoden
    //

    ArrayList<Ship> Player_DeployShips(int amount, Mapini map)
        {
            boolean showInts = true;
            boolean placing = false;
			Scanner s = new Scanner(System.in);
			ArrayList<Ship> shipList = new ArrayList<Ship>();
            while (amount != 0)
            {
                map.display();
                if (showInts) { System.out.println("\n  Platziere dein Schiff!"); showInts = false; }
                String input = s.next();
                int[] coordinates = getCordsFromInput(input.toCharArray());
                if(coordinates != null)
                {
                    map._Map[coordinates[0]][coordinates[1]] = "S";
				System.out.println("In welche Richtung soll das Schiff fahren?");

                if (!placing)
                {
                    map.display();
                    int x = coordinates[0];
                    int y = coordinates[1];
					Ship ship = new Ship(x, y, map);
					shipList.add(ship);
					Ai.decideSize(amount, ship);
                    Ai.DrawShip(ship, map);
                    placing = false;
                    showInts = true;
                }
                else placing = true;
                amount--;
                }
            }
			s.close();
			return shipList;
        }
	
    //
    // Hilfsmethoden
    //

    static int[] getCordsFromInput(char[] input)
	{
		//
		// übersetzt input in Coordinaten
		//

		int[] result = new int[input.length];
		char[] letterTranslation = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'};

		boolean hasLetter = false;
		for(int i = 0; i < input.length; i++)
		{
			if(Character.isLetter(input[i]))
			{
				for(int j = 0; j < letterTranslation.length; j++)
				{
					if(letterTranslation[j] == input[i]){ result[0] = j; hasLetter = true; break;}

				}
			}
			else result[1] = Character.getNumericValue(input[i]);
		}
		if(!hasLetter) result = null;
		return result;
	}

}
