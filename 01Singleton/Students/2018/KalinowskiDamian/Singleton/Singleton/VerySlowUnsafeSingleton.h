#pragma once

#include <iostream>
#include <Windows.h>

class VerySlowUnsafeSingleton
{
private:
	static VerySlowUnsafeSingleton* m_instance;
	VerySlowUnsafeSingleton() {}
	~VerySlowUnsafeSingleton() {}

public:
	static VerySlowUnsafeSingleton* GetInstance()
	{
		// Not thread-safe
		if (m_instance == nullptr)
		{
			// Wait for other threads to create their own instances
			Sleep(100);
			m_instance = new VerySlowUnsafeSingleton;
		}

		return m_instance;
	}

	void Log(const char *message)
	{
		printf("Log from [VerySlowUnsafeSingleton] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

VerySlowUnsafeSingleton* VerySlowUnsafeSingleton::m_instance = nullptr;
