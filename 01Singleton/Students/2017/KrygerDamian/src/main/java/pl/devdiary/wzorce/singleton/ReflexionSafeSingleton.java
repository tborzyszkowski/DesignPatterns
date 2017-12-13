package pl.devdiary.wzorce.singleton;

public class ReflexionSafeSingleton {
    private static ReflexionSafeSingleton instance;

    private ReflexionSafeSingleton() {
        if(instance != null)
            throw new IllegalStateException("Nie można utworzyć nowej instancji. Proszę, użyj do tego metody getInstance().");
    }

    public static ReflexionSafeSingleton getInstance() {
        if(instance == null) {
            instance = new ReflexionSafeSingleton();
        }

        return instance;
    }
}
