from menu.food import Food


class GrilledChicken(Food):

  def __init__(self, ingredients_factory):
    self._ingredients_factory = ingredients_factory

  def prepare(self):
    self._meat = self._ingredients_factory.get_meat()
    self._sauce = self._ingredients_factory.get_sauce()
    self._tortilla = self._ingredients_factory.get_tortilla()
    self._vegetables = self._ingredients_factory.get_vegetables()