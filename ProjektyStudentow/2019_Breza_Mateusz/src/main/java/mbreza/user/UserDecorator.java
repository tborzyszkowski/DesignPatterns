package mbreza.user;

public abstract class UserDecorator implements User {
    protected User decoratedUser;

    public UserDecorator(User decoratedUser){
        this.decoratedUser = decoratedUser;
    }
}
