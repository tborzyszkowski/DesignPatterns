package adapter.booking.room;

import adapter.booking.enums.RoomType;

public class ExclusiveRoom implements Room{
    @Override
    public RoomType getType() {
        return RoomType.EXCLUSIVE;
    }
}
