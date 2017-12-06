package design.patterns.builder;

import design.patterns.model.BoardGame;

public class MonopolyGameBuilder extends BoardGameBuilder {

    public MonopolyGameBuilder() {
        boardGame = new BoardGame("Monopoly");
    }

    @Override
    public BoardGameBuilder addBoard() {
        boardGame.setBoard("Monopoly board");
        return this;
    }

    @Override
    public BoardGameBuilder addDices() {
        boardGame.setDices("2 dices");
        return this;
    }

    @Override
    public BoardGameBuilder addPieces() {
        boardGame.setPieces("8 pieces");
        return this;
    }

    @Override
    public BoardGameBuilder addCards() {
        boardGame.setCards("32 cards");
        return this;
    }
}
