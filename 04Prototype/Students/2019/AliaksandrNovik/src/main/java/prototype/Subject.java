package prototype;

import java.io.Serializable;

public class Subject implements Serializable {
	
	private static final long serialVersionUID = 1L;
	
	private String title;
	
	public Subject(String title) {
		this.title = title;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	@Override
	public String toString() {
		return "Subject [title=" + title + "]";
	}
	
}
