#include "stdafx.h"
#include "CppUnitTest.h"
#include "../Singleton/SimpleSingleton.h"
#include "../Singleton/SafeSingletonCPP11.h"
#include "../Singleton/SafeSingletonBeforeCPP11.h"
#include "../Singleton/SlowButSafeSingleton.h"
#include "../Singleton/VerySlowUnsafeSingleton.h"
#include "../Singleton/InheritableSingleton.h"

#include <thread>
#include <vector>
#include <mutex>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

#define ACCESS_NUMBER 10000

namespace Testing
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(TestSimpleSingleton)
		{
			long address = (long) SimpleSingleton::GetInstance();

			for (int i = 0; i < ACCESS_NUMBER; i++)
				Assert::AreEqual(address, (long) SimpleSingleton::GetInstance());
		}

		TEST_METHOD(TestSafeSingletonBeforeCPP11)
		{
			long address = (long) SafeSingletonBeforeCPP11::GetInstance();

			for (int i = 0; i < ACCESS_NUMBER; i++)
				Assert::AreEqual(address, (long) SafeSingletonBeforeCPP11::GetInstance());
		}

		TEST_METHOD(TestSafeSingletonCPP11)
		{
			long address = (long) &SafeSingletonCPP11::GetInstance();

			for (int i = 0; i < ACCESS_NUMBER; i++)
				Assert::AreEqual(address, (long) &SafeSingletonCPP11::GetInstance());
		}

		TEST_METHOD(TestSafeButSlowSingleton)
		{
			long address = (long) SafeButSlowSingleton::GetInstance();

			for (int i = 0; i < ACCESS_NUMBER; i++)
				Assert::AreEqual(address, (long) SafeButSlowSingleton::GetInstance());
		}

		TEST_METHOD(TestDerivedSingleton)
		{
			long address = (long) &DerivedSingleton::GetInstance();

			for (int i = 0; i < ACCESS_NUMBER; i++)
				Assert::AreEqual(address, (long) &DerivedSingleton::GetInstance());
		}

		TEST_METHOD(TestThreadedSingletonValid)
		{
			std::vector<std::thread> threads;
			const unsigned char thread_count = ACCESS_NUMBER;

			// Final results to compare
			long results[thread_count];

			// Method to run in paralell
			auto method = [=](long* res, unsigned char i) {
				res[i] = (long) SafeSingletonBeforeCPP11::GetInstance();
			};

			// Start threads
			for (int i = 0; i < thread_count; i++)
				threads.push_back(std::thread(method, results, i));

			// Wait for threads to finish their job
			for (int i = 0; i < thread_count; i++)
				threads[i].join();

			// Check if atleast first thread returned valid address
			Assert::AreNotEqual((long)0, results[0]);

			// Compare if all threads returned the same valid address (valid implementation)
			for (int i = 1; i < thread_count; i++)
				Assert::AreEqual(results[0], results[i]);
		}

		TEST_METHOD(TestThreadedSingletonInvalid)
		{
			std::vector<std::thread> threads;
			const unsigned char thread_count = ACCESS_NUMBER;

			// Final results to compare
			long results[thread_count];

			// Method to run in paralell
			auto method = [=](long* res, unsigned char i) {
				res[i] = (long)VerySlowUnsafeSingleton::GetInstance();
			};

			// Start threads
			for (int i = 0; i < thread_count; i++)
				threads.push_back(std::thread(method, results, i));

			// Wait for threads to finish their job
			for (int i = 0; i < thread_count; i++)
				threads[i].join();

			// Check if atleast first thread returned valid address
			Assert::AreNotEqual((long)0, results[0]);

			// Check if there were multiple instances created (invalid implementation)
			bool all_addresses_are_same = true;
			for (int i = 1; i < thread_count; i++)
			{
				if (results[0] != results[i])
				{
					all_addresses_are_same = false;
					break;
				}
			}

			Assert::AreEqual(false, all_addresses_are_same);
		}
	};
}
