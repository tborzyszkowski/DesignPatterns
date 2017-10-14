package protectedpackage;

import otherpackage.SingletonThreeInheritanceFromDiferentPackage;

import java.util.logging.Logger;

/**
 * Created by jakub on 12/7/16.
 */
public class Test {
    private static final Logger logger = Logger.getLogger(Test.class.getSimpleName());

    public static void main(String[] args) {

        try {
            logger.info("trying to create singletonTwo object directly");
            new SingletonTwo();
        } catch (Exception e) {
            e.printStackTrace();
        }
        logger.info("\n\n");
        try {
            logger.info("trying to create singletonOne object directly");
            new SingletonOne();
        } catch (Exception e) {
            e.printStackTrace();
        }
        logger.info("\n\n");
        try {
            logger.info("trying to create singletonThree object directly");
            new SingletonThreeInheritanceFromDiferentPackage();
        } catch (Exception e) {
            e.printStackTrace();
        }
        logger.info("\n\n");
        try {
            logger.info("1: trying to obtain singletonOne from its get instance " + SingletonOne.getInstance());
            logger.info("2: trying to obtain singletonOne from its get instance " + SingletonOne.getInstance());
            logger.info("protectedpackage.SingletonOne.getInstance().singletonOneMethod()");
            SingletonOne.getInstance().singletonOneMethod();
        } catch (Exception e) {
            e.printStackTrace();
        }
        logger.info("\n\n");
        try {
            logger.info("1: trying to obtain singletonTwo from its get instance " + SingletonTwo.getInstance());
            logger.info("2: trying to obtain singletonTwo from its get instance " + SingletonTwo.getInstance());
            logger.info("protectedpackage.SingletonTwo.getInstance().singletonOneMethod()");
            SingletonTwo.getInstance().singletonOneMethod();
            logger.info("protectedpackage.SingletonTwo.getInstance().singletonTwoMethod()");
            SingletonTwo.getInstance().singletonTwoMethod();
        } catch (Exception e) {
            e.printStackTrace();
        }
        logger.info("\n\n");
        try {
            logger.info("1: trying to obtain SingletonThreeInheritanceFromDiferentPackage from its get instance " + SingletonTwo.getInstance());
            logger.info("2: trying to obtain SingletonThreeInheritanceFromDiferentPackage from its get instance " + SingletonTwo.getInstance());
            logger.info("SingletonThreeInheritanceFromDiferentPackage.getInstance().singletonOneMethod()");
            SingletonThreeInheritanceFromDiferentPackage.getInstance().singletonOneMethod();
            logger.info("SingletonThreeInheritanceFromDiferentPackage.getInstance().singletonTwoMethod()");
            SingletonThreeInheritanceFromDiferentPackage.getInstance().singletonTwoMethod();
            logger.info("SingletonThreeInheritanceFromDiferentPackage.getInstance().singletonThreeMethod()");
            SingletonThreeInheritanceFromDiferentPackage.getInstance().singletonThreeMethod();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
