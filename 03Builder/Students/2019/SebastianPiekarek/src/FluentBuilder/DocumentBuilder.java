package FluentBuilder;

import Builder.Documents.Person;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DocumentBuilder {


    protected String date;
    protected String place;

    protected Person personalInformation;
    protected Person addressee;

    protected String documentType;

    protected String content;
    protected String substantiation;

    protected String signature;


    public DocumentBuilder setPlace(String place){
        this.place = place;
        return this;
    }

    public DocumentBuilder setDate(Date date){
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
        this.date = dateFormat.format(date);
        return this;
    }

    public DocumentBuilder setPersonalInformation(Person person){
        this.personalInformation = person;
        return this;
    }

    public DocumentBuilder setAddressee(Person addressee){
        this.addressee = addressee;
        return this;
    }

    public DocumentBuilder setDocumentType(String documentType){
        this.documentType = documentType;
        return this;
    }

    public DocumentBuilder setContent(String content){
        this.content = content;
        return this;
    }

    public DocumentBuilder setSubstantion(String substantiation){
        this.substantiation = substantiation;
        return this;
    }

    public DocumentBuilder setSignature(String signature){
        this.signature = signature;
        return this;
    }



    public Document build() {
        Document document = new Document();
        document.setPlace(place);
        document.setDate(new Date());
        document.setPersonalInformation(personalInformation);
        document.setAddressee(addressee);
        document.setDocumentType(documentType);
        document.setContent(content);
        document.setSubstantion(substantiation);
        document.setSignature(signature);
        return document;

    }

}
