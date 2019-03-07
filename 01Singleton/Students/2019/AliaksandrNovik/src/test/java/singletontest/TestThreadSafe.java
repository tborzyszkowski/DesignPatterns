package singletontest;

import static org.junit.Assert.assertTrue;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import threadsafe.MyThread;
import threadsafe.MyThreadOneChecked;

public class TestThreadSafe {

	private static List<MyThread> tmpArr;
	private static List<MyThreadOneChecked> tmpArr2;
	
	private static int LOOP = 40;

	@Before
	public void executeBeforeEach() {
		tmpArr = new ArrayList<>();
		tmpArr2 = new ArrayList<>();
		for (int i = 0; i < LOOP; i++) {
			tmpArr.add(new MyThread(i));
			tmpArr2.add(new MyThreadOneChecked(i));
		}
	}

	@Test
	public void sameHashCodes() {

		List<Integer> arr = new ArrayList<>();

		for (int i = 0; i < LOOP; i++) {

			tmpArr.get(i).start();
			try {
				tmpArr.get(i).join();
				arr.add(tmpArr.get(i).getHashCode());
			} catch (InterruptedException e) {
				e.printStackTrace();
			}

		}
		boolean isSame = arr.stream().allMatch(e -> e.equals(arr.get(0)));
		assertTrue(isSame);
	}

	@Test
	public void oneObjectAdded() {

		HashSet<Integer> set = new HashSet<>();

		for (int i = 0; i < LOOP; i++) {

			tmpArr.get(i).start();
			try {
				tmpArr.get(i).join();
				set.add(tmpArr.get(i).getHashCode());
			} catch (InterruptedException e) {
				e.printStackTrace();
			}

		}
		assertTrue(set.size() == 1);
	}
	
	@Test
	public void doubleCheckedTime() {
		List<Integer> arr = new ArrayList<>();

		for (int i = 0; i < LOOP; i++) {

			tmpArr.get(i).start();
			try {
				tmpArr.get(i).join();
				arr.add(tmpArr.get(i).getHashCode());
			} catch (InterruptedException e) {
				e.printStackTrace();
			}

		}
		assertTrue(true);
		
	}
	
	@Test
	public void oneCheckedTime() {
		List<Integer> arr = new ArrayList<>();

		for (int i = 0; i < LOOP; i++) {

			tmpArr2.get(i).start();
			try {
				tmpArr2.get(i).join();
				arr.add(tmpArr2.get(i).getHashCode());
			} catch (InterruptedException e) {
				e.printStackTrace();
			}

		}
		assertTrue(true);
	}
}
