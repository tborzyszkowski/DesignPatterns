# 06. Dynamic Proxy w Javie

## Cel tematu

Pokazac Java Dynamic Proxy przez InvocationHandler i Proxy.newProxyInstance.

## Przyklad kodu (Java)

```java
import java.lang.reflect.*;

interface PaymentService {
    String pay(String orderId);
}

class RealPaymentService implements PaymentService {
    public String pay(String orderId) {
        return "PAID:" + orderId;
    }
}

class TimingHandler implements InvocationHandler {
    private final Object target;

    TimingHandler(Object target) {
        this.target = target;
    }

    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        long start = System.nanoTime();
        try {
            return method.invoke(target, args);
        } finally {
            long elapsedUs = (System.nanoTime() - start) / 1000;
            System.out.println(method.getName() + " took " + elapsedUs + " us");
        }
    }
}

public class JavaDynamicProxyDemo {
    public static void main(String[] args) {
        PaymentService service = (PaymentService) Proxy.newProxyInstance(
            PaymentService.class.getClassLoader(),
            new Class<?>[] { PaymentService.class },
            new TimingHandler(new RealPaymentService())
        );

        System.out.println(service.pay("ORD-42"));
    }
}
```

## Wnioski

1. Interceptor dziala dla wszystkich metod interfejsu.
2. Dynamic Proxy wymaga pracy przez interfejs.
3. Wyjatki z reflection trzeba obslugiwac jawnie.
