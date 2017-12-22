package adapter.booking;

import adapter.booking.guest.Person;
import adapter.booking.room.Room;

import java.time.LocalDate;
import java.util.List;

public interface BookingInterface {

    void setId(Long id);

    Long getId();

    LocalDate getCheckInDate();

    LocalDate getCheckOutDate();

    List<Person> getGuests();

    List<Room> getRooms();


}
