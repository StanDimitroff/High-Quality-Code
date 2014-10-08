import java.awt.Color;
import java.awt.Graphics;

public class Point {
    private int x, y;
    private final int WIDTH = 20;
    private final int HEIGHT = 20;

    public Point(Point p) {
        this(p.x, p.y);
    }

    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    public void drawSnake(Graphics graph, Color color) {
        graph.setColor(Color.BLACK);
        graph.fillRect(x, y, WIDTH, HEIGHT);
        graph.setColor(color);
        graph.fillRect(x + 1, y + 1, WIDTH - 2, HEIGHT - 2);
    }

    public String toString() {
        return "[x=" + x + ",y=" + y + "]";
    }

    public boolean equals(Object object) {
        if (object instanceof Point) {
            Point point = (Point) object;
            return (x == point.x) && (y == point.y);
        }

        return false;
    }
}