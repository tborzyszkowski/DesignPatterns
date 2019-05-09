import { Cloneable } from "./cloneable";

export class Manufacturer implements Cloneable {

    private name: string;

    constructor(name: string) {
        this.name = name;
    }

    setName(name: string) {
        this.name = name;
    }

    clone(): Manufacturer {
        var cloned = Object.create(Manufacturer.prototype || null);
        Object.keys(this).map((key: string) => {
            cloned[key] = this[key];
        });
        return cloned;
    }

    print(): string {
        return "Manufacturer{" +
                "name=" + this.name +
                '}';
    }
}