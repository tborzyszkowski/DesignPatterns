package Builder;


import Builder.Documents.Authorization;
import Builder.Documents.Document;
import Builder.Documents.Proposal;
import Builder.Documents.Sue;

public class TestBuilder {

    public static void main(String[] args) {

        Director director = new Director();


        Builder proposal = new Proposal();
        director.setBuilder(proposal);
        director.Construct();

        Document proposalDocument = proposal.getDocument();
        System.out.println(proposalDocument);

        Builder sue = new Sue();
        director.setBuilder(sue);
        director.Construct();

        Document sueDocument = sue.getDocument();
        System.out.println(sueDocument);


        Builder authorization = new Authorization();
        director.setBuilder(authorization);
        director.Construct();

        Document authorizationDocument = authorization.getDocument();
        System.out.println(authorizationDocument);

    }
}
