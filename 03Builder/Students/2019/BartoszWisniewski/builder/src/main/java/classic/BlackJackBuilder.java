package classic;

public class BlackJackBuilder implements GameBuilder {
	private Game game;
	
	public BlackJackBuilder(){
		this.game = new Game();
	}

	@Override
	public void buildGameType() {
		game.setGameType(GameType.BlackJack);

	}

	@Override
	public void buildNumberOfPlayers() {
		game.setNumberOfPlayers(3);

	}

	@Override
	public void buildDealer() {
		game.setDealer("Krzys");

	}

	@Override
	public Game getGame() {
		return this.game;
	}

}