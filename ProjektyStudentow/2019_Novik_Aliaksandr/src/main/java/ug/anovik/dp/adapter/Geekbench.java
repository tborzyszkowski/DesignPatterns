package ug.anovik.dp.adapter;

import java.util.function.Function;

import ug.anovik.dp.MobileDevice;

public class Geekbench {
	private MobileDevice md;

	public Geekbench(MobileDevice md) {
		this.md = md;
	}

	private Function<Integer, String> valuer = i -> {
		System.out.println(md);
		int score = (md.getMemory().getRom() + i * 15) / (md.getMemory().getRom() -i) + md.getMemory().getRom();
		return "The total score by GeekBench is: " + score;
	};

	public Function<Integer, String> getValuer() {
		return valuer;
	}

}
