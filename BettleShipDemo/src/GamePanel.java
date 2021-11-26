import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JPanel;

public class GamePanel extends JPanel{

    int hight, width;

    public GamePanel()
    {
        hight = 50;
        width = 50;
        setLayout(null);
        repaint();
       // Graphics g = new Graphics();
    }

    public void paintComponent(Graphics g)
    {
        int x = 0;
        int y = 0;

        super.paintComponent(g);
        setBackground(Color.BLACK);
        g.setColor(Color.WHITE); 
        g.fillRect(x, y, hight, width);

        x = x + 51;
        super.paintComponent(g);
        g.setColor(Color.WHITE);
        g.fillRect(x, y, hight, width);
            
    }
}
