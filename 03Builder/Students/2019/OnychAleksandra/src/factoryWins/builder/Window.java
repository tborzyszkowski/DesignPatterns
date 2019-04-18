package factoryWins.builder;

import factoryWins.SystemName;
import factoryWins.factory.window.WindowBase;

public class Window extends WindowBase {

    private Window(Builder builder) {
        system = builder.system;
    }

    public static class Builder {
        private SystemName system;

        public Builder system(SystemName system) {
            this.system = system;
            return this;
        }

        public Window build() {
            return new Window(this);
        }
    }
}
