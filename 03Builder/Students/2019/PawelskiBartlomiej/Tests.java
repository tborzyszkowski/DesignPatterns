import BuilderVsFactory.Factory.PCFactory;
import FluentBuilder.Computer;
import FluentBuilder.ComputerIntent;
import FluentBuilder.ComputerType;
import SimpleBuilder.*;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

class Tests {

    @Test
    void buildAFluentComputer() {
        Computer computer = new Computer
                .ComputerBuilder()
                .computerType(ComputerType.PC)
                .computerIntent(ComputerIntent.OFFICE)
                .processor("Intel Core i3-8300K")
                .ramInGB(8)
                .ssdInGB(256)
                .build();

        Assertions.assertEquals("Intel Core i3-8300K", computer.getProcessor());
    }

    @Test
    void buildASimpleOfiiceComputer() {
        Computer computer = new OfficePCBuilder().getPCOfficeComputer();
        Assertions.assertEquals("Intel Core i3-8300K", computer.getProcessor());
    }

    @AfterAll
    static void comparisionBuilderWins() throws Exception {
        System.out.println("\n\nPorównanie fabryki abstrakcyjnej i buildera w przypadku konstrukcji PC biurowych (nietypowe zamówienie - potrzeba 16 GB ramu):");
        double startTimeSimple = System.currentTimeMillis();

        BuilderVsFactory.Factory.Computer[] simpleComputers = new BuilderVsFactory.Factory.Computer[4000000];
        for (int i = 0; i < 4000000; i++) {
            PCFactory.INSTANCE.createOfficeComputer();
            simpleComputers[i] = PCFactory.INSTANCE.computer.computerClone();
            simpleComputers[i].setRAMinGB(16);
        }

        double timeSimple = System.currentTimeMillis() - startTimeSimple;
        System.out.println("Fabryka abstrakcyjna wyprodukowała 4.000.000 sztuk biurowego PC (nietypowe zamówienie - 16 GB ramu) w " + timeSimple + "ms");

        /////////////

        double startTimeBuilder = System.currentTimeMillis();

        Computer[] builderComputers = new Computer[4000000];
        for (int i = 0; i < 4000000; i++) {
            builderComputers[i] = new Computer
                    .ComputerBuilder()
                    .computerType(ComputerType.PC)
                    .computerIntent(ComputerIntent.OFFICE)
                    .processor("Intel Core i3-8300K")
                    .ramInGB(16)
                    .ssdInGB(256)
                    .build();
        }

        double timeBuilder = System.currentTimeMillis() - startTimeBuilder;
        System.out.println("Budowniczy wyprodukował 4.000.000 sztuk PC o identycznych parametrach (16 GB ramu) w " + timeBuilder + "ms");
        System.out.println("\n*************************\n");

        /////////////
    }


    @AfterAll
    static void comparisionFactoryWins() throws Exception {
        System.out.println("Porównanie fabryki abstrakcyjnej i buildera w przypadku konstrukcji PC biurowych (zwykłe, predefiniowane zestawy):");
        double startTimeSimple = System.currentTimeMillis();

        BuilderVsFactory.Factory.Computer[] simpleComputers = new BuilderVsFactory.Factory.Computer[4000000];
        for (int i = 0; i < 4000000; i++) {
            PCFactory.INSTANCE.createOfficeComputer();
            simpleComputers[i] = PCFactory.INSTANCE.computer;
        }

        double timeSimple = System.currentTimeMillis() - startTimeSimple;
        System.out.println("Fabryka abstrakcyjna wyprodukowała 4.000.000 sztuk biurowego PC (zwykłe, predefiniowane zestawy) w " + timeSimple + "ms");

        /////////////

        double startTimeBuilder = System.currentTimeMillis();

        Computer[] builderComputers = new Computer[4000000];
        for (int i = 0; i < 4000000; i++) {
            builderComputers[i] = new Computer
                    .ComputerBuilder()
                    .computerType(ComputerType.PC)
                    .computerIntent(ComputerIntent.OFFICE)
                    .processor("Intel Core i3-8300K")
                    .ramInGB(8)
                    .ssdInGB(256)
                    .build();
        }

        double timeBuilder = System.currentTimeMillis() - startTimeBuilder;
        System.out.println("Budowniczy wyprodukował 4.000.000 sztuk PC o identycznych parametrach (zwykłe, predefiniowane zestawy) w " + timeBuilder + "ms");
        System.out.println("\n*************************\n");

        /////////////
    }



}

