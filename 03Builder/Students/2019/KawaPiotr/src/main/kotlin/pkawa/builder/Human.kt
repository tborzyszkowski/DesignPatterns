package pkawa.builder

class Human(builder: Builder) {
    val eyeColor: String
    val height: Double
    val weight: Double
    val race: Race
    val education: Education
    var age: Int



    init {
        eyeColor = builder.eyeColor
        height = builder.height
        weight = builder.weight
        race = builder.race
        education = builder.education
        age = builder.age
    }

    companion object Builder {
        private lateinit var eyeColor: String
        private var  height: Double = 0.0
        private var  weight: Double = 0.0
        private lateinit var  race: Race
        private lateinit var education: Education
        private var age: Int = 0

        fun eyeColor(eyeColor: String) : Builder { this.eyeColor = eyeColor; return this }

        fun height(height: Double): Builder {
            if (height <= 0 || height.isInfinite() || height.isNaN()) {
                throw IllegalArgumentException("Incorrect height: $height")
            }
            this.height = height
            return this
        }

        fun weight(weight: Double) : Builder {
            if (weight <= 0 || weight.isInfinite() || weight.isNaN()) {
                throw IllegalArgumentException("Incorrect weight: $weight")
            }
            this.weight = weight
            return this
        }

        fun race(race: Race): Builder { this.race = race; return this }

        fun education(education: Education) : Builder { this.education = education; return this}

        fun age(age: Int): Builder {
            if (age < 0) {
                throw IllegalArgumentException("Incorrect age: $age")
            }
            this.age = age
            return this
        }

        fun build(): Human {
            assert(height > 0)
            assert(weight > 0)
            return Human(this)
        }
    }
}