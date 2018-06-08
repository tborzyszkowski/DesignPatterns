#pragma once

#include <queue>
#include <cstdint>

template<typename T, unsigned int N>
class object_pool
{
public:
  template<typename U>
  class pooled_ptr
  {
    T* m_ptr;
    object_pool<T,N>* m_pool;
  public:
    pooled_ptr(const pooled_ptr<T>& e) = delete;
    pooled_ptr(pooled_ptr<T>&& e)
    {
      m_ptr = e.m_ptr;
      m_pool = e.m_pool;
      e.m_ptr = nullptr;
    }
    pooled_ptr(object_pool<T,N>* pool, T* ptr) : m_pool(pool), m_ptr(ptr) {}
    ~pooled_ptr()
    {
      m_pool->release(m_ptr);
    }

    T* get() const { return m_ptr; }

    std::intptr_t hash() const { return (std::intptr_t) m_ptr; }

    T* operator->() const { return m_ptr; }
  };

private:
  std::queue<T*> m_available;

protected:
  object_pool() {
    for (unsigned int i = 0; i < N; i++)
      m_available.push(new T);
  }
  ~object_pool() {
    while (!m_available.empty()) {
      delete m_available.front();
      m_available.pop();
    }
  }

public:
  static object_pool<T,N>& instance();

  pooled_ptr<T> acquire();
  static pooled_ptr<T> acquire_ex();

  void release(T* ptr);
};

template<typename T, unsigned int N>
object_pool<T,N>& object_pool<T,N>::instance()
{
  static object_pool<T,N> instance;
  return instance;
}

template<typename T, unsigned int N>
object_pool<T,N>::pooled_ptr<T> object_pool<T,N>::acquire()
{
  if (m_available.empty())
    return object_pool<T,N>::pooled_ptr<T>(this, nullptr);

  auto o = m_available.front();
  m_available.pop();
  
  return object_pool<T,N>::pooled_ptr<T>(this, o);
}

template<typename T, unsigned int N>
object_pool<T,N>::pooled_ptr<T> object_pool<T,N>::acquire_ex()
{
  return instance().acquire();
}

template<typename T, unsigned int N>
void object_pool<T,N>::release(T* ptr)
{
  if (ptr == nullptr) return;
  m_available.push(ptr);
}