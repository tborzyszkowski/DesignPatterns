package fasade;

import java.util.ArrayList;
import java.util.List;

public class NotificationFasade {

    private List<NotificationService> notificationServices;

    public NotificationFasade(NotificationService mailService, NotificationService smsService, NotificationService pigeonService) {
        notificationServices = new ArrayList<>();
        notificationServices.add(mailService);
        notificationServices.add(smsService);
        notificationServices.add(pigeonService);
    }

    public void sendNotification(final User user) {
        notificationServices.stream().forEach(service -> service.sendNotification(user));
    }

}

