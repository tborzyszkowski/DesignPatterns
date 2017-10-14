package functional;

import java.util.function.BiFunction;
import java.util.function.Function;

public class GCDCalculator<T> {
        private final BiFunction<T, T, T> modulo;
        private final Function<T, Boolean> isZero;

        public GCDCalculator(BiFunction<T, T, T> modulo, Function<T, Boolean> isZero) {
            this.modulo = modulo;
            this.isZero = isZero;
        }

        public T gcd(T a, T b) {
            T c;
            while (!isZero.apply(b)) {
                c = modulo.apply(a, b);
                a = b;
                b = c;
            }

            return a;
        }
    }