package simpleBuilder;

public class BuildingCompany {

    public void buildConstruction(ConstructionBuilder constructionBuilder){
        constructionBuilder.buildFoundations();
        constructionBuilder.buildRoof();
        constructionBuilder.buildMainCOnstruction();
    }

}
