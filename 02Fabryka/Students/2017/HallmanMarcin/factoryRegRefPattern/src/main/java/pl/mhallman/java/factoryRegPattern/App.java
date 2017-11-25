package pl.mhallman.java.factoryRegPattern;

import org.apache.log4j.Logger;
import pl.mhallman.java.factoryRegPattern.factory.CookieFactory;
import pl.mhallman.java.factoryRegPattern.model.Cookie;
import pl.mhallman.java.factoryRegPattern.store.CookieStore;

import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;

public class App 
{

    static
    {
        try
        {
            Class.forName("pl.mhallman.java.factoryRegPattern.model.VeggieCookie");
            Class.forName("pl.mhallman.java.factoryRegPattern.model.CrumbleCookie");
            Class.forName("pl.mhallman.java.factoryRegPattern.model.ChocoCookie");
        }
        catch (ClassNotFoundException any)
        {
            any.printStackTrace();
        }
    }

    public static void main( String[] args ) throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        List<Cookie> clientCookies = new ArrayList<>();
        Logger LOG = Logger.getRootLogger();
        CookieFactory cookieFactory = CookieFactory.INSTANCE;
        CookieStore store = new CookieStore(cookieFactory);

        clientCookies.add(store.sellCookie("VeggieCookie"));
        clientCookies.add(store.sellCookie("CrumbleCookie"));

        for(Cookie cookie : clientCookies) {
            LOG.info("We have just sold you :: " + cookie.toString());
        }
    }
}
