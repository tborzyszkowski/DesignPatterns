package factory_package;

import java.util.Map;
import java.util.HashMap;

public class SmallSpeakerSet extends SpeakerSet {
  private String speakerSetType;
  private Map<String, String> parts = new HashMap<String, String>();

  public SmallSpeakerSet(String speakerSetType, String membranes, String amplifier, String speakers, String color) {
    this.speakerSetType = speakerSetType;
    parts.put("Membrany", membranes);
    parts.put("Wzmacniacz", amplifier);
    parts.put("Głośniki", speakers);
    parts.put("Kolor", color);
  }

  @Override
  public String getSpeakerSetType() {
    return this.speakerSetType;
  }

  @Override
  public String getMembranes() {
    return this.parts.get("Membrany");
  }

  @Override
  public String getAmplifier() {
    return this.parts.get("Wzmacniacz");
  }

  @Override
  public String getSpeakers() {
    return this.parts.get("Głośniki");
  }

  @Override
  public String getColor() {
    return this.parts.get("Kolor");
  }
}
