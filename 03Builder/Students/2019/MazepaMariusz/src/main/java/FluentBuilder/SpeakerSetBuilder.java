package builder_package;

public abstract class SpeakerSetBuilder {
  protected SpeakerSet speakerSet;

  public SpeakerSet getSpeakerSet() {
    return speakerSet;
  }

  public abstract SpeakerSetBuilder buildMembranes();
  public abstract SpeakerSetBuilder buildAmplifier();
  public abstract SpeakerSetBuilder buildSpeakers();
  public abstract SpeakerSetBuilder paintSpeakerSet();
}
