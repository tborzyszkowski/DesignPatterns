package builder_package;
import manager_package.BuilderManager;

public class Shop {
  BuilderManager bm = new BuilderManager();

  public SpeakerSet construct(SpeakerSetBuilder builder) {
    bm.printWithLinesAround("   Trwa budowanie zestawu głośników...");
    return builder
      .buildMembranes()
      .buildAmplifier()
      .buildSpeakers()
      .paintSpeakerSet()
      .getSpeakerSet();
  }
}
