package SimpleFactory;

public class SimpleCarFactory {

    private static SimpleCarFactory simpleCarFactory;
    public static SimpleCarFactory getInstance() {
        if (simpleCarFactory == null) {
            simpleCarFactory = new SimpleCarFactory();
        }
        return simpleCarFactory;
    }


    public static Car getCar(String brandName){
        if(brandName.equals("KIA"))
            return new KIA();
        else if(brandName.equals("Aston Martin"))
            return new AstonMartin();
        else if(brandName.equals("BMW"))
            return new BMW();
        else if(brandName.equals("Nissan"))
            return new Nissan();
        else
            return null;
    }
}
