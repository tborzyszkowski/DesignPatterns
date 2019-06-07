package ShallowCopy;

import ShallowCopy.SpotList.Spots;
import junit.framework.TestCase;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertNotEquals;


class TestShallowTest extends TestCase {

    private void loadData()  {
        try{
            DataLoad.loadCache("src\\Data\\ULIC_Urzedowy_2019-04-28.csv");
        }catch (Exception e){
            System.out.println(e);
        }
    }

        @Test
         void testClone() {
            loadData();
            Spots boulevars = DataLoad.getSpot("Bulwar");
            Spots boulevarsClone = boulevars.clone();
            System.out.println("x.clone().getClass() == x.getClass()");
            assertEquals(boulevars.toString(), boulevarsClone.toString());

        }

        @Test
         void testCloneReference() {
            loadData();
            Spots coasts = DataLoad.getSpot("Wybrzeże");
            Spots coastsClone = coasts.clone();
            System.out.println("x.clone() != x");
            assertNotEquals(coastsClone.hashCode(), coasts.hashCode());

        }

        @Test
         void testCloneObjects() {
            loadData();
            Spots coasts = DataLoad.getSpot("Wybrzeże");
            Spots coastsClone = coasts.clone();
            System.out.println("x.clone().equals(x)");
            assertEquals(coastsClone.getItem(2), coasts.getItem(2));

        }

        @Test
         void testCloneIndependence(){
            loadData();
            Spots coasts = DataLoad.getSpot("Wybrzeże");
            Spots coastsClone = coasts.clone();

            coastsClone.editItem(2,"Edytowany objekt");
            coastsClone.removeItem(5);
            coastsClone.addItem("Obiekt dodany");

            System.out.println("Original:\n" + coasts);
            System.out.println("Edited Clone:\n" + coastsClone);


            assertNotEquals(coasts, coastsClone);

    }
}