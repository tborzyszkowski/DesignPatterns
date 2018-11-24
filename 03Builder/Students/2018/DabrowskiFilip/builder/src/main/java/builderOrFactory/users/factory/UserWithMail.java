package builderOrFactory.users.factory;

import builderOrFactory.users.User;

public class UserWithMail extends User {

    public UserWithMail() {
        this.userName = "username";
        this.age = 19;
        this.address = "Address 1/2, 92-300, AddressCity";
        this.email = "email@ug.pl";
    }
}
