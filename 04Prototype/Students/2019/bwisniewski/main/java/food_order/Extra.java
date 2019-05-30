package food_order;

public class Extra implements Cloneable{
	private String extra;

	public String getExtra() {
		return extra;
	}

	public Extra(String extra) {
		this.extra = extra;
	}

	public void setExtra(String extra) {
		this.extra = extra;
	}
	 @Override
	    public Object clone() throws CloneNotSupportedException{
		 Extra copyExtra = (Extra) super.clone();
	        return copyExtra;
	}
}
