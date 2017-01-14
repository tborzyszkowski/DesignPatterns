package adapter;

/**
 * Created by jakub on 1/14/17.
 */
public class Boss {

    FlexibleBackendProgrammer programmer;

    public void interviewProgrammer(ConcreteFlexibleBackendProgrammer p) {
        p.showBascicProgrammingKnowledge();
        programmer = p;
    }

    public void orderJavaJob() {
        System.out.println("Boss orders project in java");
        programmer.programmInJava();
    }

    public void orderCSharpJob() {
        System.out.println("Boss orders project in CSharp");
        programmer.programmInCSharp();
    }
}
