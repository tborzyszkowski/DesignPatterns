package toolShop;

import tools.Tool;

import java.util.ArrayList;

public class ToolShop {
    private static ToolShop instance;
    private static ArrayList<Tool> toolsList = new ArrayList<Tool>();
    //singleton
    public static ToolShop getInstance() {
        if (instance == null) {
            synchronized (ToolShop.class) {
                if (instance == null) {
                    instance = new ToolShop();
                }
            }
        }
        return instance;
    }

    public void addToolToToolShop(Tool tool){
        toolsList.add(tool);
    }

    public static ArrayList<Tool> getToolsList(){
        return toolsList;
    }

    public Tool getToolFromToolsList(String toolName){
        Tool tool = null;
        for(Tool d : toolsList){
            if(d.getBrand() != null && d.getBrand().contains(toolName))
            tool = d;
            }
        return tool;
    }
}
