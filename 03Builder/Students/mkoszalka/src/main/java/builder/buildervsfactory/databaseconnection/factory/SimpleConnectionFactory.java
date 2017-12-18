package builder.buildervsfactory.databaseconnection.factory;

import builder.buildervsfactory.databaseconnection.common.ConnectionBase;
import builder.buildervsfactory.databaseconnection.enums.EnvironmentType;

public class SimpleConnectionFactory {

	public ConnectionBase getConnection(EnvironmentType environmentType) {
		switch (environmentType) {
		case LOCAL:
			return new LocalConnection();
		case PRODUCTION:
			return new ProductionConnection();
		case DEVELOPMENT:
			return new DevelopmentConnection();
		default:
			throw new IllegalArgumentException("incorrect environment type!");
		}
	}

}
