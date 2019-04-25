package factoryWins.factory.window;

import factoryWins.SystemName;

public abstract class WindowBase {
    public SystemName system;

    @Override
    public String toString() {
        return "WindowBase{" +
                "system=" + system +
                '}';
    }
}
