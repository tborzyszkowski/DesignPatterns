import { Computer } from "./computer";
import { Cpu } from "./cpu";
import { Hdd } from "./hdd";
import { Manufacturer } from "./manufacturer";

export class ComputerManager {
    private prototypes: Map<string, Computer> = new Map<string, Computer>(
        [
            ['First', new Computer('Gaming').Cpu(new Cpu(4)).Hdd(new Hdd(new Manufacturer('OOK')).setCapacity(1024))],
            ['Second', new Computer('Work').Cpu(new Cpu(2)).Hdd(new Hdd(new Manufacturer('SKD')).setCapacity(512))],
            ['Third', new Computer('Graphics').Cpu(new Cpu(8)).Hdd(new Hdd(new Manufacturer('ASDF')).setCapacity(4096))]
        ]
    );

    getComputerPrototype(name: string): Computer {
        return this.prototypes.get(name).clone();
    }

    getComputerShallowCopy(name: string): Computer {
        return this.prototypes.get(name).shallowCopy();
    }

}