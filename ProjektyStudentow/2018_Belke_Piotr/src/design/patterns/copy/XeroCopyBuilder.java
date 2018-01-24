package design.patterns.copy;

import design.patterns.Constants;
import design.patterns.client.Color;

import java.math.BigDecimal;
import java.util.UUID;

public class XeroCopyBuilder {

    protected XeroCopy copy;

    public XeroCopy build() {
        return this.copy;
    }

    public XeroCopyBuilder newInstance() {
        this.copy = new XeroCopy();
        return this;
    }

    public XeroCopyBuilder setClientId(UUID clientId) {
        this.copy.setClientId(clientId);
        return this;

    }

    public XeroCopyBuilder setPages(Integer pages) {
        this.copy.setPages(pages);
        return this;
    }

    public XeroCopyBuilder setColor(Color color) {
        this.copy.setColor(color);
        return this;
    }

    public XeroCopyBuilder countCost() {
        if(Color.COLOR.equals(copy.getColor())){
            this.copy.setCost(Constants.COLOR_INK_PAGE_COST.multiply(new BigDecimal(copy.getPages())));
        } else {
            this.copy.setCost(Constants.BLACK_INK_PAGE_COST.multiply(new BigDecimal(copy.getPages())));
        }
        return this;
    }
}
