package prototype.basic;

import org.junit.jupiter.api.Test;

import prototype.enums.CellType;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotEquals;

public class CellTest {

	@Test
	public void clone_testBone() {
		Cell cell = new BoneCell();
		assertEquals(cell.getType(), CellType.BONE);

		Cell copy = cell.clone();
		assertEquals(copy.getType(), cell.getType());
		assertNotEquals(copy, cell);
	}

	@Test
	public void clone_testMuscle() {
		Cell cell = new MuscleCell();
		assertEquals(cell.getType(), CellType.MUSCLE);

		Cell copy = cell.clone();
		assertEquals(copy.getType(), cell.getType());
		assertNotEquals(copy, cell);
	}

}
