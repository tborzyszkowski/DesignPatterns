package Builder.Documents;

import Builder.Builder;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Authorization extends Builder {

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
        document.addressee = null;
    }

    @Override
    protected void setDocumentType() {

        document.documentType = "Upoważnienie";
    }

    @Override
    protected void setContent() {

        document.content = "Ja, niżej podpisany .............................................\n| ...............................................";
    }

    @Override
    protected void setSubstantion() {
        document.substantiation = "Upoważniam Pana/Panią ...........................................\n| ........................................................";
    }

    @Override
    protected void setSignature() {
        document.signature = "Z poważaniem " +
                "\n|                                              " + sender.surname;
    }


}
