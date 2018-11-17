require_relative '../lib/abstract_factory'

describe AbstractBreakfastFactory, '#serve_meal' do
  context 'without concrete factory' do
    it 'raises error' do
      expect { AbstractBreakfastFactory.instance.serve_meal }.to raise_error(NotImplementedError)
    end
  end

  context 'when given pancakes factory' do
    it 'makes pancakes' do
      factory = PancakesFactory.instance
      expect(factory.serve_meal.class).to be(Pancakes)
    end
  end
end
