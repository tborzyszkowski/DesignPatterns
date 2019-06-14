package ug.anovik.dp.adapter;

import java.util.function.Function;

import ug.anovik.dp.MobileDevice;

public class Antutu {
	private MobileDevice md;

	public Antutu(MobileDevice md) {
		this.md = md;
	}

	private Function<Integer, String> valuer = i -> {
		System.out.println(md);
		int score = (md.getMemory().getRom() + i * 15) / (md.getMemory().getRom() - i) + md.getMemory().getRom()
				+ i * 25;
		return "The total score by AnTuTu is: " + score;
	};

	public Function<Integer, String> getValuer() {
		return valuer;
	}

}
