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
