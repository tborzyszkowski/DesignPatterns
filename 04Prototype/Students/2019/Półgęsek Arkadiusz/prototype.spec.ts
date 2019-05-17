/// <reference types="jest" />

import { ComputerManager } from "./computer-manager";

const computerManager = new ComputerManager();

test('should create deep copy', () => {
    const computer1 = computerManager.getComputerPrototype('First');
    const computer2 = computerManager.getComputerPrototype('First');

    console.log('DEEP COPY');
    console.log(JSON.stringify(computer1, null, 4));
    console.log(JSON.stringify(computer2, null, 4));

    expect(computer1).not.toBe(computer2);
    expect(computer1.getCpu()).not.toBe(computer2.getCpu());
    expect(computer1.getHdd()).not.toBe(computer2.getHdd());
    expect(computer1.getHdd().getManufacturer()).not.toBe(computer2.getHdd().getManufacturer());

    computer1.setType('Some other type');
    computer1.getCpu().setCores(1);
    computer1.getHdd().setCapacity(1024);
    computer1.getHdd().getManufacturer().setName('Company xyz');

    console.log(JSON.stringify(computer1, null, 4));
    console.log(JSON.stringify(computer2, null, 4));
});

test('should create shallow copy', () => {
    const computer1 = computerManager.getComputerShallowCopy('Second');
    const computer2 = computerManager.getComputerShallowCopy('Second');

    console.log('SHALLOW COPY');
    console.log(JSON.stringify(computer1, null, 4));
    console.log(JSON.stringify(computer2, null, 4));

    expect(computer1).not.toBe(computer2);
    expect(computer1.getCpu()).toBe(computer2.getCpu());
    expect(computer1.getHdd()).toBe(computer2.getHdd());
    expect(computer1.getHdd().getManufacturer()).toBe(computer2.getHdd().getManufacturer());

    computer1.setType('Some other type');
    computer1.getCpu().setCores(1);
    computer1.getHdd().setCapacity(1024);
    computer1.getHdd().getManufacturer().setName('Company xyz');

    console.log(JSON.stringify(computer1, null, 4));
    console.log(JSON.stringify(computer2, null, 4));
});

