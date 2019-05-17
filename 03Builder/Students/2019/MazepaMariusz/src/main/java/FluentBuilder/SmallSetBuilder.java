package builder_package;

public class SmallSetBuilder extends SpeakerSetBuilder {
  public SmallSetBuilder() {
    speakerSet = new SpeakerSet("Głośniki 2.0");
  }

  @Override
  public SmallSetBuilder buildMembranes() {
    speakerSet.setPart("Membrany", "2");
    return this;
  };

  @Override
  public SmallSetBuilder buildAmplifier() {
    speakerSet.setPart("Wzmacniacz", "14W");
    return this;
  };

  @Override
  public SmallSetBuilder buildSpeakers() {
    speakerSet.setPart("Głośniki", "2");
    return this;
  };

  @Override
  public SmallSetBuilder paintSpeakerSet() {
    speakerSet.setPart("Kolor", "biały");
    return this;
  };
}
