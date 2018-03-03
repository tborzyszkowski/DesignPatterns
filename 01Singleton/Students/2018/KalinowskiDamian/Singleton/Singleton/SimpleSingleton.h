#pragma once

#include <iostream>

class SimpleSingleton
{
private:
	static SimpleSingleton* m_instance;
	SimpleSingleton() {}
	~SimpleSingleton() {}

public:
	static SimpleSingleton* GetInstance()
	{
		// Not thread-safe
		if (m_instance == nullptr)
			m_instance = new SimpleSingleton;

		return m_instance;
	}

	void Log(const char *message)
	{
		printf("Log from [SimpleSingleton] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

SimpleSingleton* SimpleSingleton::m_instance = nullptr;
