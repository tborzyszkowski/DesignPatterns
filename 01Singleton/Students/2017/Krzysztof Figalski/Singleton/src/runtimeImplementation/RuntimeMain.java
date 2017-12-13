package runtimeImplementation;

public class RuntimeMain {

	public static void main(String[] args) {

		for (int i = 0; i < 100000; i++) {
			RuntimeImplThreads thread = new RuntimeImplThreads("W¹tek-nr-" + i);
			thread.start();
		}
		System.out.println("instanceCounter=1 dla wszystkich w¹tków");

	}

}
