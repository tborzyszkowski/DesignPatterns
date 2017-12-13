package ClassicBuilder;

public class Test {


    public static void main(String[] args)

    {

        ComputerBuilder gamingPcBuilder = new GamingPcBuilder();
        ComputerManufacturer manufacturer = new ComputerManufacturer(gamingPcBuilder);

        Computer computer = manufacturer.getComputer();
        System.out.println(computer);

    }
    }
