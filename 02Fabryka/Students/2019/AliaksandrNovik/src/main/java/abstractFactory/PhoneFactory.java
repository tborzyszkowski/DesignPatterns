package abstractFactory;

public abstract class PhoneFactory {
	
	abstract public ITestService getTestService();

	abstract public IBoxService getBoxService();

}
