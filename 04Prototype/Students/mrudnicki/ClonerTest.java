import java.util.Arrays;
import java.util.List;

import sample.Child;
import sample.Parent;
import static engine.Cloner.deepClone;


public class ClonerTest {

    static public void main(String[] args) {

        Parent parent = new Parent();
        parent.setChild(new Child());
        /**
         * First cloning using arraylist's build-in clone. It's shallow clone example.
         */
        Parent parentClone;
        try {
            parentClone = (Parent) parent.clone();
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException();
        }

        System.out.println("Shallow clone - reference checking. Is child in cloned object the same :  " + parent
                .getChild()
                .equals(parentClone
                        .getChild()));

        /**
         * Second cloning using serialization & deserialization. It's deep close example.
         */
        parentClone = (Parent) deepClone(parent);

        System.out.println("Deep clone - reference checking. Is child in cloned object the same : " + parent.getChild()
                .equals
                        (parentClone.getChild()));


        /**
         * Second test of deep cloning. This time with collection.
         */
        List<String> list = Arrays.asList("a", "b", "c");
        List<String> listClone = (List<String>) deepClone(list);

        System.out.println("Deep clone - collection reference checking. Is element in cloned object the same : " + (
                list
                        .get(0) == (listClone.get(0))));

    }


}