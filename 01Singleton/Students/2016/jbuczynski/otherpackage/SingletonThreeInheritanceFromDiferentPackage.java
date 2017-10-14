package otherpackage;

import protectedpackage.CannotInstantiateDirectlyException;
import protectedpackage.SingletonTwo;

import java.util.logging.Logger;

/**
 * Created by jakub on 12/8/16.
 */
public class SingletonThreeInheritanceFromDiferentPackage extends SingletonTwo {

    private static final Logger logger = Logger.getLogger(SingletonThreeInheritanceFromDiferentPackage.class.getSimpleName());

    public SingletonThreeInheritanceFromDiferentPackage() throws CannotInstantiateDirectlyException {
    }

    public static SingletonThreeInheritanceFromDiferentPackage getInstance() {
        return (SingletonThreeInheritanceFromDiferentPackage) getInstance(SingletonThreeInheritanceFromDiferentPackage.class);
    }

    public void singletonThreeMethod() {
        logger.info("hello from inheritance three, inheriting object in different package!");
    }

}
