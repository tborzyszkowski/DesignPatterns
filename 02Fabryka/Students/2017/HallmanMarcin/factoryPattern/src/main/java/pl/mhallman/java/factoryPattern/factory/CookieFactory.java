package pl.mhallman.java.factoryPattern.factory;

import pl.mhallman.java.factoryPattern.model.ChocoCookie;
import pl.mhallman.java.factoryPattern.model.Cookie;
import pl.mhallman.java.factoryPattern.model.CrumbleCookie;
import pl.mhallman.java.factoryPattern.model.VeggieCookie;

public class CookieFactory {

    public static final String VEGGIE = "veggie";
    public static final String CHOCO = "choco";
    public static final String CRUMBLE = "crumble";

    public Cookie bakeCookie(final String cookieType) {
        Cookie cookie = null;
        switch (cookieType) {
            case VEGGIE:
                cookie = new VeggieCookie();
                break;
            case CHOCO:
                cookie = new ChocoCookie();
                break;
            case CRUMBLE:
                cookie = new CrumbleCookie();
                break;
        }
        return cookie;
    }

}
