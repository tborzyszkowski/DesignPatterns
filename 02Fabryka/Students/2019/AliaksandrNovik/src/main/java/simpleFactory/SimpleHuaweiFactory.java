package simpleFactory;

import phoneTypes.PhoneType;
import smartphones.Smartphone;
import smartphones.huawei.HuaweiBudgetary;
import smartphones.huawei.HuaweiFold;
import smartphones.huawei.HuaweiGaming;

public class SimpleHuaweiFactory{
    private static SimpleHuaweiFactory INSTANCE;
    
    public SimpleHuaweiFactory getInstance(){
        if(INSTANCE == null){
            INSTANCE = new SimpleHuaweiFactory();
        }
        return INSTANCE;
    }
    
    public Smartphone buildSmartphone(PhoneType type){
        if(type.equals(PhoneType.GAMING)){
            return new HuaweiGaming();
        }else if(type.equals(PhoneType.BUDGETARY)){
            return new HuaweiBudgetary();
        }else if(type.equals(PhoneType.FOLD)){
            return new HuaweiFold();
        }else{
            return null;
        }
    }
}