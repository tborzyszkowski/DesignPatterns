import { Factory } from "./factory";
import { GasGiant, PlanetType, Planet, OceanPlanet } from "../planets";

export class UnsolidPlanetFactory extends Factory {

    private constructor(){
        super();
    }

	private static instance: UnsolidPlanetFactory;
	
	public static getInstance(): UnsolidPlanetFactory{
        if (this.instance == null) {
            this.instance = new UnsolidPlanetFactory();
        }
        return this.instance;
    }
    
    protected create(type: PlanetType): Planet {
        if (type === PlanetType.GasGiant) {
	        return new GasGiant();
	    } else if (type === PlanetType.OceanPlanet) {
	        return new OceanPlanet();
	    } else {
			return undefined;
		}
    }
}