const soldierAdapter = require('./soldierAdapter');
const rifleDecorator = require('./rifleDecorator');

class Field {
  constructor() {
    this.soldier = '';
    this.train = () => {

    }
  }
}

class ShootingRange extends Field {
  constructor() {
    super();

    this.transformIntoSniper = () => {
      this.soldier = this.soldier.becomeSniper();
      this.soldier.weapon = this.soldier.weapon ? 
      new rifleDecorator.RifleWithTelescope(this.soldier.weapon) :
      new rifleDecorator.RifleWithTelescope(new rifleDecorator.SimpleRifle());

      return this;
    }
  }
  
  trainSoldier(age, sex, idNumber) {
    this.soldier = new soldierAdapter.Soldier(age, sex, idNumber);    
    return this;
  }
  
  equipSoldierWithWeapon() {
    this.soldier.weapon = new rifleDecorator.SimpleRifle();
    return this;
  }

  equipSoldierWithGrenadeLauncher() {
    if (this.soldier.weapon) {
      this.soldier.weapon = new rifleDecorator.RifleWithGrenadeLauncher(this.weapon);
    } else {
      console.log('Soldier does not have a weapon to add grenade launcher to it!');
    }

    return this;
  }
  
  endTraining() {
    const returnSoldier = {...this.soldier};
    this.soldier = '';
    return returnSoldier;
  }
}

// const newShootingRange = new ShootingRange();
// console.log(newShootingRange.trainSoldier().transformIntoSniper().endTraining());

module.exports = {
  Field,
  ShootingRange
};