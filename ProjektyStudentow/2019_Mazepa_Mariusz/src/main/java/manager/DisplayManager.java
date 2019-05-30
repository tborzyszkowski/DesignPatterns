class DisplayManager {
  public static void mainHeader() {
    System.out.println(" _____           _         _      _____         _   ");
    System.out.println("|  _  |___ ___  |_|___ ___| |_   |_   _|___ ___| |_ ");
    System.out.println("|   __|  _| . | | | -_|  _|  _|    | | | -_|_ -|  _|");
    System.out.println("|__|  |_| |___|_| |___|___|_|      |_| |___|___|_|  ");
    System.out.println("              |___|                                 ");
  }

  public static String frameIt(String frame, int times) {
    String pattern = frame;
    while (frame.length() < times) frame += pattern;
    return frame;
  }

  public static void testHeader(String testInfo) {
    System.out.print("╔" + frameIt("═", testInfo.length() + 2) + "╗\n");
    System.out.println("║ " + testInfo + " ║");
    System.out.print("╚" + frameIt("═", testInfo.length() + 2) + "╝\n");
  }

  public static void horizontalLine(int length) {
    String line = "─";
    while (line.length() < length) line += "─";
    System.out.println(line);
  }
}
