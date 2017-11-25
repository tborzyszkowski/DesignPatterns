package pl.mhallman.java.factoryRegPattern.factory;

import pl.mhallman.java.factoryRegPattern.model.Cookie;

import java.util.HashMap;

public class CookieFactory {

    public static final CookieFactory INSTANCE = new CookieFactory();
    private HashMap registeredCookiesMap = new HashMap();

    public void registerCookie (final String cookieType, Cookie cookie)
    {
        registeredCookiesMap.put(cookieType, cookie);
    }


    public Cookie bakeCookie(final String cookieType) {
        return ((Cookie)registeredCookiesMap.get(cookieType)).createCookie();
    }

}
