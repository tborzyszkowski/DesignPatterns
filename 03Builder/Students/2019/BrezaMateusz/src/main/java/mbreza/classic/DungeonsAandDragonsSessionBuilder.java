package mbreza.classic;

public class DungeonsAandDragonsSessionBuilder implements RpgSessionBuilder {

    RpgSession rpgSession;

    public DungeonsAandDragonsSessionBuilder() {
        this.rpgSession = new RpgSession();
    }

    @Override
    public void addGameType() {
        rpgSession.setGameType(GameType.DUNGEONSANDDRAGONS);
    }

    @Override
    public void addGameMaster() {
        rpgSession.setGameMaster("Mark");
    }

    @Override
    public void addNumberOfPlayers() {
        rpgSession.setNumberOfPlayers(5);
    }

    @Override
    public void addSessionLocation() {
        rpgSession.setSessionLocation("Mark's basement");
    }

    @Override
    public RpgSession getRpgSession() {
        return this.rpgSession;
    }
}
