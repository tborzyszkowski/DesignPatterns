package factoryWins.factory.button;

import factoryWins.SystemName;

public abstract class ButtonBase {
    public SystemName system;

    @Override
    public String toString() {
        return "ButtonBase{" +
                "system=" + system +
                '}';
    }
}
