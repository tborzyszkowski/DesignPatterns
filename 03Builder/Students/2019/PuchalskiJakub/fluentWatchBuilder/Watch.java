package fluentWatchBuilder;

public class Watch {

    private String watchType;
    private String movement;
    private String glass;
    private String strap;

    private Watch(Builder builder) {

        this.watchType = builder.watchType;
        this.movement = builder.movement;
        this.glass = builder.glass;
        this.strap = builder.strap;

    }

    public String getWatchType() {
        return watchType;
    }

    public String getMovement() {
        return movement;
    }

    public String getGlass() {
        return glass;
    }

    public String getStrap() {
        return strap;
    }

    @Override
    public String toString() {
        return  "Watch type: " + watchType + "\n" +
                "Movement: " + movement + "\n" +
                "Glass: " + glass + "\n" +
                "Strap: " + strap + "\n";
    }


    public static class Builder{

        private final String watchType;
        private String movement;
        private String glass;
        private String strap;


        public Builder(final String watchType){
            this.watchType = watchType;
        }

        public Builder movement(final String movement){
            this.movement = movement;
            return this;
        }

        public Builder glass(final String glass){
            this.glass = glass;
            return this;
        }

        public Builder strap(final String strap){
            this.strap = strap;
            return this;
        }

        public Watch build(){
            return new Watch(this);
        }

    }


}
