package fasade;

public class PigeonService implements NotificationService {

    @Override
    public void sendNotification(User user) {
        System.out.println(String.join(" ", "sending pigeon to", user.getName(), "...."));

        /**
         * TODO...
         */
    }
}

