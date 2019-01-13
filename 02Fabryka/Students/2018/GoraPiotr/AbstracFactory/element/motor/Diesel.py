from Factory.AbstracFactory.element.motor.Motor import Motor


class Diesel(Motor):

    def get_motor(self) -> str:
        return 'diesel'
