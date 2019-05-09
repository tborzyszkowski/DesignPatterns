import { Cloneable } from "./cloneable";
import { Manufacturer } from "./manufacturer";

export class Hdd implements Cloneable {

    private capacity: number;
    private manufacturer: Manufacturer;

    constructor(manufacturer: Manufacturer) {
        this.manufacturer = manufacturer;
    }

    getManufacturer(): Manufacturer {
        return this.manufacturer;
    }

    setCapacity(capacity: number): Hdd {
        this.capacity = capacity;
        return this;
    }

    clone(): Hdd {
        const cloned = Object.create(Hdd.prototype || null);
        Object.keys(this).map((key: string) => {
            cloned[key] = this[key];
        });
        cloned.manufacturer = this.manufacturer.clone();
        return cloned;
    }

    print(): string {
        return "Frame{" +
                "manufacturer=" + this.manufacturer +
                ", capacity=" + this.capacity +
                '}';
    }
}