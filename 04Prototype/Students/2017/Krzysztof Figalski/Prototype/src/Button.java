
public abstract class Button implements Cloneable {

	protected String description;
	protected String colour;
	protected int numberOfButtonholes;

	abstract void produce();

	public Object clone() {
		Object clone = null;

		try {
			clone = super.clone();

		} catch (CloneNotSupportedException e) {
			e.printStackTrace();
		}

		return clone;
	}

	public String getColour() {
		return colour;
	}

	public void setColour(String colour) {
		this.colour = colour;
	}

	public int getNumberOfNuttonholes() {
		return numberOfButtonholes;
	}

	public void setNumberOfNuttonholes(int numberOfNuttonholes) {
		this.numberOfButtonholes = numberOfNuttonholes;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

}
