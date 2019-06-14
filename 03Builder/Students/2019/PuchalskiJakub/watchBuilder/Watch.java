package watchBuilder;

public class Watch {

    private String watchType;
    private String movement;
    private String glass;
    private String strap;

    public Watch(String watchType) {
        this.watchType = watchType;
    }

    public void setMovement(String movement) {
        this.movement = movement;
    }

    public void setGlass(String glass) {
        this.glass = glass;
    }

    public void setStrap(String strap) {
        this.strap = strap;
    }

    public void showDetails(){

        System.out.println(
                        "Watch type: " + watchType + "\n" +
                        "Movement: " + movement + "\n" +
                        "Glass: " + glass + "\n" +
                        "Strap: " + strap + "\n"
        );
    }
}
