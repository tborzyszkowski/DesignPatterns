require_relative '../lib/factory_method'

describe Meal, '#serve' do
  context 'when serving breakfast' do
    it 'delegates properly' do
      expect(Meal.new.serve('Breakfast').class).to be(Breakfast)
    end

    it 'serves meal properly' do
      breakfast = Meal.new.serve('Breakfast')
      expect(breakfast.meal('Pancakes').class).to be(Pancakes)
    end
  end

  context 'when serving lunch' do
    it 'delegates properly' do
      expect(Meal.new.serve('Lunch').class).to be(Lunch)
    end

    it 'serves meal properly' do
      lunch = Meal.new.serve('Lunch')
      expect(lunch.meal('Fish & fries').class).to be(FishAndChips)
    end
  end

  context 'when serving supper' do
    it 'delegates properly' do
      expect(Meal.new.serve('Supper').class).to be(Supper)
    end

    it 'serves meal properly' do
      supper = Meal.new.serve('Supper')
      expect(supper.meal('Craft beer').class).to be(CraftBeer)
    end
  end
end
