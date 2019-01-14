package builderOrFactory.users.factory;

import builderOrFactory.users.User;

public class UserWithMailAndPhoneNumber extends User {

    public UserWithMailAndPhoneNumber() {
        this.userName = "username";
        this.age = 19;
        this.address = "Address 1/2, 92-300, AddressCity";
        this.phoneNumber = 123456789;
        this.email = "email@ug.pl";
    }

}
