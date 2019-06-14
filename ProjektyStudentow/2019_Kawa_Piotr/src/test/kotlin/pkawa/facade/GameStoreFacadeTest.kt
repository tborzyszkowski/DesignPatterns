package pkawa.facade

import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Assertions.assertTrue
import org.junit.jupiter.api.BeforeEach
import org.junit.jupiter.api.Test
import pkawa.model.Game
import pkawa.model.Platform
import pkawa.observer.GameStore

class GameStoreFacadeTest {
    lateinit var gameStore: GameStore
    lateinit var gameStoreFacade: GameStoreFacade
    private val games = arrayListOf(
            Game("Banjo Kazooie", Platform.PS4),
            Game("Red Dead Redemption 2", Platform.PS4),
            Game("Forza Horizon", Platform.XBOX_ONE)
    )

    @BeforeEach
    fun setUp() {
        gameStore = GameStore()
        gameStoreFacade = GameStoreFacade(gameStore)
    }

    @Test
    fun gamesGetReleased() {
        gameStoreFacade.releaseGames(
                "Playstation 4",
                *games.filter { it.platform == Platform.PS4 }.map { it.title }.toTypedArray()
        )
        gameStoreFacade.releaseGames(
                "Xbox One",
                *games.filter { it.platform == Platform.XBOX_ONE }.map { it.title }.toTypedArray()
        )

        assertTrue(games.all { gameStore.isTheGameAvailable(it) })
    }

    @Test
    fun gameBoxIsCreated() {
        val consoleName = "Xbox One X"
        val gameTitle = games[2].title

        gameStoreFacade.releaseGames(consoleName, gameTitle)
        val gameBox = gameStoreFacade.prepareConsoleBox(consoleName, gameTitle)

        assertEquals(games[2], gameBox.game)
        assertEquals(consoleName, gameBox.console.consoleName)
    }

    @Test
    fun gameIsReleasedAndGameBoxIsCreated() {
        val consoleName = "Playstation 4 Pro"
        val gameTitle = games[0].title

        val gameBox = gameStoreFacade.releaseGameAndPrepareConsoleBox(consoleName, gameTitle)

        assertEquals(games[0], gameBox.game)
        assertEquals(consoleName, gameBox.console.consoleName)

    }

}