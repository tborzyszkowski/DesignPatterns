#pragma once

#include <iostream>

class SafeSingletonCPP11
{
private:
	SafeSingletonCPP11() {}
	~SafeSingletonCPP11() {}

public:
	static SafeSingletonCPP11& GetInstance()
	{
		/*
			The C++11 standard�s got our back in �6.7.4:
			If control enters the declaration concurrently while the variable is being initialized, 
			the concurrent execution shall wait for completion of the initialization.
		*/
		static SafeSingletonCPP11 instance;
		return instance;
	}

	void Log(const char *message)
	{
		printf("Log from [SafeSingletonCPP11] instance pointing to address [0x%x]: %s\n", this, message);
	}
};
