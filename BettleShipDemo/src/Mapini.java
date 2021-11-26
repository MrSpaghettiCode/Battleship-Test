public class Mapini 
{
	public String _Name;
	public int _Rows = 10;
	public int _Cols = 10;
	static String _WaveSymbol = "#";
	public String[][] _Map = new String[_Rows][_Cols];
	
	//
	//Konstruktor
	//
	
	public Mapini(String name) 
	{
		this._Name = name;
	}
	
	//
	//Get/Set-Methoden
	//
	
	public void setDimensions(int count) 
	{
		this._Rows = count;
		this._Cols = count;
	}
	
	//
	//Methoden
	//

	public void display() 
	{//Bildet die Map in der Console ab
		println("    A B C D E F G H I J\n");
		for(int r = 0; r<_Rows;r++)
		{
			for(int c = 0;c<_Cols;c++)
			{
				if(c==0) print(r + "   ");
				if(c==9 && r == 4) print(_Map[r][c] + "   " + "["+this._Name+"]");
				else
				print(_Map[r][c] + " ");
			}
			println("");
		}
	}
	
	
	public void display(int Hp) 
	{//Bildet die Map in der Console ab
		println("    A B C D E F G H I J\n");
		for(int r = 0; r<_Rows;r++)
		{
			for(int c = 0;c<_Cols;c++)
			{
				if(c==0) print(r + "   ");
				if(c==9 && r == 4) print(_Map[r][c] + "   " + "["+this._Name+"]" + "[" +Hp +"]");
				else
				print(_Map[r][c] + " ");
			}
			println("");
		}
	}
	
	public void initialize()
	{//Weist jedem Slot der Map den Wert von "WaveSymbol" zu
		for(int r = 0; r<_Rows;r++)
		{
			for(int c = 0;c<_Cols;c++)
			{
				_Map[r][c] = _WaveSymbol;
			}
		}
	}
	
	//
	//HilfsMethoden
	//
	
	public static void println(String text) 
	{
		System.out.println(text);
	}
	
	public static void print(String text) 
	{
		System.out.print(text);
	}
}
