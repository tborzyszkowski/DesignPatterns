/// <reference types="jest" />

import { ReflectionFactory } from "./reflection-factory";
import { PlanetType, RockyPlanet, Planet } from "../planets";

test('create a specific planet', () => {
  const planetFactory = ReflectionFactory.getInstance();
  planetFactory.registerPlanet(PlanetType.RockyPlanet, RockyPlanet);
  const planet = planetFactory.createPlanet(PlanetType.RockyPlanet);

  expect(planet).toBeDefined();
  expect(planet).toBeInstanceOf(RockyPlanet);
});

test('time test', () => {
  const reflectionFactory = ReflectionFactory.getInstance();
  let list: Planet[] = [];

  reflectionFactory.registerPlanet(PlanetType.RockyPlanet, RockyPlanet);

  var t1 = performance.now();
  for (let i=0; i < 1000000; i++) {
    list.push(reflectionFactory.createPlanet(PlanetType.RockyPlanet));
  }
  var t2 = performance.now();
  console.log('Class registration with reflection factory time: ', t2 - t1);
})