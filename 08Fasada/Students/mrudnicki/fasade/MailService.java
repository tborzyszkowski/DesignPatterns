package fasade;

public class MailService implements NotificationService {

    @Override
    public void sendNotification(User user) {
        System.out.println(String.join(" ", "sending mail to", user.getName(), "...."));

        /**
         * TODO ...
         */
    }
}

