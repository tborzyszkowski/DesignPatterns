package decorator;

public class Main {

    public static void main(String[] args) {
        System.out.println("example 1 ");
        SongBasic songBasic = new SongBasic("Simple song lalala");

        songBasic.play();

        System.out.println("\nexample 2");
        SongBasicDecorator songBasicDecorator = new SongBasicDecorator(new SongBasic("Sing song lalala"));

        songBasicDecorator.play();
    }
}

