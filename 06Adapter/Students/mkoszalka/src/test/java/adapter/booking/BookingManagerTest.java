package adapter.booking;

import adapter.booking.guest.Adult;
import adapter.booking.guest.Child;
import adapter.booking.room.StandardRoom;
import org.junit.jupiter.api.Test;

import java.time.DayOfWeek;
import java.time.Instant;
import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.time.temporal.TemporalUnit;
import java.util.Arrays;
import java.util.Collections;
import java.util.Date;

class BookingManagerTest {

    @Test
    void test() {
        BookingManager bookingManager = new BookingManager();
        BookingInterface booking = new Booking(LocalDate.now(), LocalDate.now().plusDays(2), Collections.singletonList(new StandardRoom()), Arrays.asList(new Adult(), new Adult(), new Child()));
        OldBooking oldBooking = new OldBooking(Date.from(Instant.now()), Date.from(Instant.now().plus(1, ChronoUnit.DAYS)), 1, 0, 1, 2);
        BookingInterface bookingAdapter = new OldBookingAdapter(oldBooking);
        bookingManager.addBooking(booking);
        bookingManager.addBooking(bookingAdapter);
    }

}