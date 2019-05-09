/// <reference types="jest" />

import { SimpleFactory } from './simple-factory';
import { PlanetType, RockyPlanet, Planet } from '../planets';

test('create a specific planet', () => {
  const simpleFactory = SimpleFactory.getInstance();
  const planet: Planet = simpleFactory.createPlanet(PlanetType.RockyPlanet);

  expect(planet).toBeDefined();
  expect(planet).toBeInstanceOf(RockyPlanet);
});

test('create a planet that does not exist', () => {
  const simpleFactory = SimpleFactory.getInstance();
  const planet: Planet = simpleFactory.createPlanet(PlanetType['SomePlanetTypeThatDoesNotExist']);
  expect(planet).toBeNull();
});

test('time test', () => {
  const simpleFactory = SimpleFactory.getInstance();
  let list: Planet[] = [];

  var t1 = performance.now();
  for (let i=0; i < 1000000; i++) {
    list.push(simpleFactory.createPlanet(PlanetType.RockyPlanet));
  }
  var t2 = performance.now();
  console.log('Simple factory time: ', t2 - t1);
})

