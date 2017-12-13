package com.marchwinski.prototype.constructorCopy;

import java.io.Serializable;

public class KindOfCheese  implements Serializable {
    private String kind;

    public KindOfCheese(KindOfCheese otherKindOfCheese) {
        this.kind = otherKindOfCheese.kind;
    }

    public KindOfCheese(String kind) {
        this.kind = kind;
    }

    public String getKind() {
        return kind;
    }


}
