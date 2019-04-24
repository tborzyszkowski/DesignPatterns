package mbreza.Simple;

public class GameFactory {

    private static GameFactory instance = null;

    private GameFactory() {
    }

    public static GameFactory createInstance(){
        if(instance == null) {
            instance = new GameFactory();
        }
        return instance;
    }

    public static Game createGame(GameType gameType) {
        switch (gameType) {
            case FPS:
                return new FPS();
            case RPG:
                return new RPG();
            default:
                return null;
        }
    }
}
