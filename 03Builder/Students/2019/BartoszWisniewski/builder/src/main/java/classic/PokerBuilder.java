package classic;

public class PokerBuilder implements GameBuilder {
	private Game game;
	
	public PokerBuilder(){
		this.game = new Game();
	}

	@Override
	public void buildGameType() {
		game.setGameType(GameType.POKER);

	}

	@Override
	public void buildNumberOfPlayers() {
		game.setNumberOfPlayers(4);

	}

	@Override
	public void buildDealer() {
		game.setDealer("Wojtek");

	}

	@Override
	public Game getGame() {
		return this.game;
	}

}
