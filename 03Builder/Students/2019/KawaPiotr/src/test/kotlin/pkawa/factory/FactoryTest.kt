package pkawa.factory

import org.junit.Assert.assertEquals
import org.junit.Test
import pkawa.Platform

class FactoryTest {

    private val gameTitle = "Red Dead Redemption"

    @Test
    fun playstationGameStoreTest() {
        val ps4GameStore: GameStore = GameStore(PS4GameFactory)
        val game = ps4GameStore.buyAGame(gameTitle)

        assertEquals(game.title, gameTitle)
        assertEquals(game.platform, Platform.PS4)
    }

    @Test
    fun xboxGameStoreTest() {
        val ps4GameStore: GameStore = GameStore(XBOXOneGameFactory)
        val game = ps4GameStore.buyAGame(gameTitle)

        assertEquals(game.title, gameTitle)
        assertEquals(game.platform, Platform.XBOX)
    }
}

/*
Builder vs Factory:
1. Factory w tym przypadku wygrywa, ponieważ posiadamy fabrykę zwracającą od razu mało skomplikowane obiekty.
2. Factory w tym przypadku rozwiązuje problem dla danych rodzin produktów - builder by od nas wymagał zawsze podawania
platformy gry, fabryka w tym przypadku wymusza przypadek, który chcemy (jeśli chcemy sprzedawać gry na PS4, nie ma powodu, by
zawsze mówić, że to gra na PS4)
 */