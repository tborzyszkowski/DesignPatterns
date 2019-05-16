package mbreza.caseForFactory;

public class ErgonomicFactory extends WorksiteFactory {

    private static ErgonomicFactory instance = null;

    private ErgonomicFactory() {
    }

    public static ErgonomicFactory createInstance(){
        if(instance == null) {
            instance = new ErgonomicFactory();
        }
        return instance;
    }

    @Override
    public Chair createChair() {
        return new ErgonomicChair();
    }

    @Override
    public Desk createDesk() {
        return new ErgonomicDesk();
    }
}
