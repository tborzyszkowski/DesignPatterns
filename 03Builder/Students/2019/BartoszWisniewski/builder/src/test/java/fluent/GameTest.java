package fluent;

import static org.junit.Assert.*;


import org.junit.Test;

import classic.BlackJackBuilder;
import classic.Game;
import classic.GameDirector;
import classic.GameType;
import classic.PokerBuilder;
import classic.TexasBuilder;

public class GameTest {
	
	BlackJackBuilder bj = new BlackJackBuilder();
	PokerBuilder poker = new PokerBuilder();
	TexasBuilder texas = new TexasBuilder();
	

	@Test
	public void createBJGameTest() {
		GameDirector gameDirector = new GameDirector(bj);
		gameDirector.createGame();
		Game game = gameDirector.getGame();
		assertEquals(game.getGameType(), GameType.BlackJack);
	}

	@Test
	public void createPokerGameTest() {
		GameDirector gameDirector = new GameDirector(poker);
		gameDirector.createGame();
		Game game = gameDirector.getGame();
		assertEquals(game.getGameType(), GameType.POKER);
	}

	@Test
	public void createTexasGameTest() {
		GameDirector gameDirector = new GameDirector(texas);
		gameDirector.createGame();
		Game game = gameDirector.getGame();
		assertEquals(game.getGameType(), GameType.Texas);
	}
}
