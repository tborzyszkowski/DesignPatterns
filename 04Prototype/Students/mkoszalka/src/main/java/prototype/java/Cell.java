package prototype.java;

import prototype.enums.CellType;

public interface Cell extends Cloneable {

	public CellType getType();

	public Cell clone() throws CloneNotSupportedException;

}
