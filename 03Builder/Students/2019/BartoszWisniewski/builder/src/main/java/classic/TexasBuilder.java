package classic;

public class TexasBuilder implements GameBuilder {
	private Game game;
	
	public TexasBuilder(){
		this.game = new Game();
	}

	@Override
	public void buildGameType() {
		game.setGameType(GameType.Texas);

	}

	@Override
	public void buildNumberOfPlayers() {
		game.setNumberOfPlayers(3);

	}

	@Override
	public void buildDealer() {
		game.setDealer("Mirek");

	}

	@Override
	public Game getGame() {
		return this.game;
	}

}
