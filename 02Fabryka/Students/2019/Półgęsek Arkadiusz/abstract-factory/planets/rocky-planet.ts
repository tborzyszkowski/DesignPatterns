import { Planet } from "./planet";
import { PlanetType } from "../../planets/planet.enum";
import { PlanetPartsFactory } from "../planet-parts-factory";

export class RockyPlanet extends Planet {
    constructor(factory: PlanetPartsFactory, name: string){
        super(PlanetType.RockyPlanet, factory, name);
    }
    prepareParts(): void {
        this.surface = this.planetPartsFactory.createSurface();
        this.atmosphere = this.planetPartsFactory.createAtmoshpere();
        this.gravity = this.planetPartsFactory.createGravity();
    }
}