package mbreza;

import mbreza.caseForBuilder.PcSetBuilder;
import mbreza.classic.GameType;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class CaseForBuilderTest {

    @Test
    public void getSessionTest() {
        PcSetBuilder psb = new PcSetBuilder.Builder()
                .addMonitor("a Monitor")
                .addBox("a Case")
                .addMotherboard("a Motherboard")
                .addPsu("a PSU")
                .addStorage("a Storage")
                .addRam("a RAM")
                .addGpu("a GPU")
                .addCpu("a CPU")
                .build();

        assertEquals(psb.getMonitor(), "a Monitor");
        assertEquals(psb.getBox(), "a Case");
        assertEquals(psb.getMotherboard(), "a Motherboard");
        assertEquals(psb.getPsu(), "a PSU");
        assertEquals(psb.getStorage(), "a Storage");
        assertEquals(psb.getRam(), "a RAM");
        assertEquals(psb.getGpu(), "a GPU");
        assertEquals(psb.getCpu(), "a CPU");
    }

}
