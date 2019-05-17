package Builder.Documents;

import Builder.Builder;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Sue extends Builder {

    Person sender = new Person(
            "Jan",
            "Kowalski",
            "ul. Przykładowa 1",
            "Gdynia 01-494",
            123456789,
            "jakowal@metal.com",
            true);

    @Override
    protected void setPlace() {
        document.place = "Gdynia";
    }

    @Override
    protected void setDate() {
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
        Date date = new Date();
        document.date = dateFormat.format(date);
    }

    @Override
    protected void setPersonalInformation() {
        document.personalInformation = sender;
    }

    @Override
    protected void setAddressee() {
        document.addressee = new Person(
                "Andrzej",
                "Nowak",
                "ul. Asfaltowa 1",
                "Warszawa 83-033",
                987654321,
                "",
                false);
    }

    @Override
    protected void setDocumentType() {

        document.documentType = "Zażalenie";
    }

    @Override
    protected void setContent() {

        document.content = "Zaskarżam .......................................................\n| ...............................................";
    }

    @Override
    protected void setSubstantion() {
        document.substantiation = "Dowód decyzji ...................................................\n| ........................................................";
    }

    @Override
    protected void setSignature() {
        document.signature = "Z poważaniem " +
                "\n|                                              " + sender.surname;
    }


}
