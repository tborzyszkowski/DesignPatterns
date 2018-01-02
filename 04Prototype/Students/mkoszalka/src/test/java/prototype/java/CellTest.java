package prototype.java;

import org.junit.jupiter.api.Test;

import prototype.enums.CellType;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class CellTest {

	@Test
	public void clone_testBone() throws Exception {
		Cell cell = new BoneCell();
		assertEquals(cell.getType(), CellType.BONE);

		Cell copy = cell.clone();
		assertEquals(copy.getType(), cell.getType());
	}

	@Test
	public void clone_testMuscle() throws Exception  {
		Cell cell = new MuscleCell();
		assertEquals(cell.getType(), CellType.MUSCLE);

		Cell copy = cell.clone();
		assertEquals(copy.getType(), cell.getType());
	}

}
