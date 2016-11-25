package inheritance;

/**
 * Singletony implementujące odpowiednik dziedziczenia poprzez kompozycję oraz kompozycję wspomaganą dynamicznym proxy.
 */
public class Test {
    public static void main(String[] args) {
        // Composition
        OtherSingleton singleton = OtherSingleton.getInstance();
        singleton.doSomething();
        singleton.doSomethingElse();
        singleton.doSomethingElse2();

        // Dynamic proxy
        CommonInterface singleton2 = DynamicProxySingleton.getInstance();
        singleton2.doSomething();
        singleton2.doSomethingElse();
        singleton2.doSomethingElse2();
    }
}
