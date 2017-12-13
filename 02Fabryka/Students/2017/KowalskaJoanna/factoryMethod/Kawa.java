package factoryMethod;

public abstract class Kawa {	
	String nazwa;
	String mielenie;
	String mleko;
			
	public void przygotuj() {
		System.out.println("Przygotowanie kawy: " + nazwa);	
	}
		
	public String toString() {
		StringBuffer sb = new StringBuffer();
		sb.append(mielenie + "\n");
		if (mleko != null) {
			sb.append(mleko + "\n");
		}
		return sb.toString();
	}
}
