const shootingRangeBuilder = require('./shootingRangeBuilder');
const commanderObserver = require('./commanderObserver');
const soldierAdapter = require('./soldierAdapter');
const warehouseChain = require('./warehouseChain');

let militaryBaseInstance;

class MilitaryBase {
  constructor() {
    if (!militaryBaseInstance) {
      militaryBaseInstance = this;
    }

    this.soldiers = [];
  }
  
  openMilitaryBase() {
    this.shootingRange = new shootingRangeBuilder.ShootingRange();
    this.commander = new commanderObserver.CommanderSubject();
    this.warehouse = new warehouseChain.Warehouse();
  }

  trainTenSoldiers() {
    if (militaryBaseInstance && this.commander) {
      let i = 0;

      while (i < 10) {
        const newHuman = new soldierAdapter.Human();

        const newSoldier = this.shootingRange
          .trainSoldier(newHuman.age, newHuman.sex, newHuman.idNumber)
          .equipSoldierWithWeapon()
          .equipSoldierWithGrenadeLauncher()
          .endTraining();

        this.soldiers.push(newSoldier);
        this.commander.attach(newSoldier);
        i++;
      }
    } else if (!militaryBase) {
      console.log('There is no military base!')
    } else if (!this.commander) {
      console.log('We must hire a commander!');
    }
  }

  processOrderForAmmunition() {
    this.warehouse.createOrder('ammo', 10600);
  }
}

const base = new MilitaryBase();

base.openMilitaryBase();

base.trainTenSoldiers();

console.log(base);
console.log(base.soldiers.map(soldier => soldier.shaved));

base.commander.notify('shave');
setTimeout(() => {

  console.log(base.soldiers.map(soldier => soldier.shaved));

  base.processOrderForAmmunition();
}, 500);

