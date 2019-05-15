package mbreza;

import mbreza.Simple.Game;
import mbreza.Simple.GameFactory;
import mbreza.Simple.GameType;
import org.junit.Before;
import org.junit.Test;

import java.lang.reflect.InvocationTargetException;

import static org.junit.Assert.assertEquals;

public class SimpleTest {

    GameFactory gameFactory;

    @Before
    public void setup(){
        gameFactory = GameFactory.createInstance();
    }

    @Test
    public void fpsTest() {
        Game fpsGame = gameFactory.createGame(GameType.FPS);
        assertEquals(fpsGame.getType(), "FPS");
    }

    @Test
    public void rpgTest() {
        Game rpgGame = gameFactory.createGame(GameType.RPG);
        assertEquals(rpgGame.getType(), "RPG");
    }

    @Test
    public void timeTest() {
        long start = System.currentTimeMillis();
        for(int i = 0 ; i<1000000 ; i++){
            gameFactory.createGame(GameType.RPG);
        }
        long end = System.currentTimeMillis();
        System.out.println("Simple time: " + (end - start));
    }
}
