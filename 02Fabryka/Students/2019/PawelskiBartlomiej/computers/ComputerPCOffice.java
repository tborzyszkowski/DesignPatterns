package computers;

import com.google.gson.Gson;

public class ComputerPCOffice extends Computer {

    public ComputerPCOffice() {
        type = "PC";
        intendedFor = "Office";
        CPU = "Intel Core i3-8100";
        GPU = "integrated in CPU";
        RAMinGB = 8;
        SSDinGB = 256;
    }

    public Computer computerClone() {
        Gson gson = new Gson();
        String json = gson.toJson(this);
        return gson.fromJson(json, ComputerPCOffice.class);
    }

}
