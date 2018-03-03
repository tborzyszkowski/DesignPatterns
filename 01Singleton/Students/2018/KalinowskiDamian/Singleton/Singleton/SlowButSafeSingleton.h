#pragma once

#include <mutex>

class SafeButSlowSingleton
{
private:
	static SafeButSlowSingleton* m_instance;
	static std::mutex m_mutex;
	SafeButSlowSingleton() {}
	~SafeButSlowSingleton() {}

public:
	static SafeButSlowSingleton* GetInstance()
	{
		// Slow because each access to ::GetInstance() locks the mutex, which is heavy
		m_mutex.lock();
		if (m_instance == nullptr)
			m_instance = new SafeButSlowSingleton;
		m_mutex.unlock();
		return m_instance;
	}

	void Log(const char *message)
	{
		printf("Log from [SafeButSlowSingleton] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

SafeButSlowSingleton* SafeButSlowSingleton::m_instance = nullptr;
std::mutex SafeButSlowSingleton::m_mutex;
