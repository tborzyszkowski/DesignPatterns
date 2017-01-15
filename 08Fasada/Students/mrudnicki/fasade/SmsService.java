package fasade;

public class SmsService implements NotificationService {
    @Override
    public void sendNotification(User user) {
        System.out.println(String.join(" ", "sending sms to", user.getName(), "...."));
        /**
         *  TODO ....
         */
    }
}

