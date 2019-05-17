import { Planet } from "./planet.base";
import { PlanetType } from "./planet.enum";

export class OceanPlanet extends Planet {
    constructor() {
        super();
        this.name = 'Planet13123';
        this.type = PlanetType.OceanPlanet;
        this.atmosphere = {humanFriendly: false};
        this.gravity = {level: 'strong'};
        this.surface = {solid: false}
    }
}