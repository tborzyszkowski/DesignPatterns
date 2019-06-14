package ug.anovik.dp.adapter;

import java.util.function.Function;

import ug.anovik.dp.MobileDevice;

public class Ranking extends Rankingable {

	private Function<Integer, String> valuer;

	public Ranking(Rankingable rankingable) {
		valuer = i -> "The total score is: " + rankingable.computeScore(i);
	}

	public Ranking(Geekbench gb) {
		this.valuer = gb.getValuer();
	}

	public Ranking(Antutu at) {
		this.valuer = at.getValuer();
	}

	public String useValuer(int i) {
		return valuer.apply(i);
	}

	public void changeValuer(Function<Integer, String> valuer) {
		this.valuer = valuer;
	}
	
}
