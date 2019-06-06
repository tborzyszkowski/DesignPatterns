import java.util.ArrayList;

public class Teacher {
    private String id;
    private String name;
    private String surname;

    public Teacher(String id, String name, String surname) {
        this.id = id;
        this.name = name;
        this.surname = surname;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public String teachersToString(ArrayList<Teacher> teachers) {
        String output = "";

        for (int i = 0; i < teachers.size(); i++){
            output = output + "Teacher" + i + ": " + teachers.get(i).toString() + "\n";
        }

        return output;
    };

    @Override
    public String toString() {
        return "Teacher{" +
                "surname='" + surname + '\'' +
                ", name='" + name + '\'' +
                "}\n";
    }
}
