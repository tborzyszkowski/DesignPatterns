import threading
import time
from singleton import Config

class CreateThread(object):
    instances = {}
    thList = []
    
    @staticmethod
    def createSingleton(threadName, delay):
        cfg = Config.getConfig() # dziala tez: cfg = Config()
        CreateThread.instances[str(cfg.getId())] = 1
        #time.sleep(delay)

    @staticmethod
    def resetSingleton():
        if len(CreateThread.instances)>1:
            print('Liczba konfliktow tworzenia singletona przez watki: %s' % len(CreateThread.instances))
            stop = False
        else: 
            print('Brak konfliktow')
        CreateThread.instances = {}
        Config.resetConfig()

''' 
#############################################
Glowny blok
#############################################
''' 
def main():
    startTime = time.time()
    for iter in range(100):
        # Uruchomienie watkow
        try:
            for i in range(100):
                th = threading.Thread(target = CreateThread.createSingleton, name = 'th{}'.format(i), args=('th{}'.format(i),0.01))
                CreateThread.thList.append(th)
                th.start()    
        except:
            print ("Nie mozna uruchomic watkow")
        # Oczekiwanie na zakonczenie watkow
        for t in CreateThread.thList:
            t.join()
        CreateThread.resetSingleton()
    endTime = time.time()
    print('Czas dzialania algorytmu: {}'.format(endTime-startTime))

if __name__ == "__main__":
    main()