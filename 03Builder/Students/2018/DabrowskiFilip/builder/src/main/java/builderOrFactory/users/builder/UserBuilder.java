package builderOrFactory.users.builder;

import builderOrFactory.users.User;

public class UserBuilder {

    private User user;

    public UserBuilder() {
        this.user = new User();
    }

    public UserBuilder withAge(int age) {
        this.user.age = age;
        return this;
    }

    public UserBuilder withUserName(String userName) {
        this.user.userName = userName;
        return this;
    }

    public UserBuilder withAddress(String address) {
        this.user.address = address;
        return this;
    }

    public UserBuilder withEmail(String email) {
        this.user.email = email;
        return this;
    }

    public UserBuilder withPhoneNumber(int phoneNumber) {
        this.user.phoneNumber = phoneNumber;
        return this;
    }

    public User buildUser() {
        return user;
    }

}
