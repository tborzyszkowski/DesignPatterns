package AbstractFactory;

public abstract class Car {
        public abstract String getBrandName();
        public abstract String getModel();
        public abstract String getType();
        public abstract String getFuelType();
        public abstract int getPrice();

        @Override
        public String toString() {
            return  "name = " + this.getBrandName() +
                    ", model = " + this.getModel() +
                    ", type = " + this.getType() +
                    ", fuel type = " + this.getFuelType() +
                    ", price = " + this.getPrice();
        }
}

