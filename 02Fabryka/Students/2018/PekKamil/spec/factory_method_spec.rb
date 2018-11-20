require_relative '../lib/factoryMethod'

describe Train, '#ride' do
  context 'when ride by Locomotive' do
    it 'delegates properly' do
      expect(Train.new.ride('Locomotive').class).to be(Locomotive)
    end

    it 'take train for ride properly' do
      locomotive = Train.new.ride('Locomotive')
      expect(locomotive.model('OK1').class).to be(OK1)
    end

    it 'take train for ride properly' do
      locomotive = Train.new.ride('Locomotive')
      expect(locomotive.model('OK22').class).to be(OK22)
    end

    it 'take train for ride properly' do
      locomotive = Train.new.ride('Locomotive')
      expect(locomotive.model('OL49').class).to be(OL49)
    end

    it 'take train for ride properly' do
      locomotive = Train.new.ride('Locomotive')
      expect(locomotive.model('TY1').class).to be(TY1)
    end

    it 'take train for ride properly' do
      locomotive = Train.new.ride('Locomotive')
      expect(locomotive.model('TY5').class).to be(TY5)
    end
  end

  context 'when ride by Railcar' do
    it 'delegates properly' do
      expect(Train.new.ride('Railcar').class).to be(Railcar)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('Railcar')
      expect(railcar.model('SA133').class).to be(SA133)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('Railcar')
      expect(railcar.model('SA136').class).to be(SA136)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('Railcar')
      expect(railcar.model('SA139').class).to be(SA139)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('Railcar')
      expect(railcar.model('SN82').class).to be(SN82)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('Railcar')
      expect(railcar.model('SN84').class).to be(SN84)
    end
  end

  context 'when ride by EZT' do
    it 'delegates properly' do
      expect(Train.new.ride('EZT').class).to be(EZT)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('EZT')
      expect(railcar.model('EN57').class).to be(EN57)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('EZT')
      expect(railcar.model('EW60').class).to be(EW60)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('EZT')
      expect(railcar.model('EN62').class).to be(EN62)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('EZT')
      expect(railcar.model('EN97').class).to be(EN97)
    end

    it 'Locomotive' do
      railcar = Train.new.ride('EZT')
      expect(railcar.model('ED161').class).to be(ED161)
    end
  end

  context 'when ride by Diesel' do
    it 'delegates properly' do
      expect(Train.new.ride('Diesel').class).to be(Diesel)
    end

    it 'Locomotive' do
      diesel = Train.new.ride('Diesel')
      expect(diesel.model('ST44').class).to be(ST44)
    end

    it 'Locomotive' do
      diesel = Train.new.ride('Diesel')
      expect(diesel.model('SU46').class).to be(SU46)
    end

    it 'Locomotive' do
      diesel = Train.new.ride('Diesel')
      expect(diesel.model('SM48').class).to be(SM48)
    end

    it 'Locomotive' do
      diesel = Train.new.ride('Diesel')
      expect(diesel.model('SM02').class).to be(SM02)
    end

    it 'Locomotive' do
      diesel = Train.new.ride('Diesel')
      expect(diesel.model('SM40').class).to be(SM40)
    end
  end
end
