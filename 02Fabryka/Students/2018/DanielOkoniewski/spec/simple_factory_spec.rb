require_relative '../lib/simple_factory'

describe SimpleMealFactory, '#serve_meal' do
  it 'exists' do
    expect { SimpleMealFactory.instance }.not_to raise_error
  end

  context 'when serving breakfast' do
    it 'can serve pancakes' do
      expect(SimpleMealFactory.instance.serve_meal('Breakfast', 'Pancakes').class).to be(Pancakes)
    end

    it 'can serve scrambled eggs' do
      expect(SimpleMealFactory.instance.serve_meal('Breakfast', 'Scrambled eggs').class).to be(ScrambledEggs)
    end
  end

  context 'when serving Lunch' do
    it 'can serve pancakes' do
      expect(SimpleMealFactory.instance.serve_meal('Lunch', 'Spinach burger').class).to be(VegeBurger)
    end

    it 'can serve scrambled eggs' do
      expect(SimpleMealFactory.instance.serve_meal('Lunch', 'Fish & fries').class).to be(FishAndChips)
    end
  end

  context 'when serving Supper' do
    it 'can serve pancakes' do
      expect(SimpleMealFactory.instance.serve_meal('Supper', 'Kebab').class).to be(Kebab)
    end

    it 'can serve scrambled eggs' do
      expect(SimpleMealFactory.instance.serve_meal('Supper', 'Pizza').class).to be(Pizza)
    end
  end
end
