package prototype;


public abstract class StudentPrototype {
	public abstract StudentPrototype shallowCopy() throws CloneNotSupportedException;
	public abstract StudentPrototype deepCopy() throws CloneNotSupportedException;
}
