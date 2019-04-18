class DisplayManager {
  public static final String RESET = "\u001B[0m";
  public static final String RED = "\u001b[38;5;160m";
  public static final String WHITE = "\u001b[38;5;250m";
  public static final String PURPLE = "\u001b[38;5;93m";
  public static final String YELLOW = "\u001b[38;5;226m";

  public static void printColored(String text, String color) {
    System.out.println(color + text + RESET);
  }

  public static void mainHeader() {
    printColored(" _____         _       _             _____         _   ", PURPLE);
    printColored("|  _  |___ ___| |_ ___| |_ _ _ ___ _|_   _|___ ___| |_ ", PURPLE);
    printColored("|   __|  _| . |  _| . |  _| | | . | -_| | | -_|_ -|  _|", PURPLE);
    printColored("|__|  |_| |___|_| |___|_| |_  |  _|___|_| |___|___|_|  ", PURPLE);
    printColored("                          |___|_|                      ", PURPLE);
  }

  public static String frameIt(String frame, int times) {
    String pattern = frame;
    while (frame.length() < times) frame += pattern;
    return frame;
  }

  public static void testHeader(String testInfo) {
    System.out.print(YELLOW);
    System.out.print("╔" + frameIt("═", testInfo.length() + 2) + "╗\n");
    System.out.println("║ " + testInfo + " ║");
    System.out.print("╚" + frameIt("═", testInfo.length() + 2) + "╝\n");
    System.out.print(RESET);
  }

  public static void horizontalLine(int length) {
    String line = "─";
    while (line.length() < length) line += "─";
    printColored(line, PURPLE);
  }
}
