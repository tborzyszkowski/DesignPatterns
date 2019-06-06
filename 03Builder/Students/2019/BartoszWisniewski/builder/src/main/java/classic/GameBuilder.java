package classic;

public interface GameBuilder {
	public void buildGameType();
	public void buildNumberOfPlayers();
	public void buildDealer();
	public Game getGame();
}
