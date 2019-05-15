/// <reference types="jest" />

import { ExtendableSingleton, ExtendableSingletonSubclass } from './extendable-singleton';

afterEach(() => {
    ExtendableSingleton.clearInstance();
});

test('create ExtendableSingleton()', () => {
  process.env["SINGLETON"] = "ExtendableSingleton";

  const singleton1 = ExtendableSingleton.getInstance();
  const singleton2 = ExtendableSingleton.getInstance();

  expect(singleton1).toBeDefined();
  expect(singleton1).toBe(singleton2);

  expect(singleton1).toBeInstanceOf(ExtendableSingleton);
  expect(singleton2).not.toBeInstanceOf(ExtendableSingletonSubclass);
});

test('create ExtendableSingletonSubclass()', () => {
  process.env["SINGLETON"] = "ExtendableSingletonSubclass";

  const singleton1 = ExtendableSingleton.getInstance();
  const singleton2 = ExtendableSingletonSubclass.getInstance();

  expect(singleton2).toBeInstanceOf(ExtendableSingletonSubclass);
  expect(singleton1).toBe(singleton2);
});