import { PlanetType, Planet } from "../planets";
const { RockyPlanet, OceanPlanet, GasGiant, VolcanoPlanet } = require('../planets');

export class NoReflectionFactory {

    private static instance: NoReflectionFactory;
    private registeredPlanets: Map<PlanetType, Supplier<Planet>> = new Map();
	
	public static getInstance(): NoReflectionFactory {
        if (this.instance == null) {
            this.instance = new NoReflectionFactory();
        }
        return this.instance;
    }
    
    public registerPlanet(type: PlanetType, supplier: Supplier<Planet>) {
        this.registeredPlanets.set(type, supplier);
    }
    public createPlanet(type: PlanetType): Planet {
        const planet: Supplier<Planet> = this.registeredPlanets.get(type);
        return planet != null ? planet.get() : null; 
    }
}

export class RockyPlanetSupplier implements Supplier<Planet> {
    get(): Planet {
        return new RockyPlanet();
    }
}

interface Supplier<T> {
    get(): T;
}