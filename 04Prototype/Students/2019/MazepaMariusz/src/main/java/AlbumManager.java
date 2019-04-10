import java.util.Map;
import java.util.HashMap;
import java.util.ArrayList;
import java.time.Duration;

class AlbumManager {
  private static Map<String, AlbumPrototype> albums = new HashMap<String, AlbumPrototype>();

  public static AlbumPrototype getAlbum(String key) {
    return albums.get(key);
  }

  public static void setAlbum(String key, AlbumPrototype albumPrototype) {
    albums.put(key, albumPrototype);
  }

  public static Map<String, AlbumPrototype> getAllAlbums() {
    return albums;
  }

  public static void displayBoth(String typeOfCopy, Album originalAlbum, Album clonedAlbum) {
    String original = "   [Oryginał]: ";
    typeOfCopy = "   [" + typeOfCopy + "Copy]: ";
    while (original.length() < typeOfCopy.length()) original += " ";
    System.out.println(original + originalAlbum.toString());
    System.out.println(typeOfCopy + clonedAlbum.toString());
  }

  public static Duration sumDurations(ArrayList<Song> tracklist) {
    Duration tracklistDuration = Duration.ofSeconds(0);
    for (Song song : tracklist) {
      tracklistDuration = tracklistDuration.plusSeconds(song.getDuration().getSeconds());
    }
    return tracklistDuration;
  }

  public static Integer getLatestYear(ArrayList<Song> tracklist) {
    int latestYear = 0;
    for (Song song : tracklist) {
      if (song.getYear() > latestYear) latestYear = song.getYear();
    }
    return latestYear;
  }
}
