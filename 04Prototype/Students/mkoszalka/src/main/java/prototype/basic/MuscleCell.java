package prototype.basic;

import prototype.enums.CellType;

public class MuscleCell implements Cell {

	@Override
	public CellType getType() {
		return CellType.MUSCLE;
	}

	@Override
	public Cell clone() {
		return new MuscleCell();
	}
}
