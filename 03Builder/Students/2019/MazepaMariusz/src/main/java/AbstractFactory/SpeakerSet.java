package factory_package;

public abstract class SpeakerSet {
  public abstract String getSpeakerSetType();
  public abstract String getMembranes();
  public abstract String getAmplifier();
  public abstract String getSpeakers();
  public abstract String getColor();

  @Override
  public String toString() {
    return "      Typ zestawu: " + this.getSpeakerSetType() + "\n"
      + "         Głośniki: " + this.getMembranes() + "\n"
      + "         Wzmacniacz: " + this.getAmplifier() + "\n"
      + "         Membrany: " + this.getSpeakers() + "\n"
      + "         Kolor: " + this.getColor();
  }
}
