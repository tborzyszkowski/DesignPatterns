import java.io.Serializable;
import java.io.FileNotFoundException;
import java.io.IOException;

class Singleton implements Serializable {
  private static Singleton instance;

	private Singleton() {
    	System.out.println("Singleton():   Inicjalizowanie instacji.");
	}

	public static Singleton getInstance() {
		if (instance == null) {
			synchronized(Singleton.class) {
				if (instance == null) {
					System.out.println("getInstance(): Pierwsze wywołanie.");
					instance = new Singleton();
				}
			}
		}
		return instance;
	}

  protected Object readResolve() throws FileNotFoundException, IOException, ClassNotFoundException {
    System.out.println("\nthis_hsc:      " + this + ", " + this.hashCode());
    if (instance == null) {
      System.out.println("instance:      " + null + "\n");
      System.out.println("readResolve(): Instancja nie istnieje, biorę z pliku.");
      instance = this;
    } else {
      System.out.println("instance:      " + instance + ", " + instance.hashCode() + "\n");
      System.out.println("readResolve(): Instancja istnieje, podmieniam na istniejącą.");
    }
    return instance;
  }
}
