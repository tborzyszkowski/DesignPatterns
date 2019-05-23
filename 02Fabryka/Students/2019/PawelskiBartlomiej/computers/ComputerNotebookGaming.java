package computers;

import com.google.gson.Gson;

public class ComputerNotebookGaming extends Computer {

    public ComputerNotebookGaming() {
        type = "PC";
        intendedFor = "Gaming";
        CPU = "Intel Core i7-8750H";
        GPU = "Nvidia GeForce RTX 2060";
        RAMinGB = 16;
        SSDinGB = 512;
    }

    public Computer computerClone() {
            Gson gson = new Gson();
            String json = gson.toJson(this);
            return gson.fromJson(json, ComputerNotebookGaming.class);
    }

}
