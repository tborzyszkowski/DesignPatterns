package prototype.java;

import java.util.HashMap;
import java.util.Map;

import prototype.enums.CellType;

public class CellManager {

	private Map<CellType, Cell> cellMap = new HashMap() {{
		put(CellType.BONE, new BoneCell());
		put(CellType.MUSCLE, new MuscleCell());
	}};

	public Cell getCell(CellType cellType) throws CloneNotSupportedException {
		return cellMap.get(cellType).clone();
	}

}
