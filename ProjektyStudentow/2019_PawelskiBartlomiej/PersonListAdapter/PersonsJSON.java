package PersonListAdapter;
import Person.*;

import com.google.gson.Gson;

import java.util.ArrayList;

public class PersonsJSON {
    private String personsJSON;

    public PersonsJSON(String personJSON) {
        this.personsJSON = personJSON;
    }

    public String getPersonJSON() {
        return personsJSON;
    }

    public void setPersonJSON(String personJSON) {
        this.personsJSON = personJSON;
    }

    @Override
    public String toString() {
        return "PersonsJSON{" +
                "personsJSON='" + personsJSON + '\'' +
                '}';
    }

    public static String listOfPersonToJSON(ArrayList<Person> list) {
        Gson gson = new Gson();
        return gson.toJson(list);
    }
}
