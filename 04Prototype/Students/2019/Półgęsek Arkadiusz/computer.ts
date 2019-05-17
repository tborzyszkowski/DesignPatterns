import { Cloneable } from "./cloneable";
import { Cpu } from "./cpu";
import { Hdd } from "./hdd";

export class Computer implements Cloneable {

    private type: string;
    private cpu: Cpu;
    private hdd: Hdd;

    constructor(type: string) {
        this.type = type;
    }

    getCpu(): Cpu {
        return this.cpu;
    }

    setCpu(cpu: Cpu) {
        this.cpu = cpu;
    }

    getHdd(): Hdd {
        return this.hdd;
    }

    setHdd(hdd: Hdd) {
        this.hdd = hdd;
    }

    setType(type: string) {
        this.type = type;
    }

    Cpu(cpu: Cpu): Computer {
        this.cpu = cpu;
        return this;
    }

    Hdd(hdd: Hdd): Computer {
        this.hdd = hdd;
        return this;
    }

    clone(): Computer {
        try {
            const cloned = this.shallowCopy();
            cloned.cpu = this.cpu.clone();
            cloned.hdd = this.hdd.clone();
            return cloned;
        } catch {
            return null;
        }
    }

    shallowCopy(): Computer {
        const cloned = Object.create(Computer.prototype || null);
        Object.keys(this).map((key: string) => {
            cloned[key] = this[key];
        });
        return cloned;
    }

    public print(): string {
        return "Computer{" +
                "type='" + this.type + '\'' +
                ", cpu=" + this.cpu +
                ", hdd=" + this.hdd +
                '}';
    }
}