package BuilderOverFactory.FluentBuilder;



public class ProductBuilder{

protected String brand;
protected String name;
protected int size;

protected String fabric;
protected String tie;
protected String sole;

        private int[] sizes = new int[] {42,43,44,45,46,47,48,49};
        private String[] colors = new String[] {"czerwony", "biały", "czarny"};

        public ProductBuilder setName(String name) {
                this.name = name;
                return this;
        }

        public ProductBuilder setSize(int size) {
                for (int available : sizes) if(size == available) this.size = size;
                return this;
        }

        public ProductBuilder setBrand(String brand){
            this.brand = brand; return this;
        }

        public ProductBuilder setFabric(String color) {
            for (String available : colors) if(color == available) this.fabric = "Syntetyczno-tekstylna cholewka";
            if(fabric == null) this.fabric = "Tekstylna cholewka";
            return this;
        }

        public ProductBuilder setTie(int price) {
                tie =  price > 1000 ? "sznurowane" : "Zapięcie na rzep";
                return this;
        }

        public ProductBuilder setSole(int price) {
                sole =  price > 1000 ? "Obniżona podeszwa środkowa" : "Sprężysta podeszwa środkowa";
                return this;
        }

        public Product build() {
            Product product = new Product();
            product.setName(name);
            product.setSize(size);
            product.setBrand(brand);
            product.setFabric(fabric);
            product.setTie(tie);
            product.setSole(sole);
            return product;
            }
}
