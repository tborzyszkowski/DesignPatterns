import java.util.ArrayList;

public class Class {

    private byte year;
    private ArrayList<Student> students;

    public Class(byte year, ArrayList<Student> students) {
        this.year = year;
        this.students = students;
    }

    public byte getYear() {
        return year;
    }

    public void setYear(byte year) {
        this.year = year;
    }

    public ArrayList<Student> getStudents() {
        return students;
    }

    public void setStudents(ArrayList<Student> students) {
        this.students = students;
    }

    public String studentsToString(ArrayList<Student> students) {
        String output = "\n";

        for (int i = 0; i < students.size(); i++){
            output = output + "Student" + i + ": " + students.get(i).toString() + "\n";
        }

        return output;
    };

    @Override
    public String toString() {
        return "\nClass (" +
                "year=" + year +
                ")\nStudents:" + studentsToString(this.students);
    }
}
