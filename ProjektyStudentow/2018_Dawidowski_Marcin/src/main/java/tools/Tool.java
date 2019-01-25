package tools;

public class Tool {
    public String brand;
    public String name;
    public String model;
    public String type;
    public int power;
    public int price;
    public int quantity;

    public void setBrand(String brand) {
        this.brand = brand;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public void setType(String type) {
        this.type = type;
    }

    public void setPower(int power){
        this.power = power;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public void setQuantity(int quantity) {this.quantity = quantity; }

    public String getBrand(){
        return brand;
    }
    @Override
    public String toString() {
        return  "{Brand = " + brand +
                ", Name = " + name +
                ", Model = " + model +
                ", Type = " + type +
                ", Power = " + power +
                ", Price = " + price +
                ", Quantity = " + quantity +
                "}";
    }
}
