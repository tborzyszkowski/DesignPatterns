package computers;

import com.google.gson.Gson;

public class ComputerPCGaming extends Computer {

    public ComputerPCGaming() {
        type = "PC";
        intendedFor = "Gaming";
        CPU = "Intel Core i5-8400F";
        GPU = "Nvidia GeForce GTX 1660";
        RAMinGB = 32;
        SSDinGB = 1024;
    }

    public Computer computerClone() {
        Gson gson = new Gson();
        String json = gson.toJson(this);
        return gson.fromJson(json, ComputerPCGaming.class);
    }

}
