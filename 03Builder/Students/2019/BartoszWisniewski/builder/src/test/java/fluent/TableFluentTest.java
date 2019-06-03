package fluent;

import static org.junit.Assert.*;

import org.junit.Test;

public class TableFluentTest {

	
	@Test
	public void createTableTest(){
		TableFluent table = new TableFluent.Builder()
				.addNumberOfSeats(4)
				.addWaiterName("Krzys")
				.addTableType(TableType.ROUND)
				.addTableName("Stol Ramzesa")
				.build();
		
		assertEquals(Integer.valueOf(4), table.getNumberOfSeats());
		assertEquals("Krzys", table.getWaiterName());
		assertEquals(TableType.ROUND, table.getTableType());
		assertEquals("Stol Ramzesa", table.getTableName());
	}

	@Test
	public void createDefaultTableTest(){
		TableFluent table = new TableFluent.Builder()
				.build();
		
		assertEquals(null, table.getNumberOfSeats());
		assertEquals(null, table.getWaiterName());
		assertEquals(null, table.getTableType());
		assertEquals("nienazwany", table.getTableName());
	}
	
	
}
