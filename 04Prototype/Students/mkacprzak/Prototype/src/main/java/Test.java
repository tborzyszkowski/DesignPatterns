

public class Test {
    public static void main(String[] args) {



        Engine power = new Engine().power(300);
        Gun gun = new Gun().specification(new Specification().diameter(30).penetration(120)).type("DESTROYER");
        Tank t1 = new Tank().engine(power).gun(gun).turret(500);
        Tank t2=null;
        Tank t3=null;

        System.out.println(t1);

          t2  = t1.shallowCopy();

        System.out.println(t2);
          t3 = t1.deepCopy();

        System.out.println("DEEP");
        System.out.println(t3);


        System.out.println("Shallow copy without issues");
        t1.turret(450);
        System.out.println(t2);
        System.out.println(t1);
        System.out.println(t3);

        System.out.println("Shallow copy with issues");
        t1.getEngine().setPower(999);
        t1.getGun().setType("MOSQUITO");
        System.out.println(t1);
        System.out.println(t2);
        System.out.println(t3);


        System.out.println("-----------------Tanks from manager----------------");

        TankManager tankManager = new TankManager();

        Tank t34_1 = tankManager.getTankWithCommonComponents("T34");
        Tank t34_2 = tankManager.getTankWithCommonComponents("T34");

        Tank leopard_1 = tankManager.getTankWithNewComponents("LEOPARD");
        Tank leopard_2 = tankManager.getTankWithNewComponents("LEOPARD");

        System.out.println(t34_1);
        System.out.println(t34_2);

        System.out.println(leopard_1);
        System.out.println(leopard_2);

        System.out.println("Changes in nested components");

        t34_1.getGun().getSpecification().setDiameter(50000);

        leopard_1.getGun().getSpecification().setDiameter(99999);

        System.out.println(t34_1);
        System.out.println(t34_2);

        System.out.println(leopard_1);
        System.out.println(leopard_2);




}

}
