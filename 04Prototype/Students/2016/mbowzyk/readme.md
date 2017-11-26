Proste klonowanie znajduje się w klasie `Employees`. By sklonować klasę, trzeba w metodzie clone() stworzyć nową kolekcję. W innym przypadku będzie ona ponownie użyta. 

Za wyjątkiem `data class`, klasy w kotlinie nie zawierają metody copy() lub clone(), trzeba samodzielnie ją przygotować.


W paczce `deepCloning` znajduje się bardziej zaawansowany przykład, który jest rozwinięciem tego prostego. Tam w liście nie ma typu prostego, tylko obiekt `data class`. 
Te obiekty w metodzie clone() muszą być przekopiowane. 
