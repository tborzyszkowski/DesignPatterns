import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.Map;
import java.util.ArrayList;
import java.time.Duration;

import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;

public class MusicTest {
  static Person author1;
  static Person author2;
  static Person author3;

  static String tag1 = "robbie";
  static String tag2 = "john_young";
  static String tag3 = "jelonek";

  static Song song1;
  static Song song2;
  static Song song3;

  static String albumTag = "various_artist";
  static String albumTitle = "Zagraniczne Przeboje";
  static Album album;

  static String musicStoreTag = "gdansk_music";
  static String musicStoreName = "Muzyczny Gdańsk";
  static MusicStore musicStore;

  static DisplayManager dm = new DisplayManager();
  static SongManager sm = new SongManager();
  static AlbumManager am = new AlbumManager();
  static MusicStoreManager msm = new MusicStoreManager();

  @BeforeClass
  public static void setUpClass() {
    dm.mainHeader();
    dm.printColored("Rozpoczęcie testowania...", dm.PURPLE);
  }

  @AfterClass
  public static void tearDownClass() {
    dm.horizontalLine(55);
    dm.printColored("Testowanie zakończone.", dm.PURPLE);
    System.out.print("\n");
  }

  @Before
  public void setUp() {
    author1 = new Person("Robbie", "Rotten");
    author2 = new Person("Jonathan", "Young");
    author3 = new Person("Michał", "Jelonek");

    song1 = new Song(tag1, author1, "We Are Number One", Duration.ofSeconds(2*60+18), 2014);
    song2 = new Song(tag2, author2, "BAIT", Duration.ofSeconds(2*60+43), 2018);
    song3 = new Song(tag3, author3, "Akka", Duration.ofSeconds(2*60+33), 2007);

    sm.setSong(tag1, song1);
    sm.setSong(tag2, song2);
    sm.setSong(tag3, song3);

    ArrayList<Song> tracklist = new ArrayList<Song>();
    tracklist.add(song1);
    tracklist.add(song2);
    tracklist.add(song3);

    album = new Album(albumTag, albumTitle, tracklist, am.sumDurations(tracklist), am.getLatestYear(tracklist));
    am.setAlbum(albumTag, album);

    ArrayList<Album> albums = new ArrayList<Album>();
    albums.add(album);

    musicStore = new MusicStore(musicStoreTag, musicStoreName, albums);
    msm.setMusicStore(musicStoreTag, musicStore);

    dm.horizontalLine(55);
  }

  @After
  public void tearDown() {
    // dm.horizontalLine(55);
  }

  @Test
  public void song_shallowCopyTest() throws CloneNotSupportedException {
    dm.testHeader("Zad1. (Song) Shallow Copy Test");

    Song song1_shallowCopy = (Song) sm.getSong(song1.getTag()).ShallowCopy();
    song1.getAuthor().setFirstName("Robert");
    sm.displayBoth("Shallow", song1, song1_shallowCopy);
    assertEquals(song1.getAuthor(), song1_shallowCopy.getAuthor());
    assertSame(song1.getAuthor(), song1_shallowCopy.getAuthor());

    Song song2_shallowCopy = (Song) sm.getSong(song2.getTag()).ShallowCopy();
    song2.getAuthor().setLastName("Młody");
    sm.displayBoth("Shallow", song2, song2_shallowCopy);
    assertEquals(song2.getAuthor(), song2_shallowCopy.getAuthor());
    assertSame(song2.getAuthor(), song2_shallowCopy.getAuthor());

    Song song3_shallowCopy = (Song) sm.getSong(song3.getTag()).ShallowCopy();
    song3.getAuthor().setFirstName("Michael");
    song3.getAuthor().setLastName("Deer");
    sm.displayBoth("Shallow", song3, song3_shallowCopy);
    assertEquals(song3.getAuthor(), song3_shallowCopy.getAuthor());
    assertSame(song3.getAuthor(), song3_shallowCopy.getAuthor());
  }

  @Test
  public void song_deepCopyTest() throws CloneNotSupportedException {
    dm.testHeader("Zad1. (Song) Deep Copy Test");

    Song song1_deepCopy = (Song) sm.getSong(song1.getTag()).DeepCopy();
    song1.getAuthor().setFirstName("Robert");
    sm.displayBoth("Deep", song1, song1_deepCopy);
    assertNotEquals(song1.getAuthor(), song1_deepCopy.getAuthor());
    assertNotSame(song1.getAuthor(), song1_deepCopy.getAuthor());

    Song song2_deepCopy = (Song) sm.getSong(song2.getTag()).DeepCopy();
    song2.getAuthor().setLastName("Młody");
    sm.displayBoth("Deep", song2, song2_deepCopy);
    assertNotEquals(song2.getAuthor(), song2_deepCopy.getAuthor());
    assertNotSame(song2.getAuthor(), song2_deepCopy.getAuthor());

    Song song3_deepCopy = (Song) sm.getSong(song3.getTag()).DeepCopy();
    song3.getAuthor().setFirstName("Michael");
    song3.getAuthor().setLastName("Deer");
    sm.displayBoth("Deep", song3, song3_deepCopy);
    assertNotEquals(song3.getAuthor(), song3_deepCopy.getAuthor());
    assertNotSame(song3.getAuthor(), song3_deepCopy.getAuthor());
  }

  @Test
  public void musicStore_shallowCopyTest() throws CloneNotSupportedException {
    dm.testHeader("Zad2. (MusicStore) Shallow Copy Test");

    MusicStore musicStore_shallowCopy = (MusicStore) msm.getMusicStore(musicStore.getTag()).ShallowCopy();
    musicStore.getAlbums().get(0).getTracklist().get(0).getAuthor().setFirstName("Flobby");
    System.out.print("───[ORYGINAŁ]──────────────────────────────────────────");
    dm.printColored(musicStore.toString(), dm.RED);
    System.out.print("───[SHALLOW COPY]──────────────────────────────────────");
    dm.printColored(musicStore_shallowCopy.toString(), dm.RED);

    Person original = musicStore.getAlbums().get(0).getTracklist().get(0).getAuthor();
    Person shallowCopy = musicStore_shallowCopy.getAlbums().get(0).getTracklist().get(0).getAuthor();
    assertEquals(original, shallowCopy);
    assertSame(original, shallowCopy);
  }

  @Test
  public void musicStore_deepCopyTest() throws CloneNotSupportedException {
    dm.testHeader("Zad2. (MusicStore) Deep Copy Test");

    MusicStore musicStore_deepCopy = (MusicStore) msm.getMusicStore(musicStore.getTag()).DeepCopy();
    musicStore.getAlbums().get(0).getTracklist().get(0).getAuthor().setFirstName("Flobby");
    System.out.print("───[ORYGINAŁ]──────────────────────────────────────────");
    dm.printColored(musicStore.toString(), dm.WHITE);
    System.out.print("───[DEEP COPY]─────────────────────────────────────────");
    dm.printColored(musicStore_deepCopy.toString(), dm.WHITE);

    Person original = musicStore.getAlbums().get(0).getTracklist().get(0).getAuthor();
    Person deepCopy = musicStore_deepCopy.getAlbums().get(0).getTracklist().get(0).getAuthor();
    assertNotEquals(original, deepCopy);
    assertNotSame(original, deepCopy);
  }
}
