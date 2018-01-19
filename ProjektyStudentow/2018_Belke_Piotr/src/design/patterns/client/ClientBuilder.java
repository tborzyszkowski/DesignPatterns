package design.patterns.client;

import java.util.UUID;

/**
 * Builder klienta.
 */
public class ClientBuilder {

    protected Client client;

    public Client build() {
        return this.client;
    }

    public ClientBuilder newInstance() {
        this.client = new Client();
        return this;
    }

    public ClientBuilder setId(UUID id) {
        this.client.setId(id);
        return this;
    }

    public ClientBuilder setName(String name) {
        this.client.setName(name);
        return this;
    }

    public ClientBuilder setSurname(String surname) {
        this.client.setSurname(surname);
        return this;
    }


    public ClientBuilder setPages(Integer pages) {
        this.client.setPages(pages);
        return this;
    }

    public ClientBuilder setColor(Color color) {
        this.client.setColor(color);
        return this;
    }
}
