import { PlanetType } from "./planet.enum";
import { Gravity, Surface, Atmosphere } from "../abstract-factory/planet-parts-factory";

export abstract class Planet {
    name: string;
    type: PlanetType;
    gravity: Gravity;
    surface: Surface;
    atmosphere: Atmosphere;
}