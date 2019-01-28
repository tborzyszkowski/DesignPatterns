package fluentBuilder;

public class CheeseBurgerBuilder {
    private CheeseBurger cheeseBurger;

    public CheeseBurgerBuilder() {
        this.cheeseBurger = new CheeseBurger();
    }

    public CheeseBurgerBuilder withCutlet(String cutlet) {
        this.cheeseBurger.cutlet = cutlet;
        return this;
    }

    public CheeseBurgerBuilder withLoaf(String loaf) {
        this.cheeseBurger.loaf = loaf;
        return this;
    }

    public CheeseBurgerBuilder withCheese(boolean cheese) {
        this.cheeseBurger.cheese = cheese;
        return this;
    }

    public CheeseBurgerBuilder withTomato(boolean tomato) {
        this.cheeseBurger.tomato = tomato;
        return this;
    }

    public CheeseBurgerBuilder withPrice(int price) {
        this.cheeseBurger.price = price;
        return this;
    }

    public CheeseBurger buildCheeseBurger() {
        return this.cheeseBurger;
    }
}
