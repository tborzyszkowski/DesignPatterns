import factoryWins.SystemName;
import factoryWins.builder.Button;
import factoryWins.builder.Window;
import factoryWins.factory.LinuxWidgetFactory;
import factoryWins.factory.WidgetFactory;
import factoryWins.factory.button.ButtonBase;
import factoryWins.factory.window.WindowBase;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class FactoryWinsTest {

    private WidgetFactory widgetFactory = LinuxWidgetFactory.getInstance();

    @Test
    public void shouldReturnWidgetFromFactory() {
        ButtonBase linuxButton = widgetFactory.createButton();
        WindowBase linuxWindow = widgetFactory.createWindow();

        assertEquals(linuxButton.system, SystemName.LINUX);
        assertEquals(linuxWindow.system, SystemName.LINUX);

        System.out.println(linuxButton);
        System.out.println(linuxWindow + "\n");
    }

    @Test
    public void shouldReturnWidgetFromBuilder() {
        Button builderButtonLinux = new Button.Builder()
                .system(SystemName.LINUX)
                .build();

        Window builderWindowLinux = new Window.Builder()
                .system(SystemName.LINUX)
                .build();

        assertEquals(builderButtonLinux.system, SystemName.LINUX);
        assertEquals(builderWindowLinux.system, SystemName.LINUX);

        System.out.println(builderButtonLinux);
        System.out.println(builderWindowLinux);
    }
}