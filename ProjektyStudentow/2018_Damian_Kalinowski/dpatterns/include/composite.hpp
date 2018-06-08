#pragma once

#include <iterator.hpp>

struct component
{
  constexpr static char LEAF=0;
  constexpr static char COMPOSITE=1;

  char m_type;
  
  virtual void evaluate(unsigned int depth=0) = 0;
};

struct leaf : public component
{
  leaf()
  {
    m_type = LEAF;
  }
};

struct composite : public component, public iterable<component>
{
  composite()
  {
    m_type = COMPOSITE;
  }

  void evaluate(unsigned int depth=0) override
  {
    for (auto it = begin(); it != end(); ++it)
      it->evaluate(depth+1);
  }

};