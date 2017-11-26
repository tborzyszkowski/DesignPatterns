package design.patterns;

import design.patterns.builder.BoardGameBuilder;
import design.patterns.model.BoardGame;

public class Shop {

    public BoardGame sellGame(BoardGameBuilder boardGameBuilder){
        return boardGameBuilder.build();
    }

}
