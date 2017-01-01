package facade.selling.facade;

import facade.selling.service1.Item1;
import facade.selling.service2.Item2;

import java.util.UUID;

/**
 * Created by jakub on 1/1/17.
 */
public class FacadeItem {
    private String name = UUID.randomUUID().toString();
    private Class rootClass;

    public FacadeItem(String name, Class rootClass) {
        this.name = name;
        this.rootClass = rootClass;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Class getRootClass() {
        return rootClass;
    }

    public static FacadeItem facadeItemOf(Object item) {
        if (item instanceof Item1) {
            return new FacadeItem(((Item1) item).getName(), Item1.class);
        } else if (item instanceof Item2) {
            return new FacadeItem(((Item2) item).getName(), Item2.class);
        } else {
            throw new RuntimeException("not know item type");
        }

    }

}
