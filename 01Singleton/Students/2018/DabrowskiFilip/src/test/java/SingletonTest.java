import org.junit.Assert;
import org.junit.Test;

import java.util.Collections;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class SingletonTest {

    @Test
    public void check_if_singleton_was_created_once_it_created() {
        Singleton firstTestSingleton = Singleton.getInstance();
        Singleton secondTestSingleton = Singleton.getInstance();

        Assert.assertEquals("Check if hashcode are the same", firstTestSingleton.hashCode(), secondTestSingleton.hashCode());
    }

    @Test
    public void check_if_multitreading_problem_appears() throws InterruptedException {

        int threadsAmount = 500;
        Set<Singleton> singletonSet = Collections.newSetFromMap(new ConcurrentHashMap<>());

        ExecutorService executorService = Executors.newFixedThreadPool(threadsAmount);

        for (int i = 0; i < threadsAmount; i++) {
            executorService.execute(() -> {
                Singleton singleton = Singleton.getInstance();
                singletonSet.add(singleton);
            });
        }

        executorService.shutdown();
        executorService.awaitTermination(1, TimeUnit.MINUTES);

        System.out.println(singletonSet);
    }

}
