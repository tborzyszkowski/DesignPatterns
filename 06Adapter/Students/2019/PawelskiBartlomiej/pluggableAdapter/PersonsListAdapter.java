package pluggableAdapter;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.util.ArrayList;
import java.util.function.Function;

public class PersonsListAdapter {

    public Function<String, ArrayList<Person>> getPersonsList;

    public PersonsListAdapter(PersonsCSV csv) {
        getPersonsList = input -> {
            ArrayList<Person> list = new ArrayList<>();

            String[] lines = input.split("\n");

            for (String line : lines) {
                String[] fields = line.split(", ");
                list.add(new Person(fields[0], fields[1], Integer.valueOf(fields[2])));
            }
            return list;
        };
    }

    public PersonsListAdapter(PersonsJSON json) {
        getPersonsList = input -> {
            Gson gson = new Gson();
            return gson.fromJson(input, new TypeToken<ArrayList<Person>>() {
            }.getType());
        };
    }
}
