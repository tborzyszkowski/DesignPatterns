public class Target implements SomeInterface {
    @Override
    public String method1() {
        return this.getClass().getName() + ": Tu metoda nr 1!";
    }

    @Override
    public String method2() {
        return this.getClass().getName() + ": Tu metoda nr 2!";
    }
}
