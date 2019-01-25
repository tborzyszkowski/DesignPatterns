package tools;

public class ToolBuilder {
    private Tool tool;

    public ToolBuilder() {
        this.tool = new Tool();
    }

    public ToolBuilder withBrand(String brand) {
        this.tool.brand = brand;
        return this;
    }

    public ToolBuilder withName(String name) {
        this.tool.name = name;
        return this;
    }

    public ToolBuilder withModel(String model) {
        this.tool.model = model;
        return this;
    }

    public ToolBuilder withType(String type) {
        this.tool.type = type;
        return this;
    }

    public ToolBuilder withPower(int power) {
        this.tool.power = power;
        return this;
    }

    public ToolBuilder withPrice(int price) {
        this.tool.price = price;
        return this;
    }

    public ToolBuilder withQuantity(int quantity){
        this.tool.quantity = quantity;
        return this;
    }

    public Tool buildTool() {
        return this.tool;
    }
}
