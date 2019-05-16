import java.sql.SQLOutput;
import java.util.ArrayList;
import java.util.Objects;

public class Main {
    public static void main(String[] args) throws CloneNotSupportedException {

        /////////////////////////SIMPLE///PROTOTYPE////////////////////////////////

        System.out.println("\n");

        Student student = StudentPrototype.studentPrototype();
        Student clone = (Student) student.clone();
        Student studentDeepCopy = student.deepCopy();

        System.out.println(student.toString());
        System.out.println(clone.toString());
        System.out.println(studentDeepCopy.toString());

        System.out.println("\n\n///////////////////////////////////\n\n");

        /////////////////////////DEEP/////PROTOTYPE////////////////////////////////

        School school = SchoolPrototype.fullSchoolPrototype();
        School schoolDeepCopy = school.deepCopy();

        System.out.println(school.toString());
        System.out.println(schoolDeepCopy.toString());


    }
}
