import java.util.ArrayList;

abstract class SchoolPrototype {

    static School fullSchoolPrototype(){
        Student one = new Student("0001", "Jacek", "Kowalski");
        Student two = new Student("0002", "Stanisława", "Nowak");
        Student three = new Student("0003", "Krystian", "Warszawski");
        Student four = new Student("0004", "Świętosława", "Górniak");
        Student five = new Student("0005", "Andrzej", "Piętrowy");
        Student six = new Student("0006", "Paulina", "Orzechowska");
        Student seven = new Student("0007", "Paweł", "Grzyb");
        Student eight = new Student("0008", "Andżelika", "Malinowska");
        Student nine = new Student("0009", "Piotr", "Kalinowski");
        Student ten = new Student("0010", "Bolesława", "Pierwsza");

        Teacher a = new Teacher("T0001", "Marek", "Mostowiak");
        Teacher b = new Teacher("T0002", "Hanna", "Mostowiak");
        Teacher c = new Teacher("T0003", "Lucjan", "Mostowiak");

        ArrayList<Teacher> teachers = new ArrayList<>();
        teachers.add(a);
        teachers.add(b);
        teachers.add(c);

        ArrayList<Student> firstYearStudents = new ArrayList<>();
        firstYearStudents.add(one);
        firstYearStudents.add(two);
        firstYearStudents.add(three);

        ArrayList<Student> secondYearStudents = new ArrayList<>();
        secondYearStudents.add(four);
        secondYearStudents.add(five);
        secondYearStudents.add(six);
        secondYearStudents.add(seven);

        ArrayList<Student> thirdYearStudents = new ArrayList<>();
        thirdYearStudents.add(eight);
        thirdYearStudents.add(nine);
        thirdYearStudents.add(ten);

        Class firstClass = new Class((byte)1, firstYearStudents);
        Class secondClass = new Class((byte)2, secondYearStudents);
        Class thirdClass = new Class((byte)3, thirdYearStudents);


        ArrayList<Class> classes = new ArrayList<>();
        classes.add(firstClass);
        classes.add(secondClass);
        classes.add(thirdClass);

        return new School(classes, teachers);
    }






}
