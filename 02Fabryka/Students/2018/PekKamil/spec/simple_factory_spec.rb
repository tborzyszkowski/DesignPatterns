require_relative '../lib/simpleFactory'

describe SimpleTrainFactory, '#take_a_ride' do
  it 'exists' do
    expect { SimpleTrainFactory.instance }.not_to raise_error
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('Locomotive', 'OK1').class).to be(OK1)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('Locomotive', 'OK22').class).to be(OK22)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('Locomotive', 'OL49').class).to be(OL49)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('Locomotive', 'TY1').class).to be(TY1)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('Locomotive', 'TY5').class).to be(TY5)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('EZT', 'ED161').class).to be(ED161)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('EZT', 'EN57').class).to be(EN57)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('EZT', 'EW60').class).to be(EW60)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('EZT', 'EN97').class).to be(EN97)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('EZT', 'EN62').class).to be(EN62)
    end
  end

  context 'when take train for ride properly' do
    it 'can ride by OK1' do
      expect(SimpleTrainFactory.instance.take_a_ride('Diesel', 'ST44').class).to be(ST44)
    end
  end

  context 'when serving Lunch' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Diesel', 'SU46').class).to be(SU46)
    end
  end

  context 'when serving Lunch' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Diesel', 'SM48').class).to be(SM48)
    end
  end

  context 'when serving Lunch' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Diesel', 'SM02').class).to be(SM02)
    end
  end

  context 'when serving Lunch' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Diesel', 'SM40').class).to be(SM40)
    end
  end

  context 'when serving Supper' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Railcar', 'SA133').class).to be(SA133)
    end
  end

  context 'when serving Supper' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Railcar', 'SA139').class).to be(SA139)
    end
  end

  context 'when serving Supper' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Railcar', 'SA133').class).to be(SA133)
    end
  end

  context 'when serving Supper' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Railcar', 'SN84').class).to be(SN84)
    end
  end

  context 'when serving Supper' do
    it 'can serve pancakes' do
      expect(SimpleTrainFactory.instance.take_a_ride('Railcar', 'SN82').class).to be(SN82)
    end
  end
end
