package computers;

import com.google.gson.Gson;

public class ComputerNotebookOffice extends Computer {

    public ComputerNotebookOffice() {
        type = "Notebook";
        intendedFor = "Office";
        CPU = "Intel Core i5-8250u";
        GPU = "integrated in CPU";
        RAMinGB = 8;
        SSDinGB = 256;
    }

    public Computer computerClone() {
        Gson gson = new Gson();
        String json = gson.toJson(this);
        return gson.fromJson(json, ComputerNotebookOffice.class);
    }

}
