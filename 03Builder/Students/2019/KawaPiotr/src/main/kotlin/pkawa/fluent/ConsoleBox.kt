package pkawa.fluent

import pkawa.Platform

class ConsoleBox(builder: Builder) {
    val modelName: String
    val gameCompatibilityPlatform: Platform
    val controllerColor: String
    val game: String

    init {
        this.modelName = builder.modelName
        this.gameCompatibilityPlatform = builder.gameCompatibilityPlatform
        this.controllerColor = builder.controllerColor
        this.game = builder.game
    }


    companion object Builder {
        private lateinit var modelName: String
        private lateinit var gameCompatibilityPlatform: Platform
        private lateinit var controllerColor: String
        private lateinit var game: String

        fun modelName(modelName: String): Builder {
            this.modelName = modelName; return this
        }

        fun gameCompatibilityPlatform(platform: Platform): Builder {
            this.gameCompatibilityPlatform = platform; return this
        }

        fun controllerColor(color: String): Builder {
            this.controllerColor = color; return this
        }

        fun game(game: String): Builder {
            this.game = game; return this
        }

        fun build() = ConsoleBox(this)
    }
}