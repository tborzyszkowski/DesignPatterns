package Builder;


import Builder.Documents.Document;

public abstract class Builder {

    protected Document document;

    public void newDocument(){
        document = new Document();
    }

    public Document getDocument(){
        return document;
    }

    protected abstract void setPlace();
    protected abstract void setDate();
    protected abstract void setPersonalInformation();
    protected abstract  void setAddressee();
    protected abstract void setDocumentType();
    protected abstract void setContent();
    protected abstract void setSubstantion();
    protected abstract void setSignature();


}
