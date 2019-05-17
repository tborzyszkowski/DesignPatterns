import { GasGiant, OceanPlanet, PlanetType, RockyPlanet, Planet, VolcanoPlanet } from '../planets';

export class SimpleFactory {

	private constructor(){}

	private static instance: SimpleFactory;
	
	public static getInstance(): SimpleFactory{
        if (this.instance == null) {
            this.instance = new SimpleFactory();
        }
        return this.instance;
	}

	public createPlanet(type: PlanetType): Planet {
	    if (type === PlanetType.GasGiant) {
	        return new GasGiant();
	    } else if (type === PlanetType.OceanPlanet) {
	        return new OceanPlanet();
	    } else if (type === PlanetType.RockyPlanet) {
			return new RockyPlanet();
		} else if (type === PlanetType.VolcanoPlanet) {
			return new VolcanoPlanet();
		} else {
			return null;
		}
	}

}