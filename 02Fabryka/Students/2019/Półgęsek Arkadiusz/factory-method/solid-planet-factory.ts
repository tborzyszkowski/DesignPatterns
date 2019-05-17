import { Factory } from "./factory";
import { RockyPlanet, PlanetType, Planet, VolcanoPlanet } from "../planets";

export class SolidPlanetFactory extends Factory {

    private constructor(){
        super();
    }

	private static instance: SolidPlanetFactory;
	
	public static getInstance(): SolidPlanetFactory{
        if (this.instance == null) {
            this.instance = new SolidPlanetFactory();
        }
        return this.instance;
    }
    
    protected create(type: PlanetType): Planet {
        if (type === PlanetType.VolcanoPlanet) {
	        return new VolcanoPlanet();
	    } else if (type === PlanetType.RockyPlanet) {
            return new RockyPlanet();
         } else {
			return undefined;
		}
    }
}