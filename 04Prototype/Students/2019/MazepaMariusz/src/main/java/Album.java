import java.time.Duration;
import java.util.ArrayList;

class Album extends AlbumPrototype implements Cloneable {
  private String tag;
  private String title;
  private ArrayList<Song> tracklist;
  private Duration duration;
  private int year;

  public Album(String tag, String title, ArrayList<Song> tracklist, Duration duration, int year) {
    this.tag = tag;
    this.title = title;
    this.tracklist = tracklist;
    this.duration = duration;
    this.year = year;
  }

  public Album(Album album) throws CloneNotSupportedException {
    this(album.getTag(), album.getTitle(), album.prepareClonedTracklist(album), album.getDuration(), album.getYear());
  }

  String getTag() { return this.tag; }
  void setTag(String tag) { this.tag = tag; }

  String getTitle() { return this.title; }
  void setTitle(String title) { this.title = title; }

  ArrayList<Song> getTracklist() { return this.tracklist; }
  void setTracklist(ArrayList<Song> tracklist) { this.tracklist = tracklist; }

  Duration getDuration() { return this.duration; }
  void setDuration(Duration duration) { this.duration = duration; }

  int getYear() { return this.year; }
  void setYear(int year) { this.year = year; }

  public ArrayList<Song> prepareClonedTracklist(Album album) throws CloneNotSupportedException {
    ArrayList<Song> tracklist = new ArrayList<Song>();
    for (Song song : album.getTracklist()) {
      tracklist.add((Song) song.DeepCopy());
    }
    return tracklist;
  }

  public String prepareDuration() {
    int minutes = (int) this.duration.getSeconds()/60;
    int seconds = (int) this.duration.getSeconds()%60;
    return minutes + ":" + seconds;
  }

  public String toString() {
    String generalInfo = "Album \"" + this.title + "\", " + this.prepareDuration() + ", " + this.year + "\n";
    int counter = 0;
    generalInfo += "         LISTA UTWORÓW:\n";
    for (Song song : tracklist) {
      generalInfo += "            " + (counter+1) + ". " + song.toString();
      if (counter < tracklist.size() - 1) generalInfo += "\n";
      counter++;
    }
    return generalInfo;
  }

  @Override
  public AlbumPrototype ShallowCopy() throws CloneNotSupportedException {
    System.out.println("[SHALLOW COPYING]: " + this.toString());
    return (AlbumPrototype) this.clone();
  }

  @Override
  public AlbumPrototype DeepCopy() throws CloneNotSupportedException {
    System.out.println("[DEEP COPYING]: " + this.toString());
    return (AlbumPrototype) new Album(this);
  }
}
