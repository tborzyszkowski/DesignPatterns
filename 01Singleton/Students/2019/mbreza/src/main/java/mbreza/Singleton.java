package mbreza;

import java.io.Serializable;

public class Singleton implements Serializable {

    private static Singleton instance;

    private Singleton(){}

    public static Singleton getInstance(String value){
        if(instance == null){
            synchronized (Singleton.class) {
                if(instance == null){
                    if(value.equals("One")){
                        instance = new SingletonOne();
                    } else if(value.equals("Two")){
                        instance = new SingletonTwo();
                    }  else {
                        instance = new Singleton();
                    }
                }
            }
        }
        return instance;
    }

    protected Object readResolve() {
        return getInstance("");
    }

    public void cleanUp(){
        instance = null;
    }

    public String writeSomething() {
        return "Nothing";
    }

    private static class SingletonOne extends Singleton {

        private SingletonOne(){
            super();
        }

        @Override
        public String writeSomething() {
            return "One";
        }
    }

    private static class SingletonTwo extends Singleton {

        private SingletonTwo(){
            super();
        }

        @Override
        public String writeSomething() {
            return "Two";
        }
    }


}

