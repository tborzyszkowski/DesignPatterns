package design.paterns;

import design.paterns.objects.Transaction;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {

        TransactionCache.generateTransactions();

        try {
            Transaction type1 = TransactionCache.getTransactionClone("Type1");
            System.out.println(type1.toString());
            Transaction type2 = TransactionCache.getTransactionClone("Type2");
            System.out.println(type2.toString());

            long start = System.currentTimeMillis();
            for (int i = 0; i < 100000; i++) {
                TransactionCache.getTransactionClone("Type1");
            }
            long end = System.currentTimeMillis();

            Transaction transactionType1 = TransactionCache.getTransactionType1();
            long startReflect = System.currentTimeMillis();
            for (int i = 0; i < 100000; i++) {
                copy(transactionType1);
            }
            long endReflect = System.currentTimeMillis();

            System.out.println("Clone: " + (end - start));
            System.out.println("Reflect: " + (endReflect - startReflect));

        } catch (CloneNotSupportedException | IllegalAccessException | InstantiationException e) {
            e.printStackTrace();
        }
    }

    private static Transaction copy(Transaction entity) throws IllegalAccessException, InstantiationException {
        Class<?> clazz = entity.getClass();
        Transaction newEntity = entity.getClass().newInstance();

        while (clazz != null) {
            copyFields(entity, newEntity, clazz);
            clazz = clazz.getSuperclass();
        }

        return newEntity;
    }

    private static Transaction copyFields(Transaction entity, Transaction newEntity, Class<?> clazz) throws IllegalAccessException {
        List<Field> fields = new ArrayList<>();
        for (Field field : clazz.getDeclaredFields()) {
            fields.add(field);
        }
        for (Field field : fields) {
            field.setAccessible(true);
            field.set(newEntity, field.get(entity));
        }
        return newEntity;
    }
}
