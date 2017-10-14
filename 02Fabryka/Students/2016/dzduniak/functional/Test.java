package functional;

import java.math.BigInteger;

/**
 * Zadanie poza tematem, prezentujące elementy programowania funkcyjnego w Javie 8.
 */
public class Test {
    public static void main(String[] args) {
        GCDCalculator<Integer> gcd = new GCDCalculator<>((a, b) -> a % b, a -> a == 0);

        System.out.println(gcd.gcd(1000, 130));

        GCDCalculator<BigInteger> gcd2 = new GCDCalculator<>(BigInteger::mod, a -> a.compareTo(BigInteger.ZERO) == 0);
        System.out.println(gcd2.gcd(
                new BigInteger("13453423000006550230000000000000"),
                new BigInteger("76556456461000000000")));
    }
}
