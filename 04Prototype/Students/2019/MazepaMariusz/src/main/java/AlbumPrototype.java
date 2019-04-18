abstract class AlbumPrototype {
  public abstract AlbumPrototype ShallowCopy() throws CloneNotSupportedException;
  public abstract AlbumPrototype DeepCopy() throws CloneNotSupportedException;
}
