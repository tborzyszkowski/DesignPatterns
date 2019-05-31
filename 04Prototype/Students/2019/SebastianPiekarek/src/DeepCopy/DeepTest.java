package DeepCopy;

import DeepCopy.Voivodeships.Voivodeship;
import junit.framework.TestCase;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertNotEquals;

class DeepTest extends TestCase {

    void loadData()  {
        try{
            DataLoad.loadCache("src\\Data\\ULIC_Urzedowy_2019-04-28.csv");
        }catch (Exception e){
            System.out.println(e);
        }
    }

    @Test
    void testClone() {
        loadData();
        Voivodeship pomeranian = DataLoad.getVoivodeship("Pomorskie");
        Voivodeship pomeranianClone = pomeranian.clone();

        System.out.println("x.clone().getClass() == x.getClass()");
        assertEquals("",pomeranianClone.toString(), pomeranian.toString());

    }

    @Test
    void testCloneReference() {
        loadData();
        Voivodeship pomeranian = DataLoad.getVoivodeship("Pomorskie");
        Voivodeship pomeranianClone = pomeranian.clone();
        System.out.println("x.clone() != x");
        assertNotEquals(pomeranianClone.hashCode(), pomeranian.hashCode());

    }

    @Test
    void testCloneObjects() {
        loadData();
        Voivodeship pomeranian = DataLoad.getVoivodeship("Pomorskie");
        Voivodeship pomeranianClone = pomeranian.clone();
        System.out.println("x.clone().equals(x)");
        assertEquals(pomeranianClone.getCity("Gdynia").getObject("Skwer",2).toString(), pomeranian.getCity("Gdynia").getObject("Skwer",2).toString());

    }

    @Test
    void testCloneIndependence(){
        loadData();
        Voivodeship pomeranian = DataLoad.getVoivodeship("Pomorskie");
        Voivodeship pomeranianClone = pomeranian.clone();
        pomeranianClone.getCity("Sopot").editObject("Parks", 1, "Edytowany objekt");
        pomeranianClone.getCity("Sopot").addObject("Bulwar","Dodany objekt");

        System.out.println("Edited Clone:\n" + pomeranianClone.getCity("Sopot"));
        System.out.println("Original:\n" + pomeranian.getCity("Sopot"));

        assertNotEquals(pomeranianClone.getCity("Sopot").toString(), pomeranian.getCity("Sopot").toString());

    }



}