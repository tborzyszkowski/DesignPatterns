package builderOrFactory.users.factory;

import builderOrFactory.users.User;
import builderOrFactory.users.UserType;

public class UserFactory {

    private static UserFactory userFactory;

    public static UserFactory getInstance() {
        if(userFactory == null) {
            userFactory = new UserFactory();
        }
        return userFactory;
    }

    public User createUser(UserType userType) {
        if(userType == UserType.EMAIL){
            return new UserWithMail();
        } else if (userType == UserType.PHONE_NUMBER) {
            return new UserWithPhoneNumber();
        } else if (userType == UserType.EMAIL_AND_PHONE_NUMBER) {
            return new UserWithMailAndPhoneNumber();
        } else {
            return null;
        }
    }

}
