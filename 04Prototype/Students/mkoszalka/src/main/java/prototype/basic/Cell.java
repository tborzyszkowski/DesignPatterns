package prototype.basic;

import prototype.enums.CellType;

public interface Cell {

	public CellType getType();

	public Cell clone();

}
