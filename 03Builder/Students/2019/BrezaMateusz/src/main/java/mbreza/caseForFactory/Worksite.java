package mbreza.caseForFactory;

public class Worksite {

    private WorksiteFactory worksiteFactory;

    public Worksite(WorksiteFactory worksiteFactory){
        this.worksiteFactory = worksiteFactory;
    }

    public Chair getChair(){
        return worksiteFactory.createChair();
    }

    public Desk getDesk(){
        return  worksiteFactory.createDesk();
    }

}
