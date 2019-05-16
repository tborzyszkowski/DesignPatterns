package mbreza.classic;

public class RpgSessionGenerator {

    public void generateSession(RpgSessionBuilder rpgSessionBuilder)
    {
        rpgSessionBuilder.addGameType();
        rpgSessionBuilder.addGameMaster();
        rpgSessionBuilder.addNumberOfPlayers();
        rpgSessionBuilder.addSessionLocation();
    }
}
