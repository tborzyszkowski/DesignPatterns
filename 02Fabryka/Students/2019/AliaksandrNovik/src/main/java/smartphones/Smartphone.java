package smartphones;

public abstract class Smartphone{
    
    protected String model;
    protected double display;
    protected String proc;
    protected short battery;
    
    public void phoneAssembling(){
        System.out.println("Model: " + model);
        System.out.println("Display size: " + display + "  inches");
        System.out.println("CPU model: " + proc);
        System.out.println("Battery capacity: " + battery + "mAh");
    }
    
    public void crashTest(){
        System.out.println("Crash test is done");
    }
    
    public void batteryLifeTest(){
        System.out.println("Battery life test is done");
    }
    
    public void pack(){
        System.out.println("Pack smartphone");
    }
}