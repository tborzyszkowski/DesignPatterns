import abstractFactory.*;
import factoryMethod.NotebookComputerFactory;
import factoryMethod.PCComputerFactory;
import noReflectionFactory.NoReflectionFactory;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.Assertions;
import reflectionFactory.ReflectionFactory;
import simpleComputerFactory.SimpleComputerFactory;
import computers.*;

import java.lang.reflect.InvocationTargetException;


class Tests {

    @BeforeAll
    static void registerTypesInReflectionFactory() {
        ReflectionFactory.INSTANCE.registerType("PC, Office", ComputerPCOffice.class);
        ReflectionFactory.INSTANCE.registerType("PC, Gaming", ComputerPCGaming.class);
        ReflectionFactory.INSTANCE.registerType("Notebook, Office", ComputerNotebookOffice.class);
        ReflectionFactory.INSTANCE.registerType("Notebook, Gaming", ComputerNotebookGaming.class);
    }

    @BeforeAll
    static void registerSuppliersInFactory() {
        NoReflectionFactory.INSTANCE.registerSupplier("PC, Office", ComputerPCOffice::new);
        NoReflectionFactory.INSTANCE.registerSupplier("PC, Gaming", ComputerPCGaming::new);
        NoReflectionFactory.INSTANCE.registerSupplier("Notebook, Office", ComputerNotebookOffice::new);
        NoReflectionFactory.INSTANCE.registerSupplier("Notebook, Gaming", ComputerNotebookGaming::new);
    }

    /////////////////SIMPLE FACTORY////////////////////////////

    @Test
    void simpleComputerFactoryOfficePC() throws Exception {
        SimpleComputerFactory.INSTANCE.sendRequestToFactory("PC", "Office");
        Assertions.assertEquals(SimpleComputerFactory.INSTANCE.computer.toString(), new ComputerPCOffice().toString());
    }

    @Test
    void simpleComputerFactoryGamingPC() throws Exception {
        SimpleComputerFactory.INSTANCE.sendRequestToFactory("PC", "Gaming");
        Assertions.assertEquals(SimpleComputerFactory.INSTANCE.computer.toString(), new ComputerPCGaming().toString());
    }

    @Test
    void simpleComputerFactoryOfficeNotebook() throws Exception {
        SimpleComputerFactory.INSTANCE.sendRequestToFactory("Notebook", "Office");
        Assertions.assertEquals(SimpleComputerFactory.INSTANCE.computer.toString(), new ComputerNotebookOffice().toString());
    }

    @Test
    void simpleComputerFactoryGamingNotebook() throws Exception {
        SimpleComputerFactory.INSTANCE.sendRequestToFactory("Notebook", "Gaming");
        Assertions.assertEquals(SimpleComputerFactory.INSTANCE.computer.toString(), new ComputerNotebookGaming().toString());
    }

    ///////////////FACTORY METHOD///////////////////////////////

    @Test
    void factoryMethodOfficePC() throws Exception {
        PCComputerFactory.INSTANCE.sendRequestToFactory("Office");
        Assertions.assertEquals(PCComputerFactory.INSTANCE.computer.toString(), new ComputerPCOffice().toString());
    }

    @Test
    void factoryMethodGamingPC() throws Exception {
        PCComputerFactory.INSTANCE.sendRequestToFactory("Gaming");
        Assertions.assertEquals(PCComputerFactory.INSTANCE.computer.toString(), new ComputerPCGaming().toString());
    }

    @Test
    void factoryMethodOfficeNotebook() throws Exception {
        NotebookComputerFactory.INSTANCE.sendRequestToFactory("Office");
        Assertions.assertEquals(NotebookComputerFactory.INSTANCE.computer.toString(), new ComputerNotebookOffice().toString());
    }

    @Test
    void factoryMethodGamingNotebook() throws Exception {
        NotebookComputerFactory.INSTANCE.sendRequestToFactory("Gaming");
        Assertions.assertEquals(NotebookComputerFactory.INSTANCE.computer.toString(), new ComputerNotebookGaming().toString());
    }

    //////////////////////ABSTRACT FACTORY////////////////////////

    @Test
    void abstractFactoryOfficePC() {
        PCFactory.INSTANCE.createOfficeComputer();
        Assertions.assertEquals(PCFactory.INSTANCE.computer.toString(), new ComputerPCOffice().toString());
    }

    @Test
    void abstractFactoryGamingPC() {
        PCFactory.INSTANCE.createGamingComputer();
        Assertions.assertEquals(PCFactory.INSTANCE.computer.toString(), new ComputerPCGaming().toString());
    }

    @Test
    void abstractFactoryOfficeNotebook() {
        NotebookFactory.INSTANCE.createOfficeComputer();
        Assertions.assertEquals(NotebookFactory.INSTANCE.computer.toString(), new ComputerNotebookOffice().toString());
    }

    @Test
    void abstractFactoryGamingNotebook() {
        NotebookFactory.INSTANCE.createGamingComputer();
        Assertions.assertEquals(NotebookFactory.INSTANCE.computer.toString(), new ComputerNotebookGaming().toString());
    }

