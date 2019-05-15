from menu.food import Food


class ConCarne(Food):

  def __init__(self, ingredients_factory):
    self._ingredients_factory = ingredients_factory
    super(ConCarne, self).__init__()

  def prepare(self):
    self._meat = self._ingredients_factory.get_meat()
    self._sauce = self._ingredients_factory.get_sauce()
    self._tortilla = self._ingredients_factory.get_tortilla()
    self._vegetables = self._ingredients_factory.get_vegetables()