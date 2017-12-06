package objectPool;

import java.util.ArrayList;

public class ObjectPool {
	
	public static final int POOL_SIZE = 3;
	private int maxPoolSize = POOL_SIZE;
	
	private ArrayList<PooledObject> availableObjects;
	protected static ObjectPool instance = null; 
	
	protected ObjectPool() {
		availableObjects = new ArrayList<PooledObject>();
    }
	
	public int getMaxPoolSize() {
        return maxPoolSize;
    }

    public void setMaxPoolSize(int maxPoolSize) {
        this.maxPoolSize = maxPoolSize;
    }
    
    public PooledObject getPooledObject() {
        for (PooledObject pooledObject : availableObjects) {
            if (!pooledObject.isUsed()) {
            	pooledObject.setUsed(true);
                return pooledObject;
            }
        }

        if (availableObjects.size() >= getMaxPoolSize()) {
            return null;
        }
        
        PooledObject pooledObject = new PooledObject();
        pooledObject.setUsed(true);
        availableObjects.add(pooledObject);        
        return pooledObject;
    }
    
    public void releasePooledObject(PooledObject object) {
        int index = availableObjects.indexOf(object);
        if (index == -1) {
            return;
        }
        PooledObject poledObject = availableObjects.get(index);
        poledObject.setUsed(false);
    }
    
    public void releaseAllPooledObjects() {
    	for(int i=0; i < ObjectPool.POOL_SIZE; i++) {
    		PooledObject poledObject = availableObjects.get(i);
    		poledObject.setUsed(false);
        }   
    }
    
    public static ObjectPool getInstance() {       
        if (instance == null) {
            instance = new ObjectPool();
        }    
        return instance;
    }
}
