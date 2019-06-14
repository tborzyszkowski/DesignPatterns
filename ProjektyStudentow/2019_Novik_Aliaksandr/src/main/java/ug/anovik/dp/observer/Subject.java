package ug.anovik.dp.observer;

import ug.anovik.dp.MobileDevice;

public interface Subject {

	public void register(Observer obj);

	public void unregister(Observer obj);

	public void notifyObservers();

	public MobileDevice getUpdate(Observer obj);
}
