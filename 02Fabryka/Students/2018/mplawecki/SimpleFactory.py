from abc import ABCMeta, abstractmethod


class VirtualMachine(metaclass=ABCMeta):
    @abstractmethod
    def start(self):
        pass

class Kvm(VirtualMachine):
    def start(self):
        print("Starting Kvm machine ...")

class Xen(VirtualMachine):
    def start(self):
        print("Starting Xen machine ...")

class VBox(VirtualMachine):
    def start(self):
        print("Starting VBox machine ...")

class Vmware(VirtualMachine):
    def start(self):
        print("Starting Vmware machine ...")

class HyperV(VirtualMachine):
    def start(self):
        print("Starting HyperV machine ...")

class Vendor(object):
    def make_run(self,objtype):
        return eval(objtype)().start()


if __name__=='__main__':
    for i in VirtualMachine.__subclasses__():
        vv = Vendor()
        vv.make_run(str(i.__name__))
