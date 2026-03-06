package factoryClassRegistrationReflection;

class Main {
	static {
		try {
			Class.forName("OneProduct");
			Class.forName("AnotherProduct");
		} catch (ClassNotFoundException any) {
			any.printStackTrace();
		}
	}

	public static void main(String args[]) {
		// TODO: wykorzystanie fabryki
	}
}
