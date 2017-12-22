package adapter.booking;

import java.util.Date;

public class OldBooking {

    private Long id;
    private Date checkInDate;
    private Date checkOutDate;
    private Integer numberOfStandardRooms;
    private Integer numberOfExclusiveRooms;
    private Integer numberOfChildren;
    private Integer numberOfAdults;

    public OldBooking(Date checkInDate, Date checkOutDate, Integer numberOfStandardRooms, Integer numberOfExclusiveRooms, Integer numberOfChildren, Integer numberOfAdults) {
        this.checkInDate = checkInDate;
        this.checkOutDate = checkOutDate;
        this.numberOfStandardRooms = numberOfStandardRooms;
        this.numberOfExclusiveRooms = numberOfExclusiveRooms;
        this.numberOfChildren = numberOfChildren;
        this.numberOfAdults = numberOfAdults;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Date getCheckInDate() {
        return checkInDate;
    }

    public Date getCheckOutDate() {
        return checkOutDate;
    }

    public Integer getNumberOfStandardRooms() {
        return numberOfStandardRooms;
    }

    public Integer getNumberOfExclusiveRooms() {
        return numberOfExclusiveRooms;
    }

    public Integer getNumberOfChildren() {
        return numberOfChildren;
    }

    public Integer getNumberOfAdults() {
        return numberOfAdults;
    }

}
