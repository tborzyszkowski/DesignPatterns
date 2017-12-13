package pl.mhallman.java.factoryRegPattern.store;

import pl.mhallman.java.factoryRegPattern.factory.CookieFactory;
import pl.mhallman.java.factoryRegPattern.model.Cookie;

import java.lang.reflect.InvocationTargetException;

public class CookieStore {

    private CookieFactory factory;

    public CookieStore(CookieFactory factory) {
        this.factory = factory;
    }

    public Cookie sellCookie(final String cookieType) throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        return factory.bakeCookie(cookieType);
    }

}
