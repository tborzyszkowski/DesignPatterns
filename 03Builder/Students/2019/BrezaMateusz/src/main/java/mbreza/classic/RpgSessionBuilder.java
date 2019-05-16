package mbreza.classic;

public interface RpgSessionBuilder {
    void addGameType();
    void addGameMaster();
    void addNumberOfPlayers();
    void addSessionLocation();
    RpgSession getRpgSession();
}
