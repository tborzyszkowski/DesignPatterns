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
    
	public PooledObject getPooledObject() {
		Lock criticalSection = new Lock();
        for (PooledObject pooledObject : availableObjects) {
            if (!pooledObject.isUsed()) {
            	pooledObject.setUsed(true);
            	criticalSection.release();
                return pooledObject;
            }
        }

        if (availableObjects.size() >= getMaxPoolSize()) {
        	criticalSection.release();
            return null;
        }
        
        PooledObject pooledObject = new PooledObject();
        pooledObject.setUsed(true);
        availableObjects.add(pooledObject);    
        criticalSection.release();
        return pooledObject;
    }

	public void releasePooledObject(PooledObject object) {
		Lock criticalSection = new Lock();
        int index = availableObjects.indexOf(object);
        if (index == -1) {
        	criticalSection.release();
            return;
        }
        PooledObject poledObject = availableObjects.get(index);
        poledObject.setUsed(false);
        criticalSection.release();
    }
	
	public void releaseAllPooledObjects() {
		Lock criticalSection = new Lock();
    	for(int i=0; i < ObjectPool.POOL_SIZE; i++) {
    		PooledObject poledObject = availableObjects.get(i);
    		poledObject.setUsed(false);
    		criticalSection.release();
        }   
    }
	
	public static ObjectPool getInstance() {    
		Lock criticalSection = new Lock();  
        if (instance == null) {
            instance = new ObjectPool();
        }    
        criticalSection.release();
        return instance;
    }
}
