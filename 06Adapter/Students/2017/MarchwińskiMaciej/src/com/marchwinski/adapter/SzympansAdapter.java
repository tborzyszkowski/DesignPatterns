package com.marchwinski.adapter;

public class SzympansAdapter implements IKrowa {

    private Szympans instance;

    public SzympansAdapter(Szympans isntance){
        this.instance = isntance;
    }

    @Override
    public void zamuczNo() {
        instance.rzucBananem();
        System.out.println("Ale po chwili muczy.");
    }
}
