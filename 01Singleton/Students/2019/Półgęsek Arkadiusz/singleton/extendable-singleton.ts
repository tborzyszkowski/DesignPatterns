export class ExtendableSingleton {

    protected constructor() {}
    private static instance: ExtendableSingleton;

    public static getInstance(): ExtendableSingleton {
        if (!this.instance) {
            const singletonName: string = process.env["SINGLETON"];
            this.instance = eval(`new ${singletonName}()`);
        }
        return this.instance;
    }

    // do testów
    public static clearInstance(): void {
        this.instance = null;
    }
}

export class ExtendableSingletonSubclass extends ExtendableSingleton {

}