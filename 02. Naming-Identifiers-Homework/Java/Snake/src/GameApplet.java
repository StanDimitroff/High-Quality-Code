import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")

public class GameApplet extends Applet {
    private Game game;
    KeyHandler handler;

    public void init() {
        game = new Game();
        game.setPreferredSize(new Dimension(800, 650));
        game.setVisible(true);
        game.setFocusable(true);
        this.add(game);
        this.setVisible(true);
        this.setSize(new Dimension(800, 650));
        handler = new KeyHandler(game);
    }

    public void paint(Graphics graph) {
        this.setSize(new Dimension(800, 650));
    }
}