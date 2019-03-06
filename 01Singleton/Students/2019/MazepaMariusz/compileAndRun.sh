javac Singleton.java
javac Helper.java
javac ThreadTest.java
javac SingletonTest.java
javac SingletonTest2.java
javac SingletonTest3.java

echo "---[Test1]: SINGLETON TEST ---------------"
java SingletonTest
echo "---[Test2]: THREAD SAFE TEST -------------"
java SingletonTest2
echo "---[Test3]: SERIALIZATION TEST -----------"
java SingletonTest3
