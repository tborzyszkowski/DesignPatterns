package prototype;

public abstract class SchedulePrototype {
	public abstract SchedulePrototype shallowCopy() throws CloneNotSupportedException;
	public abstract SchedulePrototype deepCopy() throws CloneNotSupportedException;

}
