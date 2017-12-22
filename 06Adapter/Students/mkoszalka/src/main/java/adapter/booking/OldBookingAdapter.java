package adapter.booking;

import adapter.booking.guest.Adult;
import adapter.booking.guest.Child;
import adapter.booking.guest.Person;
import adapter.booking.room.ExclusiveRoom;
import adapter.booking.room.Room;
import adapter.booking.room.StandardRoom;

import java.time.LocalDate;
import java.time.ZoneId;
import java.util.ArrayList;
import java.util.List;

public class OldBookingAdapter implements BookingInterface {

    private OldBooking oldBooking;

    private List<Person> guests = new ArrayList<>();
    private List<Room> rooms = new ArrayList<>();

    public OldBookingAdapter(OldBooking oldBooking) {
        this.oldBooking = oldBooking;
        fillInGuests();
        fillInRooms();
    }

    @Override
    public void setId(Long id) {
        oldBooking.setId(id);
    }

    @Override
    public Long getId() {
        return oldBooking.getId();
    }

    @Override
    public LocalDate getCheckInDate() {
        return oldBooking.getCheckInDate().toInstant().atZone(ZoneId.systemDefault()).toLocalDate();
    }

    @Override
    public LocalDate getCheckOutDate() {
        return oldBooking.getCheckOutDate().toInstant().atZone(ZoneId.systemDefault()).toLocalDate();
    }

    @Override
    public List<Person> getGuests() {
        return guests;
    }

    @Override
    public List<Room> getRooms() {
        return rooms;
    }

    private void fillInGuests() {
        for(int i = 0; i < oldBooking.getNumberOfChildren(); i++) {
            guests.add(new Child());
        }
        for(int i = 0; i < oldBooking.getNumberOfAdults(); i++) {
            guests.add(new Adult());
        }
    }

    private void fillInRooms() {
        for(int i = 0; i < oldBooking.getNumberOfStandardRooms(); i++) {
            rooms.add(new StandardRoom());
        }
        for(int i = 0; i < oldBooking.getNumberOfExclusiveRooms(); i++) {
            rooms.add(new ExclusiveRoom());
        }
    }
}
