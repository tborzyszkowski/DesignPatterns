package design.patterns.model;

public class BoardGame {

    private String name;
    private String board;
    private String cards;
    private String dices;
    private String pieces;

    public BoardGame(String name) {
        this.name = name;
    }

    public String getBoard() {
        return board;
    }

    public void setBoard(String board) {
        this.board = board;
    }

    public String getCards() {
        return cards;
    }

    public void setCards(String cards) {
        this.cards = cards;
    }

    public String getDices() {
        return dices;
    }

    public void setDices(String dices) {
        this.dices = dices;
    }

    public String getPieces() {
        return pieces;
    }

    public void setPieces(String pieces) {
        this.pieces = pieces;
    }

    @Override
    public String toString() {
        return "BoardGame{" +
                "name='" + name + '\'' +
                ", board='" + board + '\'' +
                ", cards='" + cards + '\'' +
                ", dices='" + dices + '\'' +
                ", pieces='" + pieces + '\'' +
                '}';
    }
}
