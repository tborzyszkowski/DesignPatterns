import java.util.ArrayList;
import java.util.List;

public class Pizza {

    public Pizza(Builder builder) {
        this.rozmiar = builder.rozmiarBuilder;
        this.ciasto = builder.ciastoBuilder;
        this.skladniki = builder.skladnikiBuilder;
    }

    private final Rozmiar rozmiar;

    private final Ciasto ciasto;

    private final List<String> skladniki;

    @Override
    public String toString() {
        return "Pizza{" +
                "rozmiar=" + rozmiar +
                ", ciasto=" + ciasto +
                ", skladniki=" + skladniki +
                '}';
    }

    public static class Builder {
        private Rozmiar rozmiarBuilder;

        private Ciasto ciastoBuilder;

        private List<String> skladnikiBuilder = new ArrayList<>();

        public Builder(Rozmiar rozmiarBuilder) {
            this.rozmiarBuilder = rozmiarBuilder;
        }

        public Builder ciasto(Ciasto ciasto) {
            ciastoBuilder = ciasto;
            return this;
        }

        public Builder skladnik(String skladnik) {
            skladnikiBuilder.add(skladnik);
            return this;
        }

        public Pizza build() {
            return new Pizza(this);
        }
    }
}

