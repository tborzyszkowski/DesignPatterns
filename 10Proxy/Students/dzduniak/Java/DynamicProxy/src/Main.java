public class  Main {
    public static void main(String[] args) {
        Target t = new Target();
        SumInterface dp = DynamicProxy.getInstance(t);

        System.out.println(dp.method1());
        System.out.println(dp.method2());
        System.out.println(dp.method3());
    }
}
