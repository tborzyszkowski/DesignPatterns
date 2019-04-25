package factoryWins.factory;

import factoryWins.factory.button.ButtonBase;
import factoryWins.factory.window.WindowBase;

public interface WidgetFactory {
    WindowBase createWindow();
    ButtonBase createButton();
}
