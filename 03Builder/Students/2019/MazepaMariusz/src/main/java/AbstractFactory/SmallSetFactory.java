package factory_package;
import manager_package.BuilderManager;

public class SmallSetFactory implements SpeakerSetAbstractFactory {
  private BuilderManager bm = new BuilderManager();

  private String speakerSetType;
  private String membranes;
  private String amplifier;
  private String speakers;
  private String color;

	public SmallSetFactory(String speakerSetType, String membranes, String amplifier, String speakers, String color) {
    this.speakerSetType = speakerSetType;
    this.membranes = membranes;
    this.amplifier = amplifier;
    this.speakers = speakers;
    this.color = color;
	}

	@Override
	public SpeakerSet createSpeakerSet() {
    bm.printWithLinesAround("   Trwa budowanie zestawu głośników...");
		return new SmallSpeakerSet(speakerSetType, membranes, amplifier, speakers, color);
	}
}
