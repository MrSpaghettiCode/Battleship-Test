import java.util.ArrayList;
import java.util.Random;

public class Ai {

	static Mapini _Map;
	
	//
	//Konstruktor
	//
	
	public Ai(Mapini map)
	{
		_Map = map;
	}
	
	//
	// Methoden
	//

	public ArrayList<Ship> DeployShips(int amount)
	{
		ArrayList<int[]> shipCordsList = new ArrayList<int[]>();
		Random rand = new Random();
		ArrayList<Ship> result = new ArrayList<Ship>(DeployShips(amount, shipCordsList, rand));
		return result;
	}
	
	ArrayList<Ship> DeployShips(int amount, ArrayList<int[]> shipCordsList, Random r)
	{
		ArrayList<Ship> shipList = new ArrayList<Ship>();
		int ships = amount;
		while(ships != 0)
		{
			boolean goon = true;
			int x, y;
			do
			{
				x = r.nextInt(9);
				y = r.nextInt(9);
				if(shipCordsList.isEmpty())
				{
					shipCordsList.add(new int[] {x, y});
				}
				else if(!shipCordsList.contains(new int[] {x, y}))
				{
					shipCordsList.add(new int[] {x, y});
					goon = false;
				}
			}
			while(goon);

			Ship ship = new Ship(x, y, _Map);

			decideSize(ships, ship);
			ship.decideKlasse();
			ship.checkForSpace();
			
			if(ship._Direction != Ship.Direction.undefined)
			{
				ships--;
			}
			ArrayList<int[]> usedCords = DrawShip(ship, _Map);
			for(int[] array : usedCords)
			{
				shipCordsList.add(array);
			}
			shipList.add(ship);
		}
		return shipList;
	}
	
	static ArrayList<int[]> DrawShip(Ship ship, Mapini map)
	{
		ArrayList<int[]> usedCords = new ArrayList<int[]>();
		Ship.Direction direction = ship._Direction;
		int x = ship._StartX;
		int y = ship._StartY;
		int size = ship._Size;
		
		if(direction == Ship.Direction.left)
		{
			for(int i = x; i > x - size; i--)
			{
				map._Map[i][y] = ship._DisplayUnit;
				usedCords.add(new int[] {x, y});
			}
		}
		if(direction == Ship.Direction.right)
		{
			for(int i = x; i< x + size; i++)
			{
				map._Map[i][y] = ship._DisplayUnit;
				usedCords.add(new int[] {x, y});
			}
		}
		if(direction == Ship.Direction.up)
		{
			for(int i = y; i > y - size; i--)
			{
				map._Map[x][i] = ship._DisplayUnit;
				usedCords.add(new int[] {x, y});
			}
		}
		if(direction == Ship.Direction.down)
		{
			for(int i = y; i < y + size; i++)
			{
				map._Map[x][i] = ship._DisplayUnit;
				usedCords.add(new int[] {x, y});
			}
		}
		return usedCords;
	}

	public static void decideSize(int shipAmount, Ship ship)
	{
			if(shipAmount == 10) ship._Size = 5;
			else if(shipAmount < 10 && shipAmount > 7) ship._Size = 4;
			else if(shipAmount < 8 && shipAmount > 4) ship._Size = 3;
			else if(shipAmount < 5) ship._Size = 2;
	}
}
