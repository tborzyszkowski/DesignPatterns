import { Cloneable } from "./cloneable";

export class Cpu implements Cloneable {

    private cores: number;

    constructor(cores: number) {
        this.cores = cores;
    }

    setCores(cores: number) {
        this.cores = cores;
    }

    clone(): Cpu {
        const cloned = Object.create(Cpu.prototype || null);
        Object.keys(this).map((key: string) => {
            cloned[key] = this[key];
        });
        return cloned;
    }

    print(): string {
        return "Cpu{" +
                "cores=" + this.cores +
                '}';
    }
}