package Builder;



public class Director {
    private Builder builder;

    public void setBuilder(Builder builder){
        this.builder = builder;
    }

    public void Construct() {
        builder.newDocument();
        builder.setPlace();
        builder.setDate();
        builder.setPersonalInformation();
        builder.setAddressee();
        builder.setDocumentType();
        builder.setContent();
        builder.setSubstantion();
        builder.setSignature();
    }
}
