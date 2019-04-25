package factoryWins.factory;

import factoryWins.factory.button.ButtonBase;
import factoryWins.factory.button.ButtonLinux;
import factoryWins.factory.window.WindowBase;
import factoryWins.factory.window.WindowLinux;

public class LinuxWidgetFactory implements WidgetFactory {

    private static LinuxWidgetFactory linuxWidgetFactory;

    private LinuxWidgetFactory() { }

    public static LinuxWidgetFactory getInstance() {
        if (linuxWidgetFactory == null) {
            synchronized (LinuxWidgetFactory.class) {
                if (linuxWidgetFactory == null) {
                    linuxWidgetFactory = new LinuxWidgetFactory();
                }
            }
        }
        return linuxWidgetFactory;
    }

    public WindowBase createWindow() {
        return new WindowLinux();
    }

    public ButtonBase createButton() {
        return new ButtonLinux();
    }
}
