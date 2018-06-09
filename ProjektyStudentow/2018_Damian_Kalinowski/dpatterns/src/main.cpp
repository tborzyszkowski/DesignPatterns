#include <iostream>
#include <string>

#include <object_pool.hpp>  // singleton+object_pool
#include <observer.hpp>     // observer
#include <iterator.hpp>     // iterator
#include <composite.hpp>    // iterator+composite

#include <third_party.hpp>  // adapter+builder

/*
  Creational Patterns:
  - Singleton
  - Object Pool
  - Builder

  Behavioral Patterns
  - Observer
  - Iterator

  Structural Patterns
  - Adapter
  - Composite
*/

struct folder : public composite
{
  std::string m_name;

  folder (const std::string& name) 
    : m_name(name) {}

  void evaluate(unsigned int depth=0) override {
    for (unsigned int i = 0; i < depth; i++)
      std::cout << "-";
    std::cout << m_name << std::endl;
    composite::evaluate(depth);
  }
};

struct file : public leaf, public observable<file>
{
  file (const std::string& name, const std::string& content) 
    : m_name(name), m_content(content) {}

  void evaluate(unsigned int depth=0) override {
    for (unsigned int i = 0; i < depth; i++)
      std::cout << "-";
    std::cout << m_name << std::endl;
    for (unsigned int i = 0; i < depth; i++)
      std::cout << "-";
    std::cout << "\t\t";
    std::cout << m_content << std::endl;
  }

  void change_content(const std::string& content)
  {
    m_content = content;
    notify();
  }

  const std::string content() const { return m_content; }
  const std::string name() const { return m_name; }

private:
  std::string m_name;
  std::string m_content;
};

struct string_adapter : public very_bad_string_builder
{
  string_adapter* append(const std::string& str) {
    very_bad_string_builder::append((char*)str.c_str());
    return this;
  }

  const std::string eval() {
    return std::string(result());
  }
};

// 3 objects in pool
typedef object_pool<string_adapter, 3> StringPool;

int main()
{
  // Folders
  folder my_computer{"My Computer"};
  folder c_drive{"C:"};
  folder d_drive{"D:"};
  folder program_files{"Program Files"};
  folder bin {"bin"};

  my_computer.push(&c_drive);
  my_computer.push(&d_drive);
  
  c_drive.push(&program_files);
  program_files.push(&bin);

  // Files
  file my_settings  {"my_settings.ini", "GRAPHICS=LOW; RESOLUTION=1920x1280; ..."};
  file my_keybinds  {"my_keybinds.ini", "W=FORWARD; A=LEFT; D=RIGHT; S=BACKWARD; SPACE=JUMP; ..."};
  file engine       {"engine.exe", "0x9ad317334367519072d9ba8abf2e74a6..."};
  file json         {"settings.json", "{\"graphics\": \"low\", \"resolution\": {\"width\": 1920, \"height\": 1280 ..."};

  program_files.push(&my_settings);
  program_files.push(&my_keybinds);
  program_files.push(&engine);
  d_drive.push(&json);

  auto content_watcher = [](const file& f) {
    std::cout << f.name() << " has changed content to: " << f.content() << std::endl;
  };

  my_computer.evaluate();

  my_settings .attach(content_watcher);
  my_keybinds .attach(content_watcher);
  engine      .attach(content_watcher);
  json        .attach(content_watcher);

  // 3 builders in pool
  // automatic release to pool when smart pointer gets out of scope
  {
    auto builder1 = StringPool::instance().acquire();
    my_settings   .change_content(builder1->append("NO_SETTINGS=TRUE;")->eval());

    auto builder2 = StringPool::instance().acquire();
    my_keybinds   .change_content(builder2->append("SPACE=JUMP;")->eval());

    auto builder3 = StringPool::instance().acquire();
    engine        .change_content(builder3->append("0x")->append("123456789ABCDEF")->eval());
  }

  auto builder4 = StringPool::instance().acquire();
  json          .change_content(builder4->append("{}")->eval());

  my_computer.evaluate();

  return 0;
}