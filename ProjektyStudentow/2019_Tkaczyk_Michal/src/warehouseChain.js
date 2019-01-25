class Warehouse {
  constructor() {
    this.warehouseMan = new WarehouseMan();
    this.colonel = new Colonel();
    this.general = new General();

    this.warehouseMan.setSuperior(this.colonel);
    this.colonel.setSuperior(this.general);
  }

  createOrder(type, value) {
    return this.warehouseMan.processRequest(new Order(type, value));
  }
}

class Official {
  constructor() {

  }

  setSuperior(official) {
    this.superior = official;
  }

  processRequest() {

  }
}

class WarehouseMan extends Official {
  constructor() {
    super();
    this.name = 'warehouse man';
  }

  processRequest(order) {
    if (order.value < 1000) {
      console.log('Order signed by ' + this.name);
    } else {
      this.superior.processRequest(order);
    }
  }
}

class Colonel extends Official {
  constructor() {
    super();
    this.name = 'colonel';
  }

  processRequest(order) {
    if (order.value < 10000) {
      console.log('Order signed by ' + this.name);
    } else {
      this.superior.processRequest(order);
    }
  }
}

class General extends Official {
  constructor() {
    super();
    this.name = 'general';
  }

  processRequest(order) {
    console.log('Order signed by ' + this.name);
  }
}

class Order {
  constructor(type, value) {
    this.type = type;
    this.value = value;
  }
}

module.exports = {
  Warehouse,
  Official,
  WarehouseMan,
  Colonel,
  General,
  Order
};