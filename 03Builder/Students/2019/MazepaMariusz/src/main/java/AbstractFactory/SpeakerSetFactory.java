package factory_package;

public class SpeakerSetFactory {
	public static SpeakerSet getSpeakerSet(SpeakerSetAbstractFactory factory){
		return factory.createSpeakerSet();
	}
}
