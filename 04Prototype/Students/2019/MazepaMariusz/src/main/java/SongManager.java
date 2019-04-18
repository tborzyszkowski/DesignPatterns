import java.util.Map;
import java.util.HashMap;

class SongManager {
  private static Map<String, SongPrototype> songs = new HashMap<String, SongPrototype>();

  public static SongPrototype getSong(String key) {
    return songs.get(key);
  }

  public static void setSong(String key, SongPrototype songPrototype) {
    songs.put(key, songPrototype);
  }

  public static Map<String, SongPrototype> getAllSongs() {
    return songs;
  }

  public static void displayBoth(String typeOfCopy, Song originalSong, Song clonedSong) {
    DisplayManager dm = new DisplayManager();

    String color = new String();
    if (typeOfCopy.equals("Shallow")) color = dm.RED;
    else if (typeOfCopy.equals("Deep")) color = dm.WHITE;

    String original = "   [Oryginał]: ";
    typeOfCopy = "   [" + typeOfCopy + "Copy]: ";
    while (original.length() < typeOfCopy.length()) original += " ";

    dm.printColored(original + originalSong.toString(), color);
    dm.printColored(typeOfCopy + clonedSong.toString(), color);
  }
}
