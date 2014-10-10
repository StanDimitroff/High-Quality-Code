import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * Creates the snake body from squares.
 */
public class Snake {
    LinkedList<Square> snakeBody = new LinkedList<Square>();
    private Color snakeColor;
    private int velocityX, velocityY;

    public Snake() {
        this.snakeColor = Color.GREEN;
        this.snakeBody.add(new Square(300, 100));
        this.snakeBody.add(new Square(280, 100));
        this.snakeBody.add(new Square(260, 100));
        this.snakeBody.add(new Square(240, 100));
        this.snakeBody.add(new Square(220, 100));
        this.snakeBody.add(new Square(200, 100));
        this.snakeBody.add(new Square(180, 100));
        this.snakeBody.add(new Square(160, 100));
        this.snakeBody.add(new Square(140, 100));
        this.snakeBody.add(new Square(120, 100));

        this.velocityX = 20;
        this.velocityY = 0;
    }

    /**
     * Draws the snake square by square.
     *
     * @param graph Graphics instance.
     */
    public void drawSnake(Graphics graph) {
        for (Square square : this.snakeBody) {
            square.drawSquare(graph, this.snakeColor);
        }
    }

    /**
     * Provides movement and growing the snake.
     */
    public void move() {
        Square current = new Square((this.snakeBody.get(0).getX() + this.velocityX), (this.snakeBody.get(0).getY() + this.velocityY));

        if (current.getX() > Game.WIDTH - 20) {
            Game.gameRunning = false;
        } else if (current.getX() < 0) {
            Game.gameRunning = false;
        } else if (current.getY() < 0) {
            Game.gameRunning = false;
        } else if (current.getY() > Game.HEIGHT - 20) {
            Game.gameRunning = false;
        } else if (Game.apple.getSquare().equals(current)) {
            this.snakeBody.add(Game.apple.getSquare());
            Game.apple = new Apple(this);
            Game.score += 50;
        } else if (this.snakeBody.contains(current)) {
            Game.gameRunning = false;
            System.out.println("You ate yourself");
        }

        for (int i = this.snakeBody.size() - 1; i > 0; i--) {
            this.snakeBody.set(i, new Square(this.snakeBody.get(i - 1)));
        }

        this.snakeBody.set(0, current);
    }

    public int getVelX() {
        return this.velocityX;
    }

    public void setVelX(int velX) {
        this.velocityX = velX;
    }

    public int getVelY() {
        return this.velocityY;
    }

    public void setVelY(int velY) {
        this.velocityY = velY;
    }
}