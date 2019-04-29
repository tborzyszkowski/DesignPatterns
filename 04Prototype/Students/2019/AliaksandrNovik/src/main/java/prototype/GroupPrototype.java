package prototype;

public abstract class GroupPrototype {
	public abstract GroupPrototype shallowCopy() throws CloneNotSupportedException;
	public abstract GroupPrototype deepCopy() throws CloneNotSupportedException;
}
