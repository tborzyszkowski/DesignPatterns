from django.db import models
from django.utils import timezone
import pyowm
import copy


#singleton model implementation to have only once instance and element of object
class SingletonModel(models.Model):
    class Meta:
        abstract = True

    def save(self, *args, **kwargs):
        self.pk = 1
        super(SingletonModel, self).save(*args, **kwargs)

    def delete(self, *args, **kwargs):
        pass

    @classmethod
    def load(cls):
        obj, created = cls.objects.get_or_create(pk=1)
        return obj

class Weather(SingletonModel):
    time = models.DateTimeField(default=timezone.now)
    status = models.CharField(max_length=20)
    temp = models.CharField(max_length=3)

    def set_temp(self):
        owm = pyowm.OWM('4ab4afbbbd053121ed05cc6e7e84bec9')
        observation = owm.weather_at_place('Gdansk,pl')
        weather = observation.get_weather()
        self.temp = weather.get_temperature('celsius').get('temp')
        self.save()

    def set_status(self):
        owm = pyowm.OWM('4ab4afbbbd053121ed05cc6e7e84bec9')
        observation = owm.weather_at_place('Gdansk,pl')
        weather = observation.get_weather()
        self.status = weather.get_status()
        self.save()

    def update_weather(self):
        self.time = timezone.now()
        self.set_temp()
        self.set_status()

#prototype
class PostPrototype(models.Model):
    class Meta:
        abstract = True

    author = models.ForeignKey('auth.User')
    title = models.CharField(max_length=200)
    text = models.TextField()
    created_date = models.DateTimeField(
        default=timezone.now)
    published_date = models.DateTimeField(
        blank=True, null=True)

    def clone(self):
        pass

class Post(PostPrototype):
    def publish(self):
        self.published_date = timezone.now()
        self.save()

    def clone(self):
        return copy.deepcopy(self)

    def __str__(self):
        return self.title