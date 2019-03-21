import java.io.*;

enum King {
    INSTANCE;

    String name = "";

    public String getKingsName() {
        System.out.println("Wywołano zapytanie o imię aktualnego króla...");
        return name.isEmpty() ? "Aktualnie nikt nie zasiada na tronie!" : "Aktualnym królem jest: " + name;
    }

    public void setKingsName(String name) {
        System.out.println("Dokonano koronizacji nowego króla. Przyjmuje on imię: " + name);
        this.name = name;
    }

    public void deleteCurrentKing() {
        this.name = "";
    }

    public static void serialize() throws IOException {
        try (ObjectOutputStream stream = new ObjectOutputStream(new FileOutputStream("src/serialize.txt"))) {
            //stream.writeObject(INSTANCE);
            stream.writeObject(INSTANCE.name);
        }
    }

    public static void deserialize() throws ClassNotFoundException, IOException {
        try (ObjectInputStream stream = new ObjectInputStream(new FileInputStream("src/serialize.txt"))) {
            INSTANCE.name = (String) stream.readObject();
        }
    }
}
