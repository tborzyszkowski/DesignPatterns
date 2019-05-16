import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.Objects;

public class School {
    private ArrayList<Class> classes;
    private ArrayList<Teacher> teachers;

    School(ArrayList<Class> classes, ArrayList<Teacher> teachers) {
        this.classes = classes;
        this.teachers = teachers;
    }

    public ArrayList<Class> getClasses() {
        return classes;
    }

    public void setClasses(ArrayList<Class> classes) {
        this.classes = classes;
    }

    public ArrayList<Teacher> getTeachers() {
        return teachers;
    }

    public void setTeachers(ArrayList<Teacher> teachers) {
        this.teachers = teachers;
    }

    public String collectionToString(ArrayList collection) {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < collection.size(); i++){
            output.append(collection.get(i).toString());
        }
        return output.toString();
    }

    @Override
    public String toString() {
        return "School:\n" +
                collectionToString(classes)+
                "\n\nTeachers:\n" + collectionToString(teachers) +
                "\n\n\n\n";
    }

    School deepCopy() {
        Gson gson = new Gson();
        String json = gson.toJson(this);
        return gson.fromJson(json, School.class);
    }


}