    /////////////////REGISTERED TYPES FACTORY WITH REFLECTION/////////////

    @Test
    void registeredTypesFactoryReflectionOfficePC() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Assertions.assertEquals(ReflectionFactory.INSTANCE.getComputer("PC, Office").toString(), new ComputerPCOffice().toString());
    }

    @Test
    void registeredTypesFactoryReflectionGamingPC() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Assertions.assertEquals(ReflectionFactory.INSTANCE.getComputer("PC, Gaming").toString(), new ComputerPCGaming().toString());
    }

    @Test
    void registeredTypesFactoryReflectionOfficeNotebook() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Assertions.assertEquals(ReflectionFactory.INSTANCE.getComputer("Notebook, Office").toString(), new ComputerNotebookOffice().toString());
    }

    @Test
    void registeredTypesFactoryReflectionGamingNotebook() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Assertions.assertEquals(ReflectionFactory.INSTANCE.getComputer("Notebook, Gaming").toString(), new ComputerNotebookGaming().toString());
    }

    /////////////////REGISTERED TYPES FACTORY WITH REFLECTION/////////////

    @Test
    void registeredTypesFactoryOfficePC() {
        Assertions.assertEquals(NoReflectionFactory.INSTANCE.getComputer("PC, Office").toString(), new ComputerPCOffice().toString());
    }

    @Test
    void registeredTypesFactoryGamingPC() {
        Assertions.assertEquals(NoReflectionFactory.INSTANCE.getComputer("PC, Gaming").toString(), new ComputerPCGaming().toString());
    }

    @Test
    void registeredTypesFactoryOfficeNotebook() {
        Assertions.assertEquals(NoReflectionFactory.INSTANCE.getComputer("Notebook, Office").toString(), new ComputerNotebookOffice().toString());
    }

    @Test
    void registeredTypesFactoryGamingNotebook() {
        Assertions.assertEquals(NoReflectionFactory.INSTANCE.getComputer("Notebook, Gaming").toString(), new ComputerNotebookGaming().toString());
    }

    //////////COMPARISION////////

    @AfterAll
    static void comparision() throws Exception {
        System.out.println("Porównanie fabryk:\n");
        double startTimeSimple = System.currentTimeMillis();

        Computer[] simpleComputers = new Computer[10000];
        for (int i = 0; i < 10000; i++) {
            SimpleComputerFactory.INSTANCE.sendRequestToFactory("PC", "Office");
            simpleComputers[i] = SimpleComputerFactory.INSTANCE.computer.computerClone();
        }

        double timeSimple = System.currentTimeMillis() - startTimeSimple;
        System.out.println("Prosta fabryka wyprodukowała 10000 sztuk biurowego PC w " + timeSimple + "ms");

        /////////////

        double startTimeAbstract = System.currentTimeMillis();

        Computer[] abstractComputers = new Computer[10000];
        for (int i = 0; i < 10000; i++) {
            PCFactory.INSTANCE.createOfficeComputer();
            abstractComputers[i] = PCFactory.INSTANCE.computer.computerClone();
        }

        double timeAbstract = System.currentTimeMillis() - startTimeAbstract;
        System.out.println("Abstrakcyjna fabryka wyprodukowała 10000 sztuk biurowego PC w " + timeAbstract + "ms");

        /////////////

        double startTimeMethod = System.currentTimeMillis();

        Computer[] methodComputers = new Computer[10000];
        for (int i = 0; i < 10000; i++) {
            PCComputerFactory.INSTANCE.sendRequestToFactory("Office");
            methodComputers[i] = PCComputerFactory.INSTANCE.computer.computerClone();
        }

        double timeMethod = System.currentTimeMillis() - startTimeMethod;
        System.out.println("Metoda fabrykująca wyprodukowała 10000 sztuk biurowego PC w " + timeMethod + "ms");


        /////////////

        double startTimeNoReflection = System.currentTimeMillis();

        Computer[] noReflectionComputers = new Computer[10000];
        for (int i = 0; i < 10000; i++) {
            noReflectionComputers[i] = NoReflectionFactory.INSTANCE.getComputer("PC, Office").computerClone();
        }

        double timeNoReflection = System.currentTimeMillis() - startTimeNoReflection;
        System.out.println("Fabryka z rejestracją typów (bez refleksji) wyprodukowała 10000 sztuk biurowego PC w " + timeNoReflection + "ms");

        //////////////

        double startTimeReflection = System.currentTimeMillis();

        Computer[] reflectionComputers = new Computer[10000];
        for (int i = 0; i < 10000; i++) {
            reflectionComputers[i] = ReflectionFactory.INSTANCE.getComputer("PC, Office").computerClone();
        }

        double timeReflection = System.currentTimeMillis() - startTimeReflection;
        System.out.println("Fabryka z rejestracją typów (z refleksją) wyprodukowała 10000 sztuk biurowego PC w " + timeReflection + "ms");

        System.out.println();
    }
}
