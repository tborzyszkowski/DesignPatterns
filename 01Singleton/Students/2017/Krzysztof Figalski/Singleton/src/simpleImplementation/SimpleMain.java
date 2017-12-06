package simpleImplementation;

public class SimpleMain {

	public static void main(String[] args) {

		for (int i = 0; i < 100000; i++) {
			SimpleImplThreads thread = new SimpleImplThreads("W¹tek-nr-" + i);
			thread.start();
		}
		System.out.println("instanceCounter=1 dla wszystkich w¹tków");

	}

}
