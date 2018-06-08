#pragma once

#include <functional>
#include <list>

template <typename T>
class observable
{
  std::list<std::function<void(const T&)>> m_observers;

public:
  void attach(const std::function<void(const T&)>&);
  void notify();
};

template<typename T>
void observable<T>::attach(const std::function<void(const T&)>& observer)
{
  m_observers.push_back(observer);
}

template<typename T>
void observable<T>::notify()
{
  for (auto& observer : m_observers)
    observer((const T&)*this);
}
