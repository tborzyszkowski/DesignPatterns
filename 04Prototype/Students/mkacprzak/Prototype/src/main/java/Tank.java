import java.io.*;

public class Tank implements Cloneable, Serializable{


    private Gun gun;
    private Engine engine;
    private int turret;

    @Override
    protected Object clone() throws CloneNotSupportedException {
        Object clone = null;

        try {
            clone = super.clone();

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }

        return clone;
    }

    public Tank gun(Gun gun)
    {
        this.gun=gun;
        return this;
    }

    public Tank engine(Engine engine)
    {
        this.engine=engine;
        return this;
    }
    public Tank turret(int turret)
    {

        this.turret=turret;
        return this;
    }

    @Override
    public String toString() {
        return "Tank{" +
                "gun=" + gun +
                ", engine=" + engine +
                ", turret=" + turret +
                '}';
    }


    public Gun getGun() {
        return gun;
    }

    public void setGun(Gun gun) {
        this.gun = gun;
    }

    public Engine getEngine() {
        return engine;
    }

    public void setEngine(Engine engine) {
        this.engine = engine;
    }

    public int getTurret() {
        return turret;
    }

    public void setTurret(int turret) {
        this.turret = turret;
    }

    public Tank shallowCopy() {
    Tank tank=null;
        try {
            return (Tank)clone();
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return tank;
    }

    public Tank deepCopy() {

        try {
            ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
            ObjectOutputStream objectOutputStream = new ObjectOutputStream(byteArrayOutputStream);
            objectOutputStream.writeObject(this);
            ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(byteArrayOutputStream.toByteArray());
            ObjectInputStream ois = new ObjectInputStream(byteArrayInputStream);
            return (Tank)ois.readObject();
        }
        catch (Exception e) {
            e.printStackTrace();
            return null;
        }

    }
}
