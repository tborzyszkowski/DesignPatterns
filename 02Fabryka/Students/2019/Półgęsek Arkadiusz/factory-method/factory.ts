import { Planet, PlanetType } from "../planets";

export abstract class Factory {
    protected abstract create(type: PlanetType): Planet;
    public build(type: PlanetType): Planet {
        let object = this.create(type);
        if (!object) {
            return null;
        }
        return object;
    }
}