import { Planet } from "./planet";
import { PlanetPartsFactory } from "../planet-parts-factory";
import { PlanetType } from "../../planets/planet.enum";

export class GasGiant extends Planet {
    constructor(factory: PlanetPartsFactory, name: string){
        super(PlanetType.GasGiant, factory, name);
    }
    prepareParts(): void {
        this.surface = this.planetPartsFactory.createSurface();
        this.atmosphere = this.planetPartsFactory.createAtmoshpere();
        this.gravity = this.planetPartsFactory.createGravity();
    }
}