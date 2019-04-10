import java.time.Duration;

class Song extends SongPrototype implements Cloneable {
  private String tag;
  private Person author;
  private String title;
  private Duration duration;
  private int year;

  public Song(String tag, Person author, String title, Duration duration, int year) {
    this.tag = tag;
    this.author = author;
    this.title = title;
    this.duration = duration;
    this.year = year;
  }

  public Song(Song song) {
    this(song.getTag(), new Person(song.getAuthor()), song.getTitle(), song.getDuration(), song.getYear());
  }

  String getTag() { return this.tag; }
  void setTag(String tag) { this.tag = tag; }

  Person getAuthor() { return this.author; }
  void setAuthor(Person author) { this.author = author; }

  String getTitle() { return this.title; }
  void setTitle(String title) { this.title = title; }

  Duration getDuration() { return this.duration; }
  void setDuration(Duration duration) { this.duration = duration; }

  int getYear() { return this.year; }
  void setYear(int year) { this.year = year; }

  public String prepareDuration() {
    int minutes = (int) this.duration.getSeconds()/60;
    int seconds = (int) this.duration.getSeconds()%60;
    return minutes + ":" + seconds;
  }

  public String toString() {
    return this.author.toString() + ", \"" + this.title + "\", " + this.prepareDuration() + ", " + this.year;
  }

  @Override
  public SongPrototype ShallowCopy() throws CloneNotSupportedException {
    System.out.println("[SHALLOW COPYING]: " + this.toString());
    return (SongPrototype) this.clone();
  }

  @Override
  public SongPrototype DeepCopy() throws CloneNotSupportedException {
    System.out.println("[DEEP COPYING]: " + this.toString());
    return (SongPrototype) new Song(this);
  }
}
