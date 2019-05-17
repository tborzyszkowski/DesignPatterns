import { PlanetPartsFactory, Atmosphere, Gravity, Surface } from "./planet-parts-factory";

export class InhabitablePlanetFactory implements PlanetPartsFactory {
    private constructor(){}

	private static instance: InhabitablePlanetFactory;
	
	public static getInstance(): InhabitablePlanetFactory {
        if (this.instance == null) {
            this.instance = new InhabitablePlanetFactory();
        }
        return this.instance;
    }

    createAtmoshpere(): Atmosphere {
        return {
            humanFriendly: false
        };
    }

    createGravity(): Gravity {
        return {
            level: 'weak'
        };
    }

    createSurface(): Surface {
        return {
            solid: false
        };
    }

}