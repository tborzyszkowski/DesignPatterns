package factoryWins.factory;

import factoryWins.factory.button.ButtonBase;
import factoryWins.factory.button.ButtonWindows;
import factoryWins.factory.window.WindowBase;
import factoryWins.factory.window.WindowWindows;

public class WindowsWidgetFactory implements WidgetFactory{

    private static WindowsWidgetFactory windowsWidgetFactory;

    private WindowsWidgetFactory() { }

    public static WindowsWidgetFactory getInstance() {
        if (windowsWidgetFactory == null) {
            synchronized (WindowsWidgetFactory.class) {
                if (windowsWidgetFactory == null) {
                    windowsWidgetFactory = new WindowsWidgetFactory();
                }
            }
        }
        return windowsWidgetFactory;
    }

    public WindowBase createWindow() {
        return new WindowWindows();
    }

    public ButtonBase createButton() {
        return new ButtonWindows();
    }
}
