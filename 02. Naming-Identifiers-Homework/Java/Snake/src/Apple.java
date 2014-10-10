import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Apple {
    public static Random randomGenerator;
    private Square apple;
    private Color appleColor;

    public Apple(Snake snake) {
        apple = createApple(snake);
        appleColor = Color.RED;
    }

    private Square createApple(Snake snake) {
        randomGenerator = new Random();
        int x = randomGenerator.nextInt(30) * 20;
        int y = randomGenerator.nextInt(30) * 20;
        for (Square snakeSquare : snake.snakeBody) {
            if (x == snakeSquare.getX() || y == snakeSquare.getY()) {
                return createApple(snake);
            }
        }

        return new Square(x, y);
    }

    public void drawApple(Graphics graph) {
        apple.drawSquare(graph, appleColor);
    }

    public Square getSquare() {
        return apple;
    }
}