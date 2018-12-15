package simpleBuilder;

public class BridgeBuilder extends ConstructionBuilder {

    public BridgeBuilder() {
        super();
    }

    public void buildFoundations() {
        this.construction.foundations = "Bridge foundations";
    }

    public void buildMainCOnstruction() {
        this.construction.mainConstruction = "Bridge construction";
    }

    public void buildRoof() {
        this.construction.roof = "Bridge roof";
    }

}
