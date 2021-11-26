import java.awt.Dimension;
import javax.swing.JFrame;

public class GameFrame extends JFrame{
    
    static int height = 300;
    static int width = 400;

    public GameFrame() {

        Dimension dim = new Dimension(height, width);
        JFrame frame = new JFrame();
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setTitle("BattleShip");
        frame.setVisible(true);
        frame.setLocationRelativeTo(null);
        frame.setPreferredSize(dim);
        frame.setMinimumSize(dim);
        frame.setMaximumSize(dim);
        frame.setResizable(false);
        frame.add(new GamePanel());

    }
}
