export class SingletonSerialized {

    public someProp: number;

    private instanceOf: string;
    private static singleton: SingletonSerialized;

    private constructor() {
        this.instanceOf = this.constructor.name;
    }
  
    public static getInstance(): SingletonSerialized {
        if (!SingletonSerialized.singleton) {
            SingletonSerialized.singleton = new SingletonSerialized();
        }
  
        return SingletonSerialized.singleton;
    }
}

module.exports = SingletonSerialized;

