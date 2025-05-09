﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02ConcurrentBagImplementation {
	class MainApp {
		static void Main(string[] args) {
			CancellationTokenSource cts = new CancellationTokenSource();

			Task.Run(() =>
			{
				if (Console.ReadKey().KeyChar == 'c' || Console.ReadKey().KeyChar == 'C')
					cts.Cancel();
			});

			ObjectPool<MyClass> pool = new ObjectPool<MyClass>(() => new MyClass());

			Parallel.For(0, 500 * 1000, (i, loopState) =>
			{
				Console.WriteLine($"i = {i}\t count = {pool.GetCount()}");

				MyClass mc = pool.GetObject();

				//Console.CursorLeft = 0;
				// This is the bottleneck in our application. All threads in this loop
				// must serialize their access to the static Console class.
				// Console.WriteLine("i = {0}\t Val = {1:####.####}\t", i, mc.GetValue(i%10));

				pool.PutObject(mc);
				if (cts.Token.IsCancellationRequested)
					loopState.Stop();

			});
			Console.WriteLine($"\nCount = {pool.GetCount()}");
			Console.WriteLine("Press the Enter key to exit.");
			Console.ReadLine();
			cts.Dispose();
		}
	}
}
