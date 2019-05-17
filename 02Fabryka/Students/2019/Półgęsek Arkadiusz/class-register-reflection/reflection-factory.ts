import { PlanetType, Planet } from "../planets";
const { RockyPlanet, OceanPlanet, GasGiant, VolcanoPlanet } = require('../planets');

export class ReflectionFactory {

    private static instance: ReflectionFactory;
    private registeredPlanets: Map<PlanetType, Function> = new Map();
	
	public static getInstance(): ReflectionFactory {
        if (this.instance == null) {
            this.instance = new ReflectionFactory();
        }
        return this.instance;
    }
    
    public registerPlanet(type: PlanetType, planetClass: Function) {
        this.registeredPlanets.set(type, planetClass);
    }
    public createPlanet(type: PlanetType): Planet {
        const planetClass = this.registeredPlanets.get(type);
        return eval(`new ${planetClass.name}()`);
    }
}