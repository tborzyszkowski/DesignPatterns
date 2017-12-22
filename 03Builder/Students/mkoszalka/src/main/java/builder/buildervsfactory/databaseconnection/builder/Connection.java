package builder.buildervsfactory.databaseconnection.builder;

import builder.buildervsfactory.databaseconnection.common.ConnectionBase;

public class Connection extends ConnectionBase {

	private Connection(ConnectionBuilder connectionBuilder) {
		url = connectionBuilder.url;
		userName = connectionBuilder.userName;
		password = connectionBuilder.password;
		port = connectionBuilder.port;
	}

	public class ConnectionBuilder {

		private String url;

		private String userName;

		private String password;

		private Integer port;

		public ConnectionBuilder withUrl(String url) {
			this.url = url;
			return this;
		}

		public ConnectionBuilder withUserName(String userName) {
			this.userName = userName;
			return this;
		}

		public ConnectionBuilder withPassword(String password) {
			this.password = password;
			return this;
		}

		public ConnectionBuilder withPort(Integer port) {
			this.port = port;
			return this;
		}

		public Connection build() {
			return new Connection(this);
		}

	}

}
