import { Planet } from "./planet.base";
import { PlanetType } from "./planet.enum";

export class VolcanoPlanet extends Planet {
    constructor() {
        super();
        this.name = 'Planet88888';
        this.type = PlanetType.VolcanoPlanet;
        this.atmosphere = {humanFriendly: false};
        this.gravity = {level: 'weak'};
        this.surface = {solid: true}
    }
}