/// <reference types="jest" />

import { HabitablePlanetFactory } from './habitable-planet-factory';
import { InhabitablePlanetFactory } from './inhabitable-planet-factory';
import { Planet } from './planets/planet';
import { RockyPlanet } from './planets/rocky-planet';

test('should create planets with the same parts', () => {
  const abstractFactory = HabitablePlanetFactory.getInstance();
  const planet1: Planet = new RockyPlanet(abstractFactory, 'Planet1');
  const planet2: Planet = new RockyPlanet(abstractFactory, 'Planet2');

  planet1.prepareParts();
  planet2.prepareParts();

  expect(planet1.surface).toEqual(planet2.surface);
  expect(planet1.gravity).toEqual(planet2.gravity);
  expect(planet1.atmosphere).toEqual(planet2.atmosphere);
});

test('should create planets with different parts', () => {
    const abstractFactoryHabitable = HabitablePlanetFactory.getInstance();
    const abstractFactoryInhabitable = InhabitablePlanetFactory.getInstance();
    const planet1: Planet = new RockyPlanet(abstractFactoryHabitable, 'Planet1');
    const planet2: Planet = new RockyPlanet(abstractFactoryInhabitable, 'Planet2');

    planet1.prepareParts();
    planet2.prepareParts();
  
    expect(planet1.surface).not.toEqual(planet2.surface);
    expect(planet1.gravity).not.toEqual(planet2.gravity);
    expect(planet1.atmosphere).not.toEqual(planet2.atmosphere);
});

test('time test', () => {
  const abstractFactory = HabitablePlanetFactory.getInstance();
  let list: Planet[] = [];

  var t1 = performance.now();
  for (let i=0; i < 1000000; i++) {
    list.push(new RockyPlanet(abstractFactory, 'Planet1'));
  }
  var t2 = performance.now();
  console.log('Abstract factory time: ', t2 - t1);
})

