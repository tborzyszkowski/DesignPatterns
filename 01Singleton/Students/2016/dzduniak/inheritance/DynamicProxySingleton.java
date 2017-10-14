package inheritance;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

public class DynamicProxySingleton implements InvocationHandler, SingletonInterface2 {
    private static final CommonInterface INSTANCE =
            (CommonInterface) Proxy.newProxyInstance(CommonInterface.class.getClassLoader(),
                    new Class[]{CommonInterface.class},
                    new DynamicProxySingleton());

    private DynamicProxySingleton() {

    }

    public void doSomethingElse2() {
        System.out.println("Something else 2!");
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        if (method.getDeclaringClass().equals(SingletonInterface2.class))
            return method.invoke(this, args);
        else
            return method.invoke(Singleton.INSTANCE, args);
    }

    public static CommonInterface getInstance() {
        return INSTANCE;
    }
}
