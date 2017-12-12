package objectPool;

public class TestObjectPool {
	public static void main(String[] args) {
		
        ObjectPool op = ObjectPool.getInstance();
                
        for(int i=1; i < ObjectPool.POOL_SIZE+2; i++) {
            PooledObject object = op.getPooledObject();
            if(object == null) {
                System.out.println("Nie ma już objektów w puli" );                
                break;
            }
            System.out.println(i + " objekt: " + object.hashCode() );
        }        
        
        System.out.println("Zwalniamy wszystkie zasoby"); 
        op.releaseAllPooledObjects();
              
        PooledObject o1 = op.getPooledObject();
        System.out.println("1 obiekt: " + o1.hashCode());
        
        PooledObject o2 = op.getPooledObject();
        System.out.println("2 obiekt: " + o2.hashCode());
        
        PooledObject o3 = op.getPooledObject();
        System.out.println("3 obiekt: " + o3.hashCode());   
        
        System.out.println("Zwalniamy zasób 2"); 
        op.releasePooledObject(o2);
        PooledObject o4 = op.getPooledObject();
        System.out.println("Wolny obiekt: " + o4.hashCode()); 
        
        op.releaseAllPooledObjects();
    }
}
