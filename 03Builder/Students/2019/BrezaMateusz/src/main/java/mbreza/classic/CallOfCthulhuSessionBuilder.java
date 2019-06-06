package mbreza.classic;

public class CallOfCthulhuSessionBuilder implements RpgSessionBuilder {

    RpgSession rpgSession;

    public CallOfCthulhuSessionBuilder() {
        this.rpgSession = new RpgSession();
    }

    @Override
    public void addGameType() {
        rpgSession.setGameType(GameType.CALLOFCTHULHU);
    }

    @Override
    public void addGameMaster() {
        rpgSession.setGameMaster("Luke");
    }

    @Override
    public void addNumberOfPlayers() {
        rpgSession.setNumberOfPlayers(3);
    }

    @Override
    public void addSessionLocation() {
        rpgSession.setSessionLocation("Luke's basement");
    }

    @Override
    public RpgSession getRpgSession() {
        return this.rpgSession;
    }
}
