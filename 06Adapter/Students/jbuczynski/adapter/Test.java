package adapter;

/**
 * Created by jakub on 1/14/17.
 */
public class Test {

    public static void main(String[] args) {

        Boss boss = new Boss();
        ConcreteFlexibleBackendProgrammer programmer = new ConcreteFlexibleBackendProgrammer();
        System.out.println("Programmer has interview");
        boss.interviewProgrammer(programmer);
        System.out.println("Programmer passed an interview");

        boss.orderJavaJob();
        System.out.println("Programmer is flexible, boss moves him to another project");
        boss.orderCSharpJob();

    }

}
