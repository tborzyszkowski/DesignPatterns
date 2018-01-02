package builder.buildervsfactory.databaseconnection.factory;

import builder.buildervsfactory.databaseconnection.common.ConnectionBase;

public class ProductionConnection extends ConnectionBase{

	public ProductionConnection() {
		this.url = "production.com";
		this.userName = "production";
		this.password = "production";
		this.port = 8080;
	}
}
