package PersonListAdapter;
import PESEL.Sex;
import Person.*;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.util.ArrayList;
import java.util.function.Function;

    public class PersonListAdapter {

        public Function<String, ArrayList<Person>> getPersonsList;

        public PersonListAdapter(PersonsCSV csv) {
            getPersonsList = input -> {
                ArrayList<Person> list = new ArrayList<>();

                String[] lines = input.split("\n");

                for (String line : lines) {
                    String[] fields = line.split(", ");
                    list.add(new Baby(fields[0], fields[1], fields[2], fields[3].equals("MALE") ? Sex.MALE : Sex.FEMALE));
                }
                return list;
            };
        }

        public PersonListAdapter(PersonsJSON json) {
            getPersonsList = input -> {
                Gson gson = new Gson();
                return gson.fromJson(input, new TypeToken<ArrayList<Baby>>() {
                }.getType());
            };
        }

        public static ArrayList<PeselDecoratedBaby> addPeselsToList(ArrayList<Person> list){
            ArrayList<PeselDecoratedBaby> output = new ArrayList<>();
            list.forEach(baby -> output.add(new PeselDecoratedBaby((Baby) baby)));
            return output;
        }
    }
