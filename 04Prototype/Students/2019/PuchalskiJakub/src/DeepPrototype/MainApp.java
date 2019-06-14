package DeepPrototype;

public class MainApp {

    public static void main(String[] args) throws CloneNotSupportedException {

        PrototypeManager prototypeManager = new PrototypeManager();

        prototypeManager.loadWatches();

        Watch classicWatch = prototypeManager.getWatch(WatchTypes.ClassicWatch);
        Watch classicWatchCopy = (Watch) classicWatch.clone();

        System.out.println(classicWatchCopy.hashCode() + "   " + classicWatch.hashCode());


        System.out.println(classicWatch == classicWatchCopy);


        //depth2
        System.out.println("--------------------------");

        System.out.println(
                classicWatch.getGlassType() == classicWatchCopy.getGlassType()
        );
        System.out.println(
                classicWatch.getGlassType().getNameOfType().equals(classicWatchCopy.getGlassType().getNameOfType())
        );

        //depth3
        System.out.println("--------------------------");

        System.out.println(classicWatch.getStrapType().getClaspType() == classicWatchCopy
                .getStrapType().getClaspType());
        System.out.println(classicWatch.getStrapType().getClaspType().getNameOfType().equals(classicWatchCopy
                .getStrapType().getClaspType().getNameOfType()));

        System.out.println("--------------------------");

        classicWatch.getStrapType().getClaspType().setNameOfType("Rubber");
        System.out.println(classicWatch.getStrapType().getClaspType().getNameOfType() == classicWatchCopy
                .getStrapType().getClaspType()
                .getNameOfType());

    }

}
