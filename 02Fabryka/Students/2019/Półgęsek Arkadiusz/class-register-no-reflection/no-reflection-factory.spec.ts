/// <reference types="jest" />

import { NoReflectionFactory, RockyPlanetSupplier } from "./no-reflection-factory";
import { PlanetType, RockyPlanet, Planet } from "../planets";

test('create a specific planet', () => {
  const planetFactory = NoReflectionFactory.getInstance();
  planetFactory.registerPlanet(PlanetType.RockyPlanet, new RockyPlanetSupplier());
  const planet = planetFactory.createPlanet(PlanetType.RockyPlanet);

  expect(planet).toBeDefined();
  expect(planet).toBeInstanceOf(RockyPlanet);
});

test('time test', () => {
  const reflectionFactory = NoReflectionFactory.getInstance();
  let list: Planet[] = [];

  reflectionFactory.registerPlanet(PlanetType.RockyPlanet, new RockyPlanetSupplier());

  var t1 = performance.now();
  for (let i=0; i < 1000000; i++) {
    list.push(reflectionFactory.createPlanet(PlanetType.RockyPlanet));
  }
  var t2 = performance.now();
  console.log('Class registration without reflection factory time: ', t2 - t1);
})