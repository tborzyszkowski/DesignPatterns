package objectPool;

public class PooledObject {
	
	private boolean used = false;

    public boolean isUsed() {
        return used;
    }

    public void setUsed(boolean used) {
        this.used = used;
    }
}
