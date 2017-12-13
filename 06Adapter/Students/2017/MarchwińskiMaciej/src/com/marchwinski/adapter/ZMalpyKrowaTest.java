package com.marchwinski.adapter;

public class ZMalpyKrowaTest {

    public static void main(String[] args) {
        IKrowa krowa = new KrowaMleczna();
        krowa.zamuczNo();

        Szympans szympans = new Szympans();
        szympans.rzucBananem();

        IKrowa szympansKrowa = new SzympansAdapter(szympans);
        szympansKrowa.zamuczNo();
    }

}
