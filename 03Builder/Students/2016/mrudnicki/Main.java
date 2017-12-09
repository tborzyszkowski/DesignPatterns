public class Main {

    public static void main(String[] args) {

        Pizza pizza = new Pizza
                .Builder(Rozmiar.DUZA)
                .ciasto(Ciasto.CIENKIE)
                .skladnik("Pomidory")
                .skladnik("Ser")
                .skladnik("Jalapeno")
                .build();

        System.out.println(pizza);

    }
}

