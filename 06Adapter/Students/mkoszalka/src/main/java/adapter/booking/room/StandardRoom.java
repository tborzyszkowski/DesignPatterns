package adapter.booking.room;

import adapter.booking.enums.RoomType;

public class StandardRoom implements Room {
    @Override
    public RoomType getType() {
        return RoomType.STANDARD;
    }
}
