package design.patterns;

import design.patterns.objects.LandlinePhone;
import design.patterns.objects.MobilePhone;

public class MobilePhoneAdapter implements MobilePhone {

    private LandlinePhone landlinePhone;

    public MobilePhoneAdapter(LandlinePhone landlinePhone) {
        this.landlinePhone = landlinePhone;
    }

    @Override
    public void pickNumber() {
        landlinePhone.pickNumber();
        System.out.println("Numer możesz również wybrać z pamięci karty SIM");
    }

    @Override
    public void saveNumber() {
        landlinePhone.saveNumber();
        System.out.println("Numer możesz również zapisać na karcie SIM");
    }
}
