package design.patterns.client;

import java.util.UUID;

/**
 * Obiekt klienta.
 */
public class Client {

    /**
     * Identyfikator klienta.
     */
    private UUID id;
    /**
     * Imię.
     */
    private String name;
    /**
     * Nazwisko.
     */
    private String surname;
    /**
     * Liczba stron danych wejściowych.
     */
    private Integer pages;
    /**
     * Rodzaj wydruku.
     */
    private Color color;

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

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
}
