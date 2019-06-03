package classic;

public class GameDirector {
	private GameBuilder gameBuilder;
	
	public GameDirector(GameBuilder gameBuilder){
		this.gameBuilder = gameBuilder;
	}
	public void createGame(){
		gameBuilder.buildGameType();
		gameBuilder.buildNumberOfPlayers();
		gameBuilder.buildDealer();
	}
	public Game getGame(){
		return this.gameBuilder.getGame();
	}
}
