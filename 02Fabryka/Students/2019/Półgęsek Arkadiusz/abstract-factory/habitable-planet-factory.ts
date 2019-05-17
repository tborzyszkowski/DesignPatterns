import { PlanetPartsFactory, Atmosphere, Surface, Gravity } from "./planet-parts-factory";

export class HabitablePlanetFactory implements PlanetPartsFactory {
    private constructor(){}

	private static instance: HabitablePlanetFactory;
	
	public static getInstance(): HabitablePlanetFactory {
        if (this.instance == null) {
            this.instance = new HabitablePlanetFactory();
        }
        return this.instance;
    }

    createAtmoshpere(): Atmosphere {
        return {
            humanFriendly: true
        };
    }

    createGravity(): Gravity {
        return {
            level: 'medium'
        };
    }

    createSurface(): Surface {
        return {
            solid: true
        };
    }

}