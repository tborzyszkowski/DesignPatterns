package adapter;

/**
 * Created by jakub on 1/14/17.
 */
public class ConcreteFlexibleBackendProgrammer implements FlexibleBackendProgrammer {

    JavaProgrammer javaProgrammer;

    public ConcreteFlexibleBackendProgrammer() {
        javaProgrammer = new JavaProgrammer();
        System.out.println("Java programmer has learned CSharp. Now he is flexible programmer");
    }

    @Override
    public void showBascicProgrammingKnowledge() {
        javaProgrammer.showBasics();
    }

    @Override
    public void programmInJava() {
        javaProgrammer.doYourBestInJava();
    }

    @Override
    public void programmInCSharp() {
        System.out.println("I'm actually good in CSharp too");
    }
}
