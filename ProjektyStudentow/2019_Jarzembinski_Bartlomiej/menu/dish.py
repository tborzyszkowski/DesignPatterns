class Dish:
    
  def __init__(self):
    self._name : str
    self._price : float
    self._tortilla : str
    self._spice : str
    self._components : list

  def print_info(self):
    raise NotImplementedError
