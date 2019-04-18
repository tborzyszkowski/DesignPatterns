import java.util.ArrayList;

class MusicStore extends MusicStorePrototype implements Cloneable {
  private String tag;
  private String name;
  private ArrayList<Album> albums;

  public MusicStore(String tag, String name, ArrayList<Album> albums) {
    this.tag = tag;
    this.name = name;
    this.albums = albums;
  }

  public MusicStore(MusicStore musicStore) throws CloneNotSupportedException {
    this(musicStore.getTag(), musicStore.getName(), musicStore.prepareClonedAlbums(musicStore));
  }

  String getTag() { return this.tag; }
  void setTag(String tag) { this.tag = tag; }

  String getName() { return this.name; }
  void setName(String name) { this.name = name; }

  ArrayList<Album> getAlbums() { return this.albums; }
  void setAlbums(ArrayList<Album> albums) { this.albums = albums; }

  public ArrayList<Album> prepareClonedAlbums(MusicStore musicStore) throws CloneNotSupportedException {
    ArrayList<Album> albums = new ArrayList<Album>();
    for (Album album : musicStore.getAlbums()) {
      albums.add((Album) album.DeepCopy());
    }
    return albums;
  }

  public String toString() {
    String generalInfo = "\n   MusicStore \"" + this.name + "\"\n";
    int albumsCounter = 0;
    generalInfo += "      LISTA ALBUMÓW:\n";
    for (Album album : albums) {
      generalInfo += "      " + (albumsCounter+1) + ". " + album.toString();
    }
    return generalInfo;
  }

  @Override
  public MusicStorePrototype ShallowCopy() throws CloneNotSupportedException {
    System.out.println("[SHALLOW COPYING]: " + this.toString());
    return (MusicStorePrototype) this.clone();
  }

  @Override
  public MusicStorePrototype DeepCopy() throws CloneNotSupportedException {
    System.out.println("[DEEP COPYING]: " + this.toString());
    return (MusicStorePrototype) new MusicStore(this);
  }
}
