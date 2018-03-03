#pragma once

template <typename T>
class InheritableSingleton
{
protected:
	InheritableSingleton() {}
	~InheritableSingleton() {}

public:
	static T& GetInstance()
	{
		static T instance;
		return instance;
	}

	virtual void Log(const char *message)
	{
		printf("Log from [InheritableSingleton] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

class DerivedSingleton : public InheritableSingleton<DerivedSingleton>
{
public: 
	void Log(const char* message) override
	{
		printf("Log from [DerivedSingleton] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

class YetAnotherDerivedSingleton : public InheritableSingleton<YetAnotherDerivedSingleton>
{
public:
	void Log(const char* message) override
	{
		printf("Log from [YetAnotherDerivedSingleton] instance pointing to address [0x%x]: %s\n", this, message);
	}
};

