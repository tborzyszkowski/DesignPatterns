package builder.buildervsfactory.databaseconnection.factory;

import builder.buildervsfactory.databaseconnection.common.ConnectionBase;

public class LocalConnection extends ConnectionBase {

	public LocalConnection() {
		this.url = "localhost";
		this.userName = "local";
		this.password = "local";
		this.port = 8989;
	}

}
