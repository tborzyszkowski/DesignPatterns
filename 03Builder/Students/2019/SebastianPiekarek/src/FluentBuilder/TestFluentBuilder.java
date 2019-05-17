package FluentBuilder;

import Builder.Documents.Person;

import java.util.Date;

public class TestFluentBuilder {

    public static void main(String[] args) {


        Document sueDocument = new DocumentBuilder()
                .setPlace("Gdynia")
                .setDate(new Date())
                .setPersonalInformation(new Person(
                        "Jan",
                        "Kowalski",
                        "ul. Przykładowa 1",
                        "Gdynia 01-494",
                        123456789,
                        "jakowal@metal.com",
                        true))
                .setAddressee(new Person(
                        "Andrzej",
                        "Nowak",
                        "ul. Asfaltowa 1",
                        "Warszawa 83-033",
                        987654321,
                        "",
                        false))
                .setDocumentType("Zażalenie")
                .setContent("Zaskarżam .......................................................\n| ...............................................")
                .setSubstantion("Dowód decyzji ...................................................\n| ........................................................")
                .setSignature("Z poważaniem \n|" +
                        "                                               Kowalski")
                .build();

        System.out.println(sueDocument);

    }


}
