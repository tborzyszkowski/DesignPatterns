class AbstractSubject {
  constructor() {};

  attach() {};
  detach() {};
  notify() {};
}


class CommanderSubject extends AbstractSubject {
  constructor() {
    super();
    this.observers = [];
  }

  attach(soldier) {
    this.observers.push(new SoldierObserver(soldier));
  }

  detach(soldier) {
    const index = this.observers.findIndex(el => el.idNumber === soldier.idNumber);

    this.observers.splice(index, 1);
  }

  notify(type) {
    this.observers.forEach(observer => {
      observer.update(type);
    })
  }
}

class AbstractObserver {
  constructor() {};
  
  update() {};
}

class SoldierObserver extends AbstractObserver {
  constructor(soldier) {
    super();
    this.soldier = soldier;
  }

  update(type) {
    switch (type) {
      case 'shave':
        this.soldier.shaveYourself();
      break;
      default:
      break;
    }
  }
}

module.exports = {
  AbstractSubject,
  CommanderSubject,
  AbstractObserver,
  SoldierObserver
}