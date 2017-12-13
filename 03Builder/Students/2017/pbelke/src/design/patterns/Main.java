package design.patterns;

import design.patterns.builder.MonopolyGameBuilder;
import design.patterns.builder.RiskBoardGameBuilder;
import design.patterns.model.BoardGame;

public class Main {

    public static void main(String[] args) {
        Shop shop = new Shop();
        BoardGame monopoly = shop.sellGame(new MonopolyGameBuilder());
        System.out.println(monopoly);

        BoardGame risk = shop.sellGame(new RiskBoardGameBuilder());
        System.out.println(risk);
    }
}
