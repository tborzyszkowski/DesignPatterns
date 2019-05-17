package FluentBuilder;

import Builder.Documents.Person;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Document {


    protected String date;
    protected String place;

    protected Person personalInformation;
    protected Person addressee;

    protected String documentType;

    protected String content;
    protected String substantiation;

    protected String signature;

    public void setPlace(String place){
        this.place = place;
    }

    public void setDate(Date date){
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
        this.date = dateFormat.format(date);
    }

    public void setPersonalInformation(Person person){
        this.personalInformation = person;
    }

    public void setAddressee(Person addressee) {
        this.addressee = addressee;
    }

    public void setDocumentType(String documentType){
        this.documentType = documentType;
    }

    public void setContent(String content){
        this.content = content;
    }

    public void setSubstantion(String substantiation){
        this.substantiation = substantiation;
    }

    public void setSignature(String signature){
        this.signature = signature;
    }



    public String toString() {
        return  "-------------------------------------------------------------------" +
                "\n|                                        " + place + " , " + date +
                "\n| " + personalInformation +
                "\n| " + addressee +
                "\n|\n|                         " + documentType +

                "\n| " + content +
                "\n|\n| " + substantiation +
                "\n|                                            " + signature +
                "\n-------------------------------------------------------------------\n";
    }
}
