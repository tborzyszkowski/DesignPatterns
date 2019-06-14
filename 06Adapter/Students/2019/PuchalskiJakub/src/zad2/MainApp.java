package zad2;

public class MainApp {
    public static void main(String[] args) {

        KartaZdrowia kartaZdrowia = new KartaZdrowia("Jakub", 176, 85);
        HealthCard healthCard = new HealthCard("Jacoob", 73,214);

        Adapter kartaZdrowiaToHealthCare = new Adapter(kartaZdrowia);
        Adapter healthCardToKartaZdrowia = new Adapter(healthCard);

        System.out.println("------------FirstAdapt------------");
        kartaZdrowiaToHealthCare.wyswietl();
        System.out.println("------------------------");
        kartaZdrowiaToHealthCare.display();
        System.out.println("------------SecondAdapt------------");
        healthCardToKartaZdrowia.wyswietl();
        System.out.println("------------------------");
        healthCardToKartaZdrowia.display();
    }
}
