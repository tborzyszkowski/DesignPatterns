package design.patterns;

import design.patterns.objects.LandlinePhone;
import design.patterns.objects.MobilePhone;
import design.patterns.objects.SamsungLandlinePhone;
import design.patterns.objects.SamsungMobilePhone;

public class Main {

    public static void main(String[] args) {
        MobilePhone mobilePhone = new SamsungMobilePhone();
        LandlinePhone landlinePhone = new SamsungLandlinePhone();
        MobilePhone adapter = new MobilePhoneAdapter(landlinePhone);

        System.out.println();
        System.out.println("Telefon komórkowy");
        mobilePhone.saveNumber();
        mobilePhone.pickNumber();

        System.out.println();
        System.out.println("Telefon stacjonarny");
        landlinePhone.saveNumber();
        landlinePhone.pickNumber();

        System.out.println();
        System.out.println("Użycie adaptera");
        adapter.saveNumber();
        adapter.pickNumber();
    }
}
