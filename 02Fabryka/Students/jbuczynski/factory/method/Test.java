package factory.method;

/**
 * Created by jakub on 1/14/17.
 */
public class Test {

    public static void main(String[] args) {
        System.out.println("wee need mobile app, order one in familiar agent ");
        Agent agent;
        System.out.println("Unfortunately this agent works with very bad softwarte producer");
        agent = new Agent(new BadSoftwareProducet());
        System.out.println("This product is not what we want " + agent.requestProduct(ProductType.MOBILE_APP));
        System.out.println("I know another agent");
        agent = new Agent(new GoodSoftwareProducet());
        System.out.println("This agent delivers good product becouse works with good producer " +agent.requestProduct(ProductType.MOBILE_APP));
    }
}
