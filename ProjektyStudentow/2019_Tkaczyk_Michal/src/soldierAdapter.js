const _ = require('lodash');

class Human {
  constructor(age, sex, idNumber) {
    if (age && sex && idNumber) {
      this.age = age;
      this.sex = sex;
      this.idNumber = idNumber;
    } else {
      this.age = _.sample([18, 19, 20, 21, 22, 23, 24, 25])
      this.sex = _.sample(['Man', 'Woman']);
      this.idNumber = this.age.toString() + 
      _.sample(['01', '02', '03', '04', '05', '06', '07', '08', '09', '11', '12']) +
      _.sample(['01', '02', '03', '04', '05', '06', '07', '08', '09', '11',
       '12', '13', '14', '15', '16', '17', '18', '19', '20',
      '21', '22', '23', '24', '25', '26', '27', '28']) +
      Math.floor(Math.random() * (99999 - 10000) + 10000).toString();
    }
  }
}

class Soldier extends Human {
  constructor(age, sex, idNumber) {
    super(age, sex, idNumber);

    if(sex === 'Man') {
      this.shaved = _.sample([true, false]);
    } else {
      this.shaved = true;
    }

    this.trainInWeapon = (weapon) => {
      this.usedWeapon = weapon;
    }

    this.clickTrigger = () => {
      if (this.usedWeapon) {
        this.usedWeapon.shoot();
      } else {
        console.log('I can\'t shoot without training!');
      }
    }

    this.shaveYourself = () => {
      if (!this.shaved && this.sex === 'Man') {
        this.shaved = true;
      }
    }

    this.becomeSniper = () => {
      return new Sniper(this);
    }
  }
}

class Sniper extends Soldier {
  constructor(soldier) {
    super(soldier.age, soldier.sex, soldier.idNumber);

    Object.keys(soldier).forEach(key => {
      this[key] = soldier[key];
    })

    this.sniperTraining = true;
    this.becomeSniper = () => {
      console.log('I\'m already a sniper');
    }
  }
}

module.exports = {
  Human,
  Soldier,
  Sniper
}