package adapter.booking.guest;

import adapter.booking.enums.PersonType;

public class Adult implements Person {

    @Override
    public PersonType getType() {
        return PersonType.ADULT;
    }
}
