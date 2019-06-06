import PESEL.Sex;
import Person.*;
import PersonListAdapter.*;
import FileSingleton.*;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Scanner;

abstract class UI {

    static void welcome(){
        System.out.println("Witaj w programie PESEL, służącym do generowania numerów PESEL!\n");
    }

    static void generateForPerson(Scanner in) {
        System.out.println("Podaj imię osoby, której PESEL chcesz wygenerować:");
        String name = in.nextLine();
        System.out.println("Podaj nazwisko osoby, której PESEL chcesz wygenerować:");
        String surname = in.nextLine();
        System.out.println("Podaj datę urodzenia (format dd-mm-yyyy) osoby, której PESEL chcesz wygenerować:");
        String date = in.nextLine();
        System.out.println("Podaj płeć (MALE lub FEMALE) osoby, której PESEL chcesz wygenerować:");
        Sex sex = in.nextLine().equals("MALE") || in.nextLine().equals("M") ? Sex.MALE : Sex.FEMALE;

        PeselDecoratedBaby person = new PeselDecoratedBaby(new Baby(name, surname, date, sex));
        System.out.println(person.toString());
    }

    static int startQuestion() {
        System.out.println("Czy wprowadzić dane osoby, której numer PESEL wygenerujesz, czy pobrać dane osób z pliku? \n" +
                "1) Pobierz dane z pliku tekstowego, w formacie json lub csv\n" +
                "2) Wprowadź dane osoby");
        Scanner in = new Scanner(System.in);
        int output = in.nextInt();
        if ((output != 1) && (output != 2)) error();
        return output;
    }

    static void getFileName() {
        System.out.println("Wprowadź nazwę pliku, lub jego ścieżkę jeśli znajduje się poza folderem domowym:");
    }

    static void choice() throws Exception {
        int menuChoice = startQuestion();
        switch (menuChoice) {
            case 1:
                getFileName();
                Scanner file = new Scanner(System.in);
                String fileString = file.nextLine();
                PersonListFile.INSTANCE.fileToString(fileString);
                String extension = fileString.substring(fileString.indexOf(".")+1);
                PersonListAdapter adapter = null;
                if (extension.equals("csv")) {
                    adapter = new PersonListAdapter(new PersonsCSV(PersonListFile.INSTANCE.text));
                }
                else if (extension.equals("json")) {
                    adapter = new PersonListAdapter(new PersonsJSON(PersonListFile.INSTANCE.text));
                }
                assert adapter != null;
                ArrayList<Person> list = adapter.getPersonsList.apply(PersonListFile.INSTANCE.text);
                ArrayList<PeselDecoratedBaby> list2 = PersonListAdapter.addPeselsToList(list);
                list2.forEach(baby -> System.out.println(baby.toString()));
                break;
            case 2:
                Scanner in = new Scanner(System.in);
                UI.generateForPerson(in);
                break;
            default:
                UI.error();
        }
    }

    static void error() {
        System.out.println("Błędne polecenie. Program zostanie teraz zamknięty.");
        System.exit(-2);
    }




}
