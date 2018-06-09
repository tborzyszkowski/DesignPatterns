#pragma once
#include <cstring>

struct very_bad_string_builder
{

  very_bad_string_builder() { 
    m_data = new char[65536]; 
    m_position = m_data;
  }

  ~very_bad_string_builder() { 
    delete[] m_data; 
  }

  very_bad_string_builder& append(char* str) {
    std::memcpy(m_position, str, strlen(str));
    m_position = m_position+strlen(str);
    return *this;
  }

  char* result()
  {
    *m_position = 0;
    reset();
    return m_data;
  }

  void reset()
  {
    m_position = m_data;
  }

private:
  char* m_position;
  char* m_data;
};