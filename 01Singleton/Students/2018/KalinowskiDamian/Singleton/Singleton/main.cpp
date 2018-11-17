#include "SimpleSingleton.h"
#include "SafeSingletonCPP11.h"
#include "SafeSingletonBeforeCPP11.h"
#include "InheritableSingleton.h"

#include <thread>
#include <vector>

int main()
{
	// SimpleSingleton
	SimpleSingleton::GetInstance()->Log("Hello World1");
	SimpleSingleton::GetInstance()->Log("Hello World2");
	SimpleSingleton::GetInstance()->Log("Hello World3");
	SimpleSingleton::GetInstance()->Log("Hello World4");

	// Cannot create
	//SimpleSingleton singleton;
	//SimpleSingleton* singleton = new SimpleSingleton;

	// Cannot delete
	//delete SimpleSingleton::GetInstance();
	

	// SafeSingletonCPP11
	SafeSingletonCPP11::GetInstance().Log("Hello World1");
	SafeSingletonCPP11::GetInstance().Log("Hello World2");
	SafeSingletonCPP11::GetInstance().Log("Hello World3");
	SafeSingletonCPP11::GetInstance().Log("Hello World4");

	// SafeSingletonBeforeCPP11
	SafeSingletonBeforeCPP11::GetInstance()->Log("Hello World1");
	SafeSingletonBeforeCPP11::GetInstance()->Log("Hello World2");
	SafeSingletonBeforeCPP11::GetInstance()->Log("Hello World3");
	SafeSingletonBeforeCPP11::GetInstance()->Log("Hello World4");

	// Unsafe example
	std::vector<std::thread> threads;
	const unsigned char thread_count = 30;

	for (int i = 0; i < thread_count; i++)
		threads.push_back(std::thread([=]() { SimpleSingleton::GetInstance()->Log("Example"); }));

	for (int i = 0; i < thread_count; i++)
		threads[i].join();

	// InheritableSingleton
	//InheritableSingleton<DerivedSingleton>::GetInstance().Log("Test"); // Impossible!
	
	// Usage: Method 1:
	InheritableSingleton<DerivedSingleton>::GetInstance().Log("Test1");
	InheritableSingleton<DerivedSingleton>::GetInstance().Log("Test2");
	InheritableSingleton<YetAnotherDerivedSingleton>::GetInstance().Log("Test1");
	InheritableSingleton<YetAnotherDerivedSingleton>::GetInstance().Log("Test2");

	// Usage: Method 2:
	DerivedSingleton::GetInstance().Log("Hello World 1");
	DerivedSingleton::GetInstance().Log("Hello World 2");
	YetAnotherDerivedSingleton::GetInstance().Log("Hello World 1");
	YetAnotherDerivedSingleton::GetInstance().Log("Hello World 2");

	std::cin.get();
	return 0;
}
