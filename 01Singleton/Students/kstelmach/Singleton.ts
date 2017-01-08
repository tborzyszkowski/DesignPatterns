class Singleton {
    private static instance: Singleton;

    constructor() {
        if (Singleton.instance) {
            throw new Error("Uzyj Singleton.getInstance()");
            //console.log("err");
        }
        
        this.member = 0;
    }

    static getInstance(): Singleton {
        Singleton.instance = Singleton.instance || new Singleton();
        return Singleton.instance;
    }

    member: number;
}

var obj = new Singleton();
console.log(obj);
    obj = Singleton.getInstance();
console.log(obj);
var   obj2 = Singleton.getInstance();
console.log(obj2);
      obj2 = new Singleton(); //will generate Error
console.log(obj2);