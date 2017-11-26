package design.patterns.builder;

import design.patterns.model.BoardGame;

public class RiskBoardGameBuilder extends BoardGameBuilder {

    public RiskBoardGameBuilder() {
        boardGame = new BoardGame("Risk");
    }

    @Override
    public BoardGameBuilder addBoard() {
        boardGame.setBoard("Risk board");
        return this;
    }

    @Override
    public BoardGameBuilder addDices() {
        boardGame.setDices("5 dices");
        return this;
    }

    @Override
    public BoardGameBuilder addPieces() {
        boardGame.setPieces("305 pieces");
        return this;
    }

    @Override
    public BoardGameBuilder addCards() {
        boardGame.setCards("56 cards");
        return this;
    }
}
