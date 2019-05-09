import { Planet } from "./planet.base";
import { PlanetType } from "./planet.enum";

export class RockyPlanet extends Planet {
    constructor() {
        super();
        this.name = 'Planet345';
        this.type = PlanetType.RockyPlanet;
        this.atmosphere = {humanFriendly: true};
        this.gravity = {level: 'medium'};
        this.surface = {solid: true}
    }
}