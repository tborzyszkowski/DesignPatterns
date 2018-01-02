package prototype.basic;

import prototype.enums.CellType;

public class BoneCell implements Cell {

	@Override
	public CellType getType() {
		return CellType.BONE;
	}

	@Override
	public Cell clone() {
		return new BoneCell();
	}
}
