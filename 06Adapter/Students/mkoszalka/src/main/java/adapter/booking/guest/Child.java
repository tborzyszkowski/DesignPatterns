package adapter.booking.guest;

import adapter.booking.enums.PersonType;

public class Child implements Person {

    @Override
    public PersonType getType() {
        return PersonType.CHILD;
    }
}
