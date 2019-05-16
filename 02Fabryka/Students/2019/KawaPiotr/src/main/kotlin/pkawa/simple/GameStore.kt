package pkawa.simple

import pkawa.exception.UnknownGameTitleException
import pkawa.model.*
import pkawa.model.ConsoleCodename.*

object GameStore {
    fun purchaseConsole(platformName: ConsoleCodename): Console {
        return when (platformName) {
            XBOX_ONE -> XboxOne()
            XBOX_ONE_X -> XboxOneX()
            PS4 -> PlayStation4()
            PS4_PRO -> PlayStation4Pro()
            NINTENDO_SWITCH -> NintendoSwitch()
            NINTENDO_3DS -> ThreeDS()
            NINTENDO_2DS -> TwoDS()
            NINTENDO_NEW_3DS -> New3DS()
        }
    }

    fun purchaseGame(gameTitle: String): Game {
        return when (gameTitle) {
            "[PS4] WITCHER 3" -> Game("Witcher 3", PS4)
            else -> throw UnknownGameTitleException("Wrong title. Please try again.")
        }
    }
}