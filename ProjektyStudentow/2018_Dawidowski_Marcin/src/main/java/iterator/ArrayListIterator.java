package iterator;

import java.util.ArrayList;

public class ArrayListIterator<object> implements Iterator {

    int posistion = 0;
    ArrayList<object> list;

    public ArrayListIterator(ArrayList<object> list){
        this.list = list;
    }

    @Override
    public boolean hasNext() {
        if (posistion >= list.size() || list.get(posistion) == null){
            return false;
        }
        return true;
    }

    @Override
    public Object next() {
        Object element = list.get(posistion);
        posistion += 1;
        return element;
    }
}
