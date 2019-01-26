from abc import ABCMeta, abstractmethod


class CarAddOn(metaclass=ABCMeta):
    @abstractmethod
    def describe(self):
        pass

class Audio(CarAddOn):
    def describe(self):
        print("Audio Section")

class TRRoof(CarAddOn):
    def describe(self):
        print("Transparent Roof Section")

class GPS(CarAddOn):
    def describe(self):
        print("GPS Section")

class VideoRec(CarAddOn):
    def describe(self):
        print("Video Recorder Section")

class ParkSens(CarAddOn):
    def describe(self):
        print("Car Sensors Section")


class Profile(metaclass=ABCMeta):
    def __init__(self):
        self.sections=[]
        self.createProfile()
    @abstractmethod
    def createProfile(self):
        pass
    def getSections(self):
        return self.sections
    def addSections(self,section):
        self.sections.append(section)

class Vip(Profile):
    def createProfile(self):
        self.addSections(Audio())
        self.addSections(TRRoof())
        self.addSections(GPS())
        self.addSections(VideoRec())
        self.addSections(ParkSens())

class Econo(Profile):
    def createProfile(self):
        self.addSections(Audio())
        self.addSections(GPS())


if __name__=='__main__':
    profile_type = ["Vip","Econo"]
    for i in profile_type:
        profile= eval(i)()
        print("Creating Profile..", type(profile).__name__)
        print("Profile has sections --",profile.getSections())