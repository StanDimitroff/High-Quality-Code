import java.awt.Color;
import java.awt.Graphics;

public class Square {
    private int x, y;
    private final int WIDTH = 20;
    private final int HEIGHT = 20;

    public Square(Square square) {
        this(square.x, square.y);
    }

    public Square(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return this.x;
    }

    public int getY() {
        return this.y;
    }

    public void drawSquare(Graphics graph, Color color) {
        graph.setColor(Color.BLACK);
        graph.fillRect(this.x, this.y, this.WIDTH, this.HEIGHT);
        graph.setColor(color);
        graph.fillRect(this.x + 1, this.y + 1, this.WIDTH - 2, this.HEIGHT - 2);
    }

    public boolean equals(Object object) {
        if (object instanceof Square) {
            Square square = (Square) object;
            return (this.x == square.x) && (this.y == square.y);
        }

        return false;
    }
}