/// <reference types="jest" />

import { SolidPlanetFactory } from './solid-planet-factory';
import { PlanetType, Planet, RockyPlanet } from '../planets';

test('create a specific object', () => {
  const planetFactory = SolidPlanetFactory.getInstance();
  const planet: Planet = planetFactory.build(PlanetType.RockyPlanet);

  expect(planet).toBeDefined();
  expect(planet).toBeInstanceOf(RockyPlanet);
});

test('create an non-existing object', () => {
    const planetFactory = SolidPlanetFactory.getInstance();
    const planet: Planet = planetFactory.build(PlanetType["SomeNonExistingPlanetType"]);
  
    expect(planet).toBeNull();
});

test('time test', () => {
  const simpleFactory = SolidPlanetFactory.getInstance();
  let list: Planet[] = [];

  var t1 = performance.now();
  for (let i=0; i < 1000000; i++) {
    list.push(simpleFactory.build(PlanetType.RockyPlanet));
  }
  var t2 = performance.now();
  console.log('Factory method time: ', t2 - t1);
})