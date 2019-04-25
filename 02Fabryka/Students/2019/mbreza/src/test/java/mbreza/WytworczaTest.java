package mbreza;

import mbreza.Wytworcza.*;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class WytworczaTest {

    BookFactory fantasyBookFactory;
    BookFactory horrorBookFactory;

    @Before
    public void setup(){
        fantasyBookFactory = FantasyFactory.createInstance();
        horrorBookFactory = HorrorFactory.createInstance();
    }

    @Test
    public void gameOfThronesTest() {
        Book gameOfThrones = fantasyBookFactory.createBook(BookType.GameOfThrones);
        assertEquals(gameOfThrones.getType(), "GameOfThrones");
    }

    @Test
    public void witcherTest() {
        Book witcher = fantasyBookFactory.createBook(BookType.Witcher);
        assertEquals(witcher.getType(), "Witcher");
    }

    @Test
    public void salemsLotTest() {
        Book salemsLot = horrorBookFactory.createBook(BookType.SalemsLot);
        assertEquals(salemsLot.getType(), "SalemsLot");
    }

    @Test
    public void itTest() {
        Book it = horrorBookFactory.createBook(BookType.It);
        assertEquals(it.getType(), "It");
    }

    @Test
    public void timeTest() {
        long start = System.currentTimeMillis();
        for(int i = 0 ; i<1000000 ; i++){
            horrorBookFactory.createBook(BookType.It);
        }
        long end = System.currentTimeMillis();
        System.out.println("Wytworcza time: " + (end - start));
    }
}
