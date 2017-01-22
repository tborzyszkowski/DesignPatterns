package strategy;

public interface Klocek {

    default void jaki() {
        System.out.println(this.getClass().getSimpleName());
    }
}


