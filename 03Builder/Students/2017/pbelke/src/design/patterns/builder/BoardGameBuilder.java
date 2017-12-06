package design.patterns.builder;

import design.patterns.model.BoardGame;

public abstract class BoardGameBuilder {

    protected BoardGame boardGame;

    public BoardGame build() {
        return this.addBoard().addDices().addPieces().addCards().boardGame;
    }

    public abstract BoardGameBuilder addBoard();
    public abstract BoardGameBuilder addDices();
    public abstract BoardGameBuilder addPieces();
    public abstract BoardGameBuilder addCards();
}
