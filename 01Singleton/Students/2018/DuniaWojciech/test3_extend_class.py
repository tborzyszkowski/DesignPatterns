from singleton_extend import Config

class Config2(Config):
    pass

class Config3(Config2):
    pass

print('----------------------\nSingleton 1:')

cfg1 = Config(username='admin1', password='p@ssw0rd1')
cfg1.printUser()
print('Id obiektu: {}'.format(id(cfg1)))

print('----------------------\nSingleton 2:')

cfg2 = Config2()
cfg2.setUser('2','uzytkownik2','haslo2')
cfg2.printUser()

print('Id obiektu: {}'.format(id(cfg2)))

print('----------------------\nSingleton 3:')

cfg3 = Config3(username='admin3', password='p@ssw0rd3')
cfg3.printUser()
print('Id obiektu: {}'.format(id(cfg3)))

print('----------------------\nSingleton 1:')

cfg1 = Config()
cfg1.printUser()
print('Id obiektu: {}'.format(id(cfg1)))

print('----------------------\nSingleton 2:')

cfg2 = Config2()
cfg2.printUser()
print('Id obiektu: {}'.format(id(cfg2)))


