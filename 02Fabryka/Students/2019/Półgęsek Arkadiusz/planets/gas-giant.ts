import { Planet } from "./planet.base";
import { PlanetType } from "./planet.enum";

export class GasGiant extends Planet {
    constructor() {
        super();
        this.name = 'Planet13123';
        this.type = PlanetType.GasGiant;
        this.atmosphere = {humanFriendly: false};
        this.gravity = {level: 'strong'};
        this.surface = {solid: false}
    }
}