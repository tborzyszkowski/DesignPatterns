/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package builderbetterthenfactory.builder;

/**
 *
 * @author Marcin
 */
public class Seller {
    private MacBookBuilder macBookBuilder;

    public void setMacBookBuilder(MacBookBuilder mb) {
        macBookBuilder = mb;
    }

    public Mac getMac() {
        return macBookBuilder.getMac();
    }

    public void constructMac() {
        macBookBuilder.createNewMacProduct();
        macBookBuilder.buildProcesor();
        macBookBuilder.buildRam();
        macBookBuilder.buildHardDisc();
        macBookBuilder.buildGraphicsCard();
    }
}
