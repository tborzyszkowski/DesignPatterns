package builder_vs_factory;

import fluent.TableType;

public class TableFluent {
	private TableType tableType;
	private Integer numberOfSeats;
	private String waiterName;
	private String tableName;

	private TableFluent(Builder builder) {
		tableType = builder.tableType;
		numberOfSeats = builder.numberOfSeats;
		waiterName = builder.waiterName;
		tableName = builder.tableName;
	}

	public TableType getTableType() {
		return tableType;
	}

	public Integer getNumberOfSeats() {
		return numberOfSeats;
	}

	public String getWaiterName() {
		return waiterName;
	}

	public String getTableName() {
		return tableName;
	}

	public static class Builder {
		private TableType tableType = null;
		private Integer numberOfSeats = null;
		private String waiterName = null;
		private String tableName = "nienazwany";

		public Builder addTableType(TableType tableType) {
			this.tableType = tableType;
			return this;
		}

		public Builder addNumberOfSeats(Integer numberOfSeats) {
			this.numberOfSeats = numberOfSeats;
			return this;
		}

		public Builder addWaiterName(String waiterName) {
			this.waiterName = waiterName;
			return this;
		}

		public Builder addTableName(String tableName) {
			this.tableName = tableName;
			return this;
		}

		public TableFluent build() {
			return new TableFluent(this);
		}
	}
}
