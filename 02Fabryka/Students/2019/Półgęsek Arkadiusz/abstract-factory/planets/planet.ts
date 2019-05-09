import { Surface, Atmosphere, Gravity, PlanetPartsFactory } from "../planet-parts-factory";
import { PlanetType } from "../../planets/planet.enum";

export abstract class Planet {
    name: string;
    type: PlanetType;
    gravity: Gravity;
    surface: Surface;
    atmosphere: Atmosphere;
    planetPartsFactory: PlanetPartsFactory;
    
    constructor(
        type: PlanetType,
        factory: PlanetPartsFactory,
        name: string
    ) {
        this.planetPartsFactory = factory;
        this.type = type;
        this.name = name;
    }

    abstract prepareParts(): void;
}