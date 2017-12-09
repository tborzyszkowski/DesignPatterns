package com.marchwinski.prototype.constructorCopy;

public class SandwichTester {
    public static void main(String[] args) {
        Sandwich motherSandwich = new Sandwich(new Meat("Baleron", 3), new Cheese(new KindOfCheese("Edamski"), 7), new Sauce("Kieczup"));
        System.out.println("Mama " + motherSandwich);

        Sandwich sonSandwich = new Sandwich(motherSandwich);
        System.out.println("Son " + sonSandwich);
        sonSandwich.getMeat().setKindOfMeat("Poledwica sopocka");

        System.out.println("Mama " + motherSandwich);
        System.out.println("Son " + sonSandwich);

    }
}
