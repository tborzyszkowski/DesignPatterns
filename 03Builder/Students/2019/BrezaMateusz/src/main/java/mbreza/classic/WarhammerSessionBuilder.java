package mbreza.classic;

public class WarhammerSessionBuilder implements RpgSessionBuilder{

    RpgSession rpgSession;

    public WarhammerSessionBuilder() {
        this.rpgSession = new RpgSession();
    }

    @Override
    public void addGameType() {
        rpgSession.setGameType(GameType.WARHAMMER);
    }

    @Override
    public void addGameMaster() {
        rpgSession.setGameMaster("John");
    }

    @Override
    public void addNumberOfPlayers() {
        rpgSession.setNumberOfPlayers(4);
    }

    @Override
    public void addSessionLocation() {
        rpgSession.setSessionLocation("John's basement");
    }

    @Override
    public RpgSession getRpgSession() {
        return this.rpgSession;
    }
}
