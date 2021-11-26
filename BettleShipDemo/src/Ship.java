import java.util.ArrayList;

public class Ship {

	public static Mapini _Map;
	public String _DisplayUnit = "S";
	public Klasse _Klasse;
	public Direction _Direction;
	public int _StartX;
	public int _StartY;
	public ArrayList<int[]> _Body = new ArrayList<int[]>(); 
	
	public int _Size;
	public int _Hp;
	
	public enum Direction
	{
		up,
		down,
		left,
		right,
		undefined
	}
	
	public enum Klasse
	{
		Schlachtschiff,
		Kreuzer,
		Zerstörer,
		UBoot
	}
	
	//
	//Konstruktor
	//
	
	public Ship(int x, int y, Mapini map)
	{
		_StartX = x;
		_StartY = y;
		_Map = map;
	}
	
	//
	//Get/Set-Methoden
	//
	
	public Klasse getKlasse() 
	{
		return this._Klasse;
	}
	
	public Direction getDirection() 
	{
		return this._Direction;
	}
	public void setDirection(Direction direction) {
		this._Direction = direction;
	}
	
	//
	//Methoden
	//
	
	public int calcShipHp()
	{
		
		int hp = 0;
		for(int i = 0; i< this._Body.size();i++)
		{
			int x = this._Body.get(i)[0];
			int y = this._Body.get(i)[1];
			
			if(_Map._Map[x][y] == _DisplayUnit)
			{
				hp++;
			}
		}
		return hp;
	}
	
	public void decideKlasse()
	{
		switch(this._Size)
		{
		case(5):
			this._Klasse = Klasse.Schlachtschiff;
			this._Hp = 5;
				break;
		case(4):
			this._Klasse = Klasse.Kreuzer;
			this._Hp = 4;
				break;
		case(3):
			this._Klasse = Klasse.Zerstörer;
			this._Hp = 3;
				break;
		case(2):
			this._Klasse = Klasse.UBoot;
			this._Hp = 2;
				break;
		}
	}
	
	void checkForSpace()
	{//Decides the direction that the ship will be placed in
		int x  = this._StartX;
		int y  = this._StartY;
		int size = this._Size;
		
		String[] left = new String[size];
		String[] right = new String[size];
		String[] up = new String[size];
		String[] down = new String[size];
		
		Direction direction = Direction.undefined;
		
		boolean leftDir = false;
		boolean rightDir = false;
		boolean downDir = false;
		boolean upDir = false;
		
		int lIndex = 0;
		int rIndex = 0;
		int uIndex = 0;
		int dIndex = 0;
		
		for(int r = x; r < x + size; r++)
		{//inserts all symbols found in the ships size on the map[x+] into "right"
			try
			{
				right[rIndex] = _Map._Map[r][y];
				rIndex++;
			}
			catch(Exception e)
			{
				right = null;
			}
		}
		for(int r = x - size; r < x; r++)
		{//inserts all symbols found in the ships size on the map[x-] into "left"
			try
			{
				left[lIndex] = _Map._Map[r][y];
				lIndex++;
			}
			catch(Exception e)
			{
				left = null;
			}
		}
		for(int c = y; c < y + size;c++)
		{//inserts all symbols found in the ships size on the map[y+] into "down"
			try
			{
				down[dIndex] = _Map._Map[x][c];
				dIndex++;
			}
			catch(Exception e)
			{
				down = null;
			}
		}
		for(int c = y-size;c<y;c++)
		{//inserts all symbols found in the ships size on the map[y-] into "up"
			try
			{
				up[uIndex] = _Map._Map[x][c];
				uIndex++;
			}
			catch(Exception e)
			{
				up = null;
			}
		}
		
		if(checkFor(left, "S") == false) leftDir = true;
		if(checkFor(right, "S") == false) rightDir = true;
		if(checkFor(down, "S") == false) downDir = true;
		if(checkFor(up, "S") == false) upDir = true;
		
		if(leftDir && downDir)
		{
			if(x < size)
			direction = Direction.left;
			else
				direction = Direction.down;
		}
		else if(leftDir && upDir)
		{
			if(x < size)
			direction = Direction.left;
			else
				direction = Direction.up;
		}
		else if(rightDir && downDir)
		{
			if(x > size)
			direction = Direction.right;
			else 
				direction = Direction.down;
		}
		else if(rightDir && upDir)
		{
			if(x > size)
			direction = Direction.right;
			else
				direction = Direction.up;
		}
		
		this._Direction = direction;
	}
	
	//
	//Hilfs-Methoden
	//
	
	public static boolean checkFor(String[] array, String search)
	{//searches the array for an occurance of "search"
		boolean doesContain = false;
		
		if(array != null)
		{
			for(int i = 0;i< array.length;i++)
			{
				if(array[i] == search) { doesContain = true; break;}
			}
		}
		else doesContain = true;
		return doesContain;
	}
	
}
