from Factory.AbstracFactory.element.motor.Motor import Motor


class Engine(Motor):

    def get_motor(self)->str:
        return 'engine'
