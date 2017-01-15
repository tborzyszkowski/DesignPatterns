package strategy;

import java.util.Random;

public class Main {

    public static void main(String[] args) {
        Random random = new Random();
        Main main = new Main();

        while (true) {
            try {
                Thread.sleep(2000);
                Klocek klocek = main.wybierzKlocek(random.nextInt(3));
                klocek.jaki();

            } catch (InterruptedException e) {
                e.printStackTrace();
            }


        }
    }

    private Klocek wybierzKlocek(int i) {
        if (i == 0) {
            return new DlugiKlocek();
        } else if (i == 1) {
            return new Kwadrat();
        } else if (i == 2) {
            return new Zet();
        } else
            throw new RuntimeException();
    }
}

