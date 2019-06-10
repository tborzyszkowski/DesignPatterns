package ug.anovik.dp.observer;

import ug.anovik.dp.MobileDevice;

public class NewPhoneObserver implements Observer {

	private String name;
	private Subject topic;

	public NewPhoneObserver(String nm) {
		this.name = nm;
	}

	@Override
	public void update() {
		MobileDevice device = topic.getUpdate(this);
		if (device == null) {
			System.out.println(name + ": there are no new devices");
		} else
			System.out.println(name + " was briefed about new "+ device.getClass().getSimpleName() + ". " + device);
	}

	@Override
	public void setSubject(Subject sub) {
		this.topic = sub;
	}
}
