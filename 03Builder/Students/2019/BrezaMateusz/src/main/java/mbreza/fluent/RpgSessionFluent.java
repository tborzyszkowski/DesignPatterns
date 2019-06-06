package mbreza.fluent;

import mbreza.classic.GameType;

public class RpgSessionFluent {
    private GameType gameType;
    private String gameMaster;
    private int numberOfPlayers;
    private String sessionLocation;


    public RpgSessionFluent( Builder builder) {
        gameType = builder.gameType;
        gameMaster = builder.gameMaster;
        numberOfPlayers = builder.numberOfPlayers;
        sessionLocation = builder.sessionLocation;
    }

    public GameType getGameType() {
        return gameType;
    }

    public String getGameMaster() {
        return gameMaster;
    }

    public int getNumberOfPlayers() {
        return numberOfPlayers;
    }

    public String getSessionLocation() {
        return sessionLocation;
    }

    public static class Builder {
        private GameType gameType;
        private String gameMaster;
        private int numberOfPlayers;
        private String sessionLocation;;

        public Builder addGameType(GameType gameType) {
            this.gameType = gameType;
            return this;
        }

        public Builder addGameMaster(String gameMaster) {
            this.gameMaster = gameMaster;
            return this;
        }

        public Builder addNumberOfPlayers(int numberOfPlayers) {
            this.numberOfPlayers = numberOfPlayers;
            return this;
        }

        public Builder addSessionLocation(String sessionLocation) {
            this.sessionLocation = sessionLocation;
            return this;
        }

        public RpgSessionFluent build() {
            return new RpgSessionFluent(this);
        }
    }
}
