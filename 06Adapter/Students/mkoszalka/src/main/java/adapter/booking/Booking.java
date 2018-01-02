package adapter.booking;

import adapter.booking.guest.Person;
import adapter.booking.room.Room;

import java.time.LocalDate;
import java.util.List;

public class Booking implements BookingInterface {

    private Long id;
    private LocalDate checkInDate;
    private LocalDate checkOutDate;
    private List<Room> rooms;
    private List<Person> guests;

    public Booking(LocalDate checkInDate, LocalDate checkOutDate, List<Room> rooms, List<Person> guests) {
        this.checkInDate = checkInDate;
        this.checkOutDate = checkOutDate;
        this.rooms = rooms;
        this.guests = guests;
    }

    @Override
    public LocalDate getCheckInDate() {
        return checkInDate;
    }

    @Override
    public LocalDate getCheckOutDate() {
        return checkOutDate;
    }

    @Override
    public List<Room> getRooms() {
        return rooms;
    }

    @Override
    public List<Person> getGuests() {
        return guests;
    }

    @Override
    public Long getId() {
        return id;
    }

    @Override
    public void setId(Long id) {
        this.id = id;
    }
}
