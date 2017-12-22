package adapter.booking;

import java.util.HashMap;
import java.util.Map;

public class BookingManager {

    private final Map<Long,BookingInterface> bookings = new HashMap<>();

    private long bookingIdCounter;

    public void addBooking(BookingInterface booking) {
        booking.setId(bookingIdCounter++);
        bookings.put(booking.getId(),booking);
    }

}
