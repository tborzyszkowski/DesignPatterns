#pragma once

#include <vector>

template<class T>
class iterable
{
  std::vector<T*> m_items;

public:
  struct iterator
  {
    iterator(const iterable<T>* iterable, unsigned int current=0) 
      : m_iterable(iterable), m_current(current) {}

    bool operator==(const iterator& it) const {
      return it.m_current == m_current;
    }

    bool operator!=(const iterator& it) const {
      return it.m_current != m_current;
    }

    iterator next() const {
      return iterator(m_iterable, m_current+1);
    }

    T* operator*() const { return (*m_iterable)[m_current]; }
    T* operator->() const { return (*m_iterable)[m_current]; }

    iterator& operator++() { m_current++; return *this; }
  private:
    const iterable<T>* m_iterable;
    unsigned int m_current;
  };

  T* operator[](unsigned int index) const
  {
    return m_items[index];
  }

  unsigned int size() const 
  { 
    return m_items.size(); 
  }

  iterator begin() const
  {
    return iterator(this);
  }

  iterator end() const
  {
    iterator(this, size());
  }

  void push(T* item) { m_items.push_back(item); }

  ~iterable()
  {
    //for (auto& item : m_items)
    //  delete item;
  }
};
