package fasade;

public class Main {

    public static void main(String[] args) {

        NotificationFasade fasade = new NotificationFasade(new SmsService(), new MailService(), new PigeonService());

        fasade.sendNotification(new User("Bob"));
    }
}

