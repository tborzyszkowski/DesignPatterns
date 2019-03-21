public class Main {
    public static void main(String[] args) {

        System.out.println();

        //Sprawdź imię aktualnego króla
        System.out.println(King.INSTANCE.getKingsName());

        //Umieść na tronie jakiegoś króla
        King.INSTANCE.setKingsName("Jan III");

        //Sprawdź imię aktualnego króla
        System.out.println(King.INSTANCE.getKingsName());
    }
}
