package builder.buildervsfactory.databaseconnection.factory;

import builder.buildervsfactory.databaseconnection.common.ConnectionBase;

public class DevelopmentConnection extends ConnectionBase {

	public DevelopmentConnection() {
		this.url = "urltodevelopment.com";
		this.userName = "development";
		this.password = "development";
		this.port = 8080;
	}
}
