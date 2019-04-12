const SingletonSerialized = require('./singleton-serialized');

export function serialize(instance: any): string {
    return JSON.stringify(instance);
}

export function deserialize(serializedInstance: string) {
    const serializedInstanceState = JSON.parse(serializedInstance);
    const instance = eval(serializedInstanceState.instanceOf).getInstance();

    Object.keys(instance).forEach((key) => {
        instance[key] = serializedInstanceState[key];
    });
}

module.exports = {serialize, deserialize};