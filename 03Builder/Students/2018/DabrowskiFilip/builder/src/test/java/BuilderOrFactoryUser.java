import builderOrFactory.users.User;
import builderOrFactory.users.UserType;
import builderOrFactory.users.builder.UserBuilder;
import builderOrFactory.users.factory.UserFactory;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class BuilderOrFactoryUser {

    UserBuilder userBuilder;
    UserFactory userFactory;

    @Before
    public void prepare_builder() {
        this.userBuilder = new UserBuilder();
        this.userFactory = UserFactory.getInstance();
    }

    @Test
    public void build_user_with_email() {

        User userBuildedWithEmail = userBuilder
                .withUserName("username")
                .withAge(19).withAddress("Address 1/2, 92-300, AddressCity")
                .withEmail("email@ug.pl")
                .buildUser();

        Assert.assertEquals("username", userBuildedWithEmail.userName);
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userBuildedWithEmail.address);
        Assert.assertEquals(19, userBuildedWithEmail.age);
        Assert.assertEquals("email@ug.pl", userBuildedWithEmail.email);
        Assert.assertEquals(0, userBuildedWithEmail.phoneNumber);

    }

    @Test
    public void build_user_with_phone_number() {
        UserBuilder userBuilder = new UserBuilder();

        User userBuildedWithphoneNumber = userBuilder
                .withUserName("username")
                .withAge(19).withAddress("Address 1/2, 92-300, AddressCity")
                .withPhoneNumber(123456789)
                .buildUser();

        Assert.assertEquals("username", userBuildedWithphoneNumber.userName);
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userBuildedWithphoneNumber.address);
        Assert.assertEquals(19, userBuildedWithphoneNumber.age);
        Assert.assertEquals(null, userBuildedWithphoneNumber.email);
        Assert.assertEquals(123456789, userBuildedWithphoneNumber.phoneNumber);

    }

    @Test
    public void build_user_with_email_and_phone_number() {

        User userBuildedWithEmailAndPhoneNumber = userBuilder
                .withUserName("username")
                .withAge(19).withAddress("Address 1/2, 92-300, AddressCity")
                .withEmail("email@ug.pl")
                .withPhoneNumber(123456789)
                .buildUser();

        Assert.assertEquals("username", userBuildedWithEmailAndPhoneNumber.userName);
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userBuildedWithEmailAndPhoneNumber.address);
        Assert.assertEquals(19, userBuildedWithEmailAndPhoneNumber.age);
        Assert.assertEquals("email@ug.pl", userBuildedWithEmailAndPhoneNumber.email);
        Assert.assertEquals(123456789, userBuildedWithEmailAndPhoneNumber.phoneNumber);

    }

    @Test
    public void create_user_with_email() {
        User userCreatedWithMail = userFactory.createUser(UserType.EMAIL);

        System.out.println(userCreatedWithMail.toString());

        Assert.assertEquals("username", userCreatedWithMail.userName);
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userCreatedWithMail.address);
        Assert.assertEquals(19, userCreatedWithMail.age);
        Assert.assertEquals("email@ug.pl", userCreatedWithMail.email);
        Assert.assertEquals(0, userCreatedWithMail.phoneNumber);

    }

    @Test
    public void create_user_with_phone_number() {
        User userCreatedWithPhoneNumber = userFactory.createUser(UserType.PHONE_NUMBER);

        System.out.println(userCreatedWithPhoneNumber.toString());

        Assert.assertEquals("username", userCreatedWithPhoneNumber.userName);
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userCreatedWithPhoneNumber.address);
        Assert.assertEquals(19, userCreatedWithPhoneNumber.age);
        Assert.assertEquals(null, userCreatedWithPhoneNumber.email);
        Assert.assertEquals(123456789, userCreatedWithPhoneNumber.phoneNumber);

    }

    @Test
    public void create_user_with_email_and_phone_number() {
        User userWithMailAndPhoneNumber = userFactory.createUser(UserType.EMAIL_AND_PHONE_NUMBER);

        System.out.println(userWithMailAndPhoneNumber.toString());

        Assert.assertEquals("username", userWithMailAndPhoneNumber.userName);
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userWithMailAndPhoneNumber.address);
        Assert.assertEquals(19, userWithMailAndPhoneNumber.age);
        Assert.assertEquals("email@ug.pl", userWithMailAndPhoneNumber.email);
        Assert.assertEquals(123456789, userWithMailAndPhoneNumber.phoneNumber);

    }

}
