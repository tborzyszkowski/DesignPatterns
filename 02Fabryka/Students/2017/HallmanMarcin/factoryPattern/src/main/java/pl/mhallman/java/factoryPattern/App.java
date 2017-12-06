package pl.mhallman.java.factoryPattern;

import org.apache.log4j.Logger;
import pl.mhallman.java.factoryPattern.factory.CookieFactory;
import pl.mhallman.java.factoryPattern.model.Cookie;
import pl.mhallman.java.factoryPattern.store.CookieStore;

import java.util.ArrayList;
import java.util.List;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        List<Cookie> clientCookies = new ArrayList<>();
        Logger LOG = Logger.getRootLogger();
        CookieFactory mySuperFactory = new CookieFactory();
        CookieStore store = new CookieStore(mySuperFactory);

        clientCookies.add(store.sellCookie("veggie"));
        clientCookies.add(store.sellCookie("crumble"));

        for(Cookie cookie : clientCookies) {
            LOG.info("We have just sold you :: " + cookie.toString());
        }
    }
}
