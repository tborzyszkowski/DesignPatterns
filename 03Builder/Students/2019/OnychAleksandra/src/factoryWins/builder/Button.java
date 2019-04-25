package factoryWins.builder;

import factoryWins.SystemName;
import factoryWins.factory.button.ButtonBase;

public class Button extends ButtonBase {

    private Button(Builder builder) {
        system = builder.system;
    }

    public static class Builder {
        private SystemName system;

        public Builder system(SystemName system) {
            this.system = system;
            return this;
        }

        public Button build() {
            return new Button(this);
        }
    }
}
