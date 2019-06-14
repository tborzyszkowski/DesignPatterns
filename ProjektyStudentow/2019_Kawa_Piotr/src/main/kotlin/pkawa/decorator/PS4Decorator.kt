package pkawa.decorator

import pkawa.model.Console
import pkawa.model.Game

class PS4Decorator(console: Console) : ConsoleDecorator(console) {

    override fun bootGame(game: Game): Boolean {
        print("\n        888                        888           888   d8b                 \n" +
                "        888                        888           888   Y8P                 \n" +
                "        888                        888           888                       \n" +
                "88888b. 888 8888b. 888  888.d8888b 888888 8888b. 888888888 .d88b. 88888b.  \n" +
                "888 \"88b888    \"88b888  88888K     888       \"88b888   888d88\"\"88b888 \"88b \n" +
                "888  888888.d888888888  888\"Y8888b.888   .d888888888   888888  888888  888 \n" +
                "888 d88P888888  888Y88b 888     X88Y88b. 888  888Y88b. 888Y88..88P888  888 \n" +
                "88888P\" 888\"Y888888 \"Y88888 88888P' \"Y888\"Y888888 \"Y888888 \"Y88P\" 888  888 \n" +
                "888                     888                                                \n" +
                "888                Y8b d88P                                                \n" +
                "888                 \"Y88P\"                                                 \n\n")
        return console.bootGame(game)
    }
}