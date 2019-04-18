import java.util.Map;
import java.util.HashMap;
import java.util.ArrayList;

class MusicStoreManager {
  private static Map<String, MusicStorePrototype> musicStores = new HashMap<String, MusicStorePrototype>();

  public static MusicStorePrototype getMusicStore(String key) {
    return musicStores.get(key);
  }

  public static void setMusicStore(String key, MusicStorePrototype musicStorePrototype) {
    musicStores.put(key, musicStorePrototype);
  }

  public static Map<String, MusicStorePrototype> getAllMusicStores() {
    return musicStores;
  }

  public static void displayBoth(String typeOfCopy, MusicStore originalMusicStore, MusicStore clonedMusicStore) {
    String original = "   [Oryginał]: ";
    typeOfCopy = "   [" + typeOfCopy + "Copy]: ";
    while (original.length() < typeOfCopy.length()) original += " ";
    System.out.println(original + originalMusicStore.toString());
    System.out.println(typeOfCopy + clonedMusicStore.toString());
  }
}
