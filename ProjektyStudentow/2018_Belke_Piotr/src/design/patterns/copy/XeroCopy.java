package design.patterns.copy;

import design.patterns.client.Color;

import java.math.BigDecimal;
import java.util.UUID;

/**
 * Kopia przekazanego dokumentu.
 */
public class XeroCopy {

    /**
     * Liczba stron danych wejściowych.
     */
    private Integer pages;
    /**
     * Rodzaj wydruku.
     */
    private Color color;
    /**
     * Identyfikator klienta.
     */
    private UUID clientId;
    /**
     * Cena.
     */
    private BigDecimal cost;

    public Integer getPages() {
        return pages;
    }

    public void setPages(Integer pages) {
        this.pages = pages;
    }

    public Color getColor() {
        return color;
    }

    public void setColor(Color color) {
        this.color = color;
    }

    public UUID getClientId() {
        return clientId;
    }

    public void setClientId(UUID clientId) {
        this.clientId = clientId;
    }

    public BigDecimal getCost() {
        return cost;
    }

    public void setCost(BigDecimal cost) {
        this.cost = cost;
    }

    @Override
    public String toString() {
        return "XeroCopy{" +
                "pages=" + pages +
                ", color=" + color +
                ", clientId=" + clientId +
                ", cost=" + cost +
                '}';
    }
}
