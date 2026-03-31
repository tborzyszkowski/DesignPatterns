# 06. Dynamic Proxy w Javie

## Cel tematu

Pokazac Java Dynamic Proxy przez InvocationHandler i Proxy.newProxyInstance.

## Szczegolowe wyjasnienie koncepcji w Javie

JDK Dynamic Proxy pozwala tworzyc implementacje interfejsu w runtime bez pisania recznej klasy proxy.
Mechanizm opiera sie o `InvocationHandler`, ktory przechwytuje kazde wywolanie metody.

Jak to dziala:

1. Klient pracuje na interfejsie, np. `PaymentService`.
1. `Proxy.newProxyInstance(...)` tworzy obiekt implementujacy ten interfejs.
1. Kazde wywolanie metody trafia do `invoke(proxy, method, args)` w handlerze.
1. Handler wykonuje logike przekrojowa i deleguje przez `method.invoke(target, args)`.
1. Ewentualne `InvocationTargetException` jest rozpakowywane do rzeczywistego wyjatku biznesowego.

Wazne ograniczenie:

1. Standardowy JDK proxy dziala tylko dla interfejsow (nie dla klas).

## Role w przykladzie

1. `PaymentService` - kontrakt (`Subject`).
1. `RealPaymentService` - implementacja docelowa (`RealSubject`).
1. `TimingHandler` - interceptor (`InvocationHandler`).
1. Obiekt z `Proxy.newProxyInstance` - dynamiczny proxy obslugujacy wywolania klienta.

## Diagramy

### Diagram interakcji

![Diagram interakcji](diagrams/dynamic_proxy_java_flow.png)

Zrodlo: [diagrams/01-jdk-proxy-flow.puml](diagrams/01-jdk-proxy-flow.puml)

### Diagram klas

Zrodlo: [diagrams/02-class.puml](diagrams/02-class.puml)

## Program ilustrujacy (Java)

Kod: [Examples/JavaDynamicProxyDemo.java](Examples/JavaDynamicProxyDemo.java)

```java
import java.lang.reflect.*;

interface PaymentService {
    String pay(String orderId);
}

class RealPaymentService implements PaymentService {
    public String pay(String orderId) {
        if (orderId == null || orderId.isBlank()) {
            throw new IllegalArgumentException("orderId is required");
        }

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
        System.out.println("START " + method.getName());

        try {
            Object result = method.invoke(target, args);
            System.out.println("OK " + method.getName());
            return result;
        } catch (InvocationTargetException ex) {
            Throwable inner = ex.getTargetException();
            System.out.println("ERROR " + method.getName() + ": " + inner.getMessage());
            throw inner;
        } finally {
            long elapsedUs = (System.nanoTime() - start) / 1000;
            System.out.println("ELAPSED_US " + method.getName() + "=" + elapsedUs);
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

## Wyjasnienie programu krok po kroku

1. `RealPaymentService` realizuje logike biznesowa i waliduje `orderId`.
1. `TimingHandler` dodaje logi `START/OK/ERROR` oraz pomiar czasu `ELAPSED_US`.
1. Proxy JDK implementuje `PaymentService` i przekazuje kazde wywolanie do handlera.
1. Dla poprawnego `orderId` zwracane jest `PAID:<id>`.
1. Dla blednego argumentu handler rozpakowuje `InvocationTargetException` i rzuca oryginalny wyjatek.

## Uruchom

```bash
cd src/10-proxy/06-dynamic-proxy-java/Examples
javac JavaDynamicProxyDemo.java
java JavaDynamicProxyDemo
```

## Wnioski

1. Interceptor dziala dla wszystkich metod interfejsu.
2. Dynamic Proxy wymaga pracy przez interfejs.
3. Wyjatki z reflection trzeba obslugiwac jawnie.
