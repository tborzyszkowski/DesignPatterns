require_relative '../lib/SimpleBuilder/abstractFactory'

describe AbstractLocomotiveFactory, '#take_a_ride' do
  context 'without concrete factory' do
    it 'raises error' do
      expect { AbstractLocomotiveFactory.instance.take_a_ride }.to raise_error(NotImplementedError)
    end
  end

  context 'when given OK1 factory' do
    it 'makes OK1' do
      factory = OK1Factory.instance
      expect(factory.take_a_ride.class).to be(OK1)
    end
  end

  context 'when given OK22 factory' do
    it 'makes OK22' do
      factory = OK22Factory.instance
      expect(factory.take_a_ride.class).to be(OK22)
    end
  end

  context 'when given OL49 factory' do
    it 'makes OL49' do
      factory = OL49Factory.instance
      expect(factory.take_a_ride.class).to be(OL49)
    end
  end

  context 'when given TY1 factory' do
    it 'makes TY1' do
      factory = TY1Factory.instance
      expect(factory.take_a_ride.class).to be(TY1)
    end
  end

  context 'when given TY5 factory' do
    it 'makes TY5' do
      factory = TY5Factory.instance
      expect(factory.take_a_ride.class).to be(TY5)
    end
  end

  context 'when given EN57 factory' do
    it 'makes EN57' do
      factory = EN57Factory.instance
      expect(factory.take_a_ride.class).to be(EN57)
    end
  end

  context 'when given ED161 factory' do
    it 'makes ED161' do
      factory = ED161Factory.instance
      expect(factory.take_a_ride.class).to be(ED161)
    end
  end

  context 'when given EN97 factory' do
    it 'makes EN97' do
      factory = EN97Factory.instance
      expect(factory.take_a_ride.class).to be(EN97)
    end
  end

  context 'when given EN62 factory' do
    it 'makes EN62' do
      factory = EN62Factory.instance
      expect(factory.take_a_ride.class).to be(EN62)
    end
  end

  context 'when given EW60 factory' do
    it 'makes EW60' do
      factory = EW60Factory.instance
      expect(factory.take_a_ride.class).to be(EW60)
    end
  end

  context 'when given ST44 factory' do
    it 'makes ST44' do
      factory = ST44Factory.instance
      expect(factory.take_a_ride.class).to be(ST44)
    end
  end

  context 'when given SU46 factory' do
    it 'makes SU46' do
      factory = SU46Factory.instance
      expect(factory.take_a_ride.class).to be(SU46)
    end
  end

  context 'when given SM48 factory' do
    it 'makes SM48' do
      factory = SM48Factory.instance
      expect(factory.take_a_ride.class).to be(SM48)
    end
  end

  context 'when given SM02 factory' do
    it 'makes SM02' do
      factory = SM02Factory.instance
      expect(factory.take_a_ride.class).to be(SM02)
    end
  end

  context 'when given SM40 factory' do
    it 'makes SM40' do
      factory = SM40Factory.instance
      expect(factory.take_a_ride.class).to be(SM40)
    end
  end

  context 'when given SA133 factory' do
    it 'makes SA133' do
      factory = SA133Factory.instance
      expect(factory.take_a_ride.class).to be(SA133)
    end
  end

  context 'when given SA136 factory' do
    it 'makes SA136' do
      factory = SA136Factory.instance
      expect(factory.take_a_ride.class).to be(SA136)
    end
  end

  context 'when given SA139 factory' do
    it 'makes SA139' do
      factory = SA139Factory.instance
      expect(factory.take_a_ride.class).to be(SA139)
    end
  end

  context 'when given SN82 factory' do
    it 'makes SN82' do
      factory = SN82Factory.instance
      expect(factory.take_a_ride.class).to be(SN82)
    end
  end

  context 'when given SN84 factory' do
    it 'makes SN84' do
      factory = SN84Factory.instance
      expect(factory.take_a_ride.class).to be(SN84)
    end
  end
end
