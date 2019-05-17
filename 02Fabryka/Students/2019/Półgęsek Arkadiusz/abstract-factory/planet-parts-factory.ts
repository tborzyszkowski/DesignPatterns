
export interface PlanetPartsFactory {
    createGravity(): Gravity;
    createSurface(): Surface;
    createAtmoshpere(): Atmosphere;
}

export interface Gravity {
    level: 'weak' | 'medium' | 'strong';
}

export interface Surface {
    solid: boolean;
}

export interface Atmosphere {
    humanFriendly: boolean;
}
