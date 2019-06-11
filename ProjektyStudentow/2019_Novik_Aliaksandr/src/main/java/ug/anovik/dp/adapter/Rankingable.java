package ug.anovik.dp.adapter;

import ug.anovik.dp.MobileDevice;

public class Rankingable {

	protected MobileDevice md;

	public Rankingable() {

	}
	
	public MobileDevice getMd() {
		return this.md;
	}

	public Rankingable(MobileDevice md) {
		this.md = md;
	}

	public int computeScore(int i) {
		System.out.println(md);
		return (md.getMemory().getRom() + i) / md.getMemory().getRom() + md.getMemory().getRom() - i;
	}
}
