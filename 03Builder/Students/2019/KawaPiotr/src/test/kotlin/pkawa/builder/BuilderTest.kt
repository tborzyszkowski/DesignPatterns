package pkawa.builder

import org.junit.Assert.assertEquals
import org.junit.Assert.assertTrue
import org.junit.Test
import kotlin.math.abs

class BuilderTest {
    @Test
    fun createHuman() {
        val human = Human.Builder
            .age(23)
            .education(Education.HIGHER)
            .eyeColor("Brown")
            .height(1.78)
            .race(Race.CAUCASIAN)
            .weight(79.5)
            .build()

        assertEquals(human.education, Education.HIGHER)
        assertEquals(human.age, 23)
        assertEquals(human.race, Race.CAUCASIAN)
        assertEquals(human.eyeColor, "Brown")
        assertTrue(abs(human.weight - 79.5 ) <= 0.005)
        assertTrue(abs(human.height - 1.78) <= 0.005)
    }
}

/*
Builder vs Factory:
1. Builder w tym przypadku wygrywa, ponieważ mamy bardzo złożony obiekt, który wymaga customowego nadawania, krok po kroku
wartości. Ciężko jest tutaj znaleźć sensowny przykład rodziny problemów, które mogłaby zgrupować fabryka
2. O ile sam builder pattern jest bardziej skomplikowany niż fabryka, to w tym przypadku code readability i reusability jest
o wiele efektywniejszy.
 */