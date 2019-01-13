import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import user.builder.UserBuilder;
import user.model.User;

public class BuilderOrFactoryUser {

    UserBuilder userBuilder;

    @Before
    public void prepare_builder() {
        this.userBuilder = new UserBuilder();
    }

    @Test
    public void build_user_with_email() {

        User userBuildedWithEmail = userBuilder
                .withUserName("username")
                .withAge(19).withAddress("Address 1/2, 92-300, AddressCity")
                .withEmail("email@ug.pl")
                .buildUser();

        Assert.assertEquals("username", userBuildedWithEmail.getUserName());
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userBuildedWithEmail.getAddress());
        Assert.assertEquals(19, userBuildedWithEmail.getAge());
        Assert.assertEquals("email@ug.pl", userBuildedWithEmail.getEmail());
        Assert.assertEquals(0, userBuildedWithEmail.getPhoneNumber());

    }

    @Test
    public void build_user_with_phone_number() {
        UserBuilder userBuilder = new UserBuilder();

        User userBuildedWithphoneNumber = userBuilder
                .withUserName("username")
                .withAge(19).withAddress("Address 1/2, 92-300, AddressCity")
                .withPhoneNumber(123456789)
                .buildUser();

        Assert.assertEquals("username", userBuildedWithphoneNumber.getUserName());
        Assert.assertEquals("Address 1/2, 92-300, AddressCity", userBuildedWithphoneNumber.getAddress());
        Assert.assertEquals(19, userBuildedWithphoneNumber.getAge());
        Assert.assertEquals(null, userBuildedWithphoneNumber.getEmail());
        Assert.assertEquals(123456789, userBuildedWithphoneNumber.getPhoneNumber());

    }

    @Test
    public void build_user_with_email_and_phone_number() {

        User userBuildedWithEmailAndPhoneNumber = userBuilder
                .withUserName("username")
                .withAge(19).withAddress("Address 1/2, 92-300, AddressCity")
                .withEmail("email@ug.pl")
                .withPhoneNumber(123456789)
                .buildUser();

        Assert.assertEquals("username", userBuildedWithEmailAndPhoneNumber.getUserName());
        Assert.assertEquals("Address 1/2, 92-300, AddressCity",
                userBuildedWithEmailAndPhoneNumber.getAddress());
        Assert.assertEquals(19, userBuildedWithEmailAndPhoneNumber.getAge());
        Assert.assertEquals("email@ug.pl", userBuildedWithEmailAndPhoneNumber.getEmail());
        Assert.assertEquals(123456789, userBuildedWithEmailAndPhoneNumber.getPhoneNumber());

    }

}
