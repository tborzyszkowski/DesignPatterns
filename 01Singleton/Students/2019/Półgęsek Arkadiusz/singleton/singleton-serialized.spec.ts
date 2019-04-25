/// <reference types="jest" />
const utils = require('./utils');
const SingletonSerialized = require('./singleton-serialized');

test('check one instnace', () => {
  const singleton = SingletonSerialized.getInstance();
  singleton.someProp = 2;
  const serialized: string = utils.serialize(singleton);
  singleton.someProp = 8;
  utils.deserialize(serialized);
  expect(singleton.someProp).toBe(2);
});