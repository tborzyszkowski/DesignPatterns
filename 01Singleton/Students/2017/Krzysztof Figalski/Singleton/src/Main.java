import runtimeImplementation.RuntimeImplThreads;
import simpleImplementation.SimpleImplThreads;

public class Main {

	public static void main(String[] args) {

		int numberofThreads = 500000;

		long startTime = System.currentTimeMillis();

		for (int i = 0; i < numberofThreads; i++) {
			SimpleImplThreads thread = new SimpleImplThreads("W¹tek-nr-" + i);
			thread.start();
		}

		long stopTime = System.currentTimeMillis();
		long elapsedTime = stopTime - startTime;
		System.out.println("Czas w przypadku lazy initialization:"+ elapsedTime);

		/*********************************************************/
		startTime = System.currentTimeMillis();
		for (int i = 0; i < numberofThreads; i++) {
			RuntimeImplThreads thread = new RuntimeImplThreads("W¹tek-nr-" + i);
			thread.start();
		}
		stopTime = System.currentTimeMillis();
		elapsedTime = stopTime - startTime;
		System.out.println("Czas w przypadku runtime initialization:"+elapsedTime);
	}

}
