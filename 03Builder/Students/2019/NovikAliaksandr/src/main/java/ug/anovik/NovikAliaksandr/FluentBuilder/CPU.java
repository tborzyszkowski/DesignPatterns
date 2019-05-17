package ug.anovik.NovikAliaksandr.FluentBuilder;

public class CPU {
	private int coreNum;
	private String frequency;

	public CPU(int coreNum, String frequency) {
		this.coreNum = coreNum;
		this.frequency = frequency;
	}

	public int getCoreNum() {
		return coreNum;
	}

	public void setCoreNum(int coreNum) {
		this.coreNum = coreNum;
	}

	public String getFrequency() {
		return frequency;
	}

	public void setFrequency(String frequency) {
		this.frequency = frequency;
	}

	@Override
	public String toString() {
		return "CPU [coreNum=" + coreNum + ", frequency=" + frequency + "]";
	}
	
	
}
