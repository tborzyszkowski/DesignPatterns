package zad2;

public class Adapter implements I_KartaZdrowia,I_HealthCard {

    private KartaZdrowia kartaZdrowia;
    private HealthCard healthCard;
    private int cardType;

    public Adapter(KartaZdrowia kartaZdrowia) {
        cardType = 1;
        this.kartaZdrowia = kartaZdrowia;
    }

    public Adapter(HealthCard healthCard) {
        cardType = 2;
        this.healthCard = healthCard;
    }


    @Override
    public String getName() {
        if (cardType == 1){
            return this.kartaZdrowia.imie();
        } else {
            return this.healthCard.getName();
        }

    }

    @Override
    public double getHeightInInches() {
        if (cardType == 1){
            return this.kartaZdrowia.wagaWKg() * 0.39;
        } else {
            return this.healthCard.getHeightInInches();
        }

    }

    @Override
    public double getWeightInPounds() {
        if (cardType == 1){
            return this.kartaZdrowia.wagaWKg() * 2.2;
        } else {
            return this.healthCard.getWeightInPounds();
        }
    }

    @Override
    public String imie() {
        if (cardType == 1){
            return this.kartaZdrowia.imie();
        } else {
            return this.healthCard.getName();
        }
    }

    @Override
    public double wzrostWCm() {
        if (cardType == 1){
            return this.kartaZdrowia.wzrostWCm();
        } else {
            return this.healthCard.getHeightInInches() * 2.54;
        }
    }

    @Override
    public double wagaWKg() {
        if (cardType == 2){
            return this.healthCard.getWeightInPounds() * 0.45;
        } else {
            return this.kartaZdrowia.wagaWKg();
        }
    }

    @Override
    public void wyswietl() {
        if (cardType == 1){
            this.kartaZdrowia.wyswietl();
        } else {
            System.out.println(
                    "KARTA ZDROWIA" + "\n"
                            + "Imię: " + imie() + "\n"
                            + "Wzrost: " + wzrostWCm() + "\n"
                            + "Waga: " + wagaWKg()
            );
        }
    }


    @Override
    public void display() {
        if (cardType == 1){
            System.out.println(
                    "HEALTH CARD" + "\n"
                            + "Name: " + getName() + "\n"
                            + "Height: " + getHeightInInches() + "\n"
                            + "Weight: " + getWeightInPounds()
            );
        } else {
            this.healthCard.display();
        }

    }
}
