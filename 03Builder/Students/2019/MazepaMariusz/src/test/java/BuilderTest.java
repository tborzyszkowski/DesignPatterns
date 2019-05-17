import static org.junit.Assert.*;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.hamcrest.CoreMatchers.*;;

import manager_package.BuilderManager;
import builder_package.*;
import factory_package.*;

public class BuilderTest {
  static BuilderManager bm = new BuilderManager();

  @BeforeClass
  public static void setUpClass() {
    bm.mainHeader();
    System.out.println("Rozpoczęcie testowania...");
    System.out.println("───────────────────────────────────────────────────────");
  }

  @AfterClass
  public static void tearDownClass() {
    // System.out.println("───────────────────────────────────────────────────────");
    System.out.println("Testowanie zakończone.\n");
  }

  @Before
  public void setUp() {
    // System.out.println("───────────────────────────────────────────────────────");
  }

  @After
  public void tearDown() {
    System.out.println("───────────────────────────────────────────────────────");
  }

  @Test
  public void simpleBuilderTest() {
    bm.testHeader("Simple Builder Test");
    bm.setIsTimeTest(false);

    Shop shop = new Shop();

    builder_package.SpeakerSet small = shop.construct(new SmallSetBuilder());
    small.show();

    builder_package.SpeakerSet medium = shop.construct(new MediumSetBuilder());
    medium.show();

    builder_package.SpeakerSet large = shop.construct(new LargeSetBuilder());
    large.show();

    assertThat(small, instanceOf(builder_package.SpeakerSet.class));
    assertThat(medium, instanceOf(builder_package.SpeakerSet.class));
    assertThat(large, instanceOf(builder_package.SpeakerSet.class));
  }

  @Test
  public void simpleFactoryTest() {
    bm.testHeader("Simple Factory Test");
    bm.setIsTimeTest(false);

    SpeakerSetFactory factory = new SpeakerSetFactory();

    factory_package.SpeakerSet small = factory.getSpeakerSet(new SmallSetFactory("Głośniki 2.0", "2", "14W", "2", "biały"));
    System.out.println(small);

    factory_package.SpeakerSet medium = factory.getSpeakerSet(new MediumSetFactory("Głośniki 2.1", "3", "60W", "3", "srebrny"));
    System.out.println(medium);

    factory_package.SpeakerSet large = factory.getSpeakerSet(new LargeSetFactory("Głośniki 5.1", "6", "120W", "7", "czarny"));
    System.out.println(large);

    assertThat(small, instanceOf(SmallSpeakerSet.class));
    assertThat(medium, instanceOf(MediumSpeakerSet.class));
    assertThat(large, instanceOf(LargeSpeakerSet.class));
  }

  @Test
  public void builderVsAbstractFactoryTimeTest() {
    bm.testHeader("Builder vs. Abstract Factory Time Test");
    bm.setIsTimeTest(true);

    long startTime, endTime, timeElapsed;
    int limit = 1000000;

    Long[] results = new Long[2];

    // ----- BUILDER TIME TEST -------------------------------------------------
    Shop shop = new Shop();

    startTime = System.currentTimeMillis();
    for (int i = 0; i < limit; i++) {
      shop.construct(new SmallSetBuilder());
    }
    endTime = System.currentTimeMillis();
    timeElapsed = endTime - startTime;
    results[0] = timeElapsed;

    // ----- FACTORY TIME TEST -------------------------------------------------
    SpeakerSetFactory factory = new SpeakerSetFactory();

    startTime = System.currentTimeMillis();
    for (int i = 0; i < limit; i++) {
      factory.getSpeakerSet(new SmallSetFactory("Głośniki 2.0", "2", "14W", "2", "biały"));
    }
    endTime = System.currentTimeMillis();
    timeElapsed = endTime - startTime;
    results[1] = timeElapsed;

    bm.printResults(results);
  }
}
