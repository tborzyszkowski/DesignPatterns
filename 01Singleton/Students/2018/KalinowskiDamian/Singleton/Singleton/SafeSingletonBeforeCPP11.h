#pragma once

#include <mutex>

class SafeSingletonBeforeCPP11
{
private:
	static SafeSingletonBeforeCPP11* m_instance;
	static std::mutex m_mutex;
	SafeSingletonBeforeCPP11() {}
	~SafeSingletonBeforeCPP11() {}

public:
	static SafeSingletonBeforeCPP11* GetInstance()
	{
		// DCLP - Double-Checked Locking Pattern
		// Might this be the first call to ::GetInstance()?
		if (m_instance == nullptr)
		{
			m_mutex.lock();
			// Are you sure its the first call to ::GetInstance()?
			if (m_instance == nullptr)
				m_instance = new SafeSingletonBeforeCPP11;
			m_mutex.unlock();
		}
		return m_instance;
	}

	void Log(const char *message)
	{
		printf("Log from [SafeSingletonBeforeCPP11] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

SafeSingletonBeforeCPP11* SafeSingletonBeforeCPP11::m_instance = nullptr;
std::mutex SafeSingletonBeforeCPP11::m_mutex;
