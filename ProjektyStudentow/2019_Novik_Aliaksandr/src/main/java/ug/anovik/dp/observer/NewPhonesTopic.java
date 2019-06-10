package ug.anovik.dp.observer;

import java.util.ArrayList;
import java.util.List;

import ug.anovik.dp.Manager;
import ug.anovik.dp.MobileDevice;
import ug.anovik.dp.facade.MobileDeviceFacade;

public class NewPhonesTopic implements Subject {

	private List<Observer> observers;
	private Manager<String, MobileDevice> manager;

	private MobileDevice device;
	private boolean changed;
	private final Object MUTEX = new Object();

	public NewPhonesTopic() {
		manager = MobileDeviceFacade.getManager();
		this.observers = new ArrayList<>();
	}

	@Override
	public void register(Observer obj) {
		if (obj == null)
			throw new NullPointerException("Null Observer");

		synchronized (MUTEX) {
			if (!observers.contains(obj))
				observers.add(obj);
		}
	}

	@Override
	public void unregister(Observer obj) {
		synchronized (MUTEX) {
			observers.remove(obj);
		}
	}

	@Override
	public void notifyObservers() {
		List<Observer> observersLocal = null;
		synchronized (MUTEX) {
			if (!changed)
				return;
			observersLocal = new ArrayList<>(this.observers);
			this.changed = false;
		}
		for (Observer obj : observersLocal) {
			obj.update();
		}
	}

	@Override
	public MobileDevice getUpdate(Observer obj) {
		return this.device;
	}

	public void postNewDevice(String model, MobileDevice device) {
		System.out.println("New " + device.getClass().getSimpleName() + " posted to topic:" + device);
		this.manager.addDevice(model, device);
		this.device = device;
		this.changed = true;
		notifyObservers();
	}

}
