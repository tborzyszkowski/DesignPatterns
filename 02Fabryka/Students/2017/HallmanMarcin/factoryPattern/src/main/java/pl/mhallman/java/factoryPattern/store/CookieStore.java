package pl.mhallman.java.factoryPattern.store;

import pl.mhallman.java.factoryPattern.factory.CookieFactory;
import pl.mhallman.java.factoryPattern.model.Cookie;

public class CookieStore {

    private CookieFactory factory;

    public CookieStore(CookieFactory factory) {
        this.factory = factory;
    }

    public Cookie sellCookie(final String cookieType) {
        return factory.bakeCookie(cookieType);
    }

}
