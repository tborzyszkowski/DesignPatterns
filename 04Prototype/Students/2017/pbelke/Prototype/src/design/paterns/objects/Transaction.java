package design.paterns.objects;

public class Transaction implements Cloneable {

    private String type;
    private Person buyer;
    private Person seller;

    public Transaction() {
    }

    public Transaction(String type) {
        this.type = type;
    }

    @Override
    public Transaction clone() throws CloneNotSupportedException {
        Transaction newTransaction = new Transaction(this.type);
        newTransaction.buyer = buyer.clone();
        newTransaction.seller = seller.clone();
        return newTransaction;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Person getBuyer() {
        return buyer;
    }

    public void setBuyer(Person buyer) {
        this.buyer = buyer;
    }

    public Person getSeller() {
        return seller;
    }

    public void setSeller(Person seller) {
        this.seller = seller;
    }

    @Override
    public String toString() {
        return "Transaction{" +
                "type='" + type + '\'' +
                ", buyer=" + buyer.toString() +
                ", seller=" + seller.toString() +
                '}';
    }
}
