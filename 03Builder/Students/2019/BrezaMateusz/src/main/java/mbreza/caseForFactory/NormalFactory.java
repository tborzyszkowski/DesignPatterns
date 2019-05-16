package mbreza.caseForFactory;

public class NormalFactory extends WorksiteFactory {

    private static NormalFactory instance = null;

    private NormalFactory() {
    }

    public static NormalFactory createInstance(){
        if(instance == null) {
            instance = new NormalFactory();
        }
        return instance;
    }

    @Override
    public Chair createChair() {
        return new NormalChair();
    }

    @Override
    public Desk createDesk() {
        return new NormalDesk();
    }
}
