import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

public class DynamicProxy implements InvocationHandler, OtherInterface {
    private final SomeInterface target;

    private DynamicProxy(SomeInterface target) {
        this.target = target;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        if (method.getDeclaringClass().equals(SomeInterface.class))
            return method.invoke(target, args);
        else
            return method.invoke(this, args);
    }

    @Override
    public String method3() {
        return this.getClass().getName() + ": Tu metoda nr 3!";
    }

    public static SumInterface getInstance(SomeInterface target) {
        return (SumInterface) Proxy.newProxyInstance(target.getClass().getClassLoader(), new Class[]{SumInterface.class}, new DynamicProxy(target));
    }
}
