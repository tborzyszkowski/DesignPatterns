package builder_package;

public class LargeSetBuilder extends SpeakerSetBuilder {
  public LargeSetBuilder() {
    speakerSet = new SpeakerSet("Głośniki 5.1");
  }

  @Override
  public LargeSetBuilder buildMembranes() {
    speakerSet.setPart("Membrany", "7");
    return this;
  };

  @Override
  public LargeSetBuilder buildAmplifier() {
    speakerSet.setPart("Wzmacniacz", "120W");
    return this;
  };

  @Override
  public LargeSetBuilder buildSpeakers() {
    speakerSet.setPart("Głośniki", "6");
    return this;
  };

  @Override
  public LargeSetBuilder paintSpeakerSet() {
    speakerSet.setPart("Kolor", "czarny");
    return this;
  };
}
