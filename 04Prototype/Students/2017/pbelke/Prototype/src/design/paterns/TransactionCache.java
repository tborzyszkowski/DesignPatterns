package design.paterns;

import design.paterns.objects.Address;
import design.paterns.objects.Person;
import design.paterns.objects.Transaction;

import java.util.HashMap;
import java.util.Map;

public class TransactionCache {

    private static Map<String, Transaction> transactionTypes = new HashMap<>();

    public static Transaction getTransactionClone(String type) throws CloneNotSupportedException {
        return transactionTypes.get(type).clone();
    }

    public static void generateTransactions() {
        Transaction transactionType1 = new Transaction("Type1");
        Person buyer = new Person("buyerName", "buyerSurnname");
        Address addressBuyer = new Address("buyerStreet", "buyerNumber");
        buyer.setAddress(addressBuyer);
        Person seller = new Person("sellerName", "sellerSurnname");
        Address addressSeller = new Address("sellerStreet", "sellerNumber");
        seller.setAddress(addressSeller);
        transactionType1.setBuyer(buyer);
        transactionType1.setSeller(seller);
        transactionTypes.put(transactionType1.getType(), transactionType1);

        Transaction transactionType2 = new Transaction("Type2");
        Person buyer2 = new Person("buyerName2", "buyerSurnname2");
        Address addressBuyer2 = new Address("buyer2Street", "buyer2Number");
        buyer2.setAddress(addressBuyer2);
        Person seller2 = new Person("sellerName2", "sellerSurnname2");
        Address addressSeller2 = new Address("seller2Street", "seller2Number");
        seller2.setAddress(addressSeller2);
        transactionType2.setBuyer(buyer2);
        transactionType2.setSeller(seller2);
        transactionTypes.put(transactionType2.getType(), transactionType2);
    }

    public static Transaction getTransactionType1() {
        return transactionTypes.get("Type1");
    }
}
