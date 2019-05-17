package Builder.Documents;


public class  Document {


    protected String date;
    protected String place;

    protected Person personalInformation;
    protected Person addressee;

    protected String documentType;

    protected String content;
    protected String substantiation;

    protected String signature;



    public String toString() {


        return  "-------------------------------------------------------------------" +
                "\n|                                        " + place + " , " + date +
                "\n| " + personalInformation +
                "\n| " + ((addressee == null) ? " " : addressee) +
                "\n|\n|                         " + documentType +

                "\n| " + content +
                "\n|\n| " + substantiation +
                "\n|                                            " + signature +
                "\n-------------------------------------------------------------------\n";
    }
}
