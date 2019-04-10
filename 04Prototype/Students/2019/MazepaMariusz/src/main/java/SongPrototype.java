abstract class SongPrototype {
  public abstract SongPrototype ShallowCopy() throws CloneNotSupportedException;
  public abstract SongPrototype DeepCopy() throws CloneNotSupportedException;
}
